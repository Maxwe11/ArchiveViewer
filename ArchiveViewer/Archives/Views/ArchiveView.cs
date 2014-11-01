namespace ArchiveViewer.Archives.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;
    using Common.Extensions;
    using Telerik.WinControls.UI;
    using ViewModels;

    internal partial class ArchiveView : UserControl
    {
        #region Fields

        private readonly ArchiveViewModel mViewModel;

        private readonly Dictionary<object, Action> mCommands = new Dictionary<object, Action>();

        private Lazy<RadContextMenu> mLazyContextMenu;

        #endregion

        #region Constructor

        public ArchiveView(ArchiveViewModel viewModel)
        {
            viewModel.CheckNull("viewModel");
            mViewModel = viewModel;

            InitializeComponent();
            BindViewModel();
        }

        #endregion

        #region Methods

        #region Event handlers

        private void OnLoad(object sender, EventArgs e)
        {
            PrepareMenus();
            PrepareColumns();
            PrepareConditionalFormattingColumns();
        }

        private void OnDecMenuMenuItemClick(object sender, EventArgs e)
        {
            var column = mLazyContextMenu.Value.DropDown.Tag as GridViewDecimalColumn;
            if (column != null)
                column.FormatString = @"{0:D}";
        }

        private void OnHexMenuMenuItemClick(object sender, EventArgs eventArgs)
        {
            var column = mLazyContextMenu.Value.DropDown.Tag as GridViewDecimalColumn;
            if (column != null)
                column.FormatString = @"0x{0:X}";
        }

        private void OnArchiveRecordsGridViewDataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            foreach (var column in mArchiveRecordsGridView.Columns)
            {
                if (column.Name.Contains("Raw"))
                {
                    column.IsVisible = false;
                }
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Enabled")
            {
                mRecordsReadingGroupBox.Enabled = mViewModel.Enabled;
                mRegistersReadingGroupBox.Enabled = mViewModel.Enabled;
            }
        }

        private void OnArchiveBindingSourceChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.Reset)
                mArchiveRecordsGridView.BestFitColumns();
        }

        private void OnArchiveRecordsGridViewContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            var cell = e.ContextMenuProvider as GridHeaderCellElement;

            if (cell == null)
                return;

            var column = cell.Data as GridViewDecimalColumn;

            if (column != null)// && column.DataType != typeof(float) && column.DataType != typeof(double))
            {
                var type = column.DataType;
                if (type != typeof(sbyte) && type != typeof(short) && type != typeof(int) &&
                    type != typeof(byte) && type != typeof(ushort) && type != typeof(uint))
                    return;

                mLazyContextMenu.Value.DropDown.Tag = cell.Data;
                e.ContextMenu = mLazyContextMenu.Value.DropDown;
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            mCommands[sender].Invoke();
        }

        #endregion

        #region Own methods

        private void BindViewModel()
        {
            //archive records
            mArchiveBindingSource.DataSource = mViewModel;
            mArchiveBindingSource.DataMember = mViewModel.MemberName(x => x.ArchiveRecords);
            mArchiveBindingSource.ListChanged += OnArchiveBindingSourceChanged;

            //position and count for reading
            mRecordPositionSpinEditor.DataBindings.Add("Value", mViewModel, mViewModel.MemberName(x => x.RecordPosition));
            mRecordPositionSpinEditor.Maximum = mViewModel.MaximumPosition;
            mRecordsCountSpinEditor.DataBindings.Add("Value", mViewModel, mViewModel.MemberName(x => x.RecordsCount));
            mRecordsCountSpinEditor.Maximum = mViewModel.MaximumRecordsCount;

            //archive registers
            mCmndRegValueTextBox.DataBindings.Add("Text", mViewModel, mViewModel.MemberName(x => x.CmndRegValue));
            mPosRecRegValueTextBox.DataBindings.Add("Text", mViewModel, mViewModel.MemberName(x => x.PosRecRegValue));
            mDataRegValueTextBox.DataBindings.Add("Text", mViewModel, mViewModel.MemberName(x => x.DataRegValue));

            //archive reference info
            var culture = CultureInfo.InvariantCulture;
            mCmndRegAddressTextBox.Text = mViewModel.CmndRegAddress.ToString(culture);
            mRecordsRegistersTextBox.Text = mViewModel.RecordRegistersCount.ToString(culture);
            mArchiveDeepnessTextBox.Text = mViewModel.ArchiveDeepness.ToString(culture);

            //add commands
            mCommands.Add(mReadRecordsBtn,
                () =>
                {
                    var cell = mArchiveRecordsGridView.CurrentCell;
                    int columnIndex = 0;

                    if (cell != null)
                        columnIndex = cell.ColumnIndex;

                    mViewModel.ReadRecordsCommand.Execute();

                    if (cell != null && columnIndex < mArchiveRecordsGridView.ColumnCount)
                        mArchiveRecordsGridView.TableElement.ScrollToColumn(columnIndex);
                });
            mCommands.Add(mReadRegistersBtn, () => mViewModel.ReadRegistersCommand.Execute());
            mCommands.Add(mEraseArchiveBtn, () => mViewModel.EraseArchiveCommand.Execute());

            //blocking ops
            //mRecordsReadingGroupBox.DataBindings.Add("Enabled", mViewModel, "Enabled");
            //mRegistersReadingGroupBox.DataBindings.Add("Enabled", mViewModel, "Enabled");

            mViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void PrepareMenus()
        {
            mLazyContextMenu = new Lazy<RadContextMenu>(
                () =>
                {
                    var contextMenu = new RadContextMenu();
                    var menuItem1 = new RadMenuItem("Hex");
                    var menuItem2 = new RadMenuItem("Dec");
                    
                    menuItem1.Click += OnHexMenuMenuItemClick;
                    menuItem2.Click += OnDecMenuMenuItemClick;
                    
                    contextMenu.Items.Add(menuItem1);
                    contextMenu.Items.Add(menuItem2);
                    return contextMenu;
                });
                
//            mHexMenuItem = new Lazy<RadMenuItem>(
//                () =>
//                {
//                    var item = new RadMenuItem("Hex");
//                    item.Click += OnHexMenuMenuItemClick;
//                    return item;
//                });
//
//            mDecMenuItem = new Lazy<RadMenuItem>(
//                () =>
//                {
//                    var item = new RadMenuItem("Dec");
//                    item.Click += OnDecMenuMenuItemClick;
//                    return item;
//                });
        }

        private void PrepareConditionalFormattingColumns()
        {
            var column = mArchiveRecordsGridView.Columns.FirstOrDefault(x => x.Name == "Crc16Matched");
            if (column != null)
            {
                var obj = new ConditionalFormattingObject
                {
                    Name = "BadCrc",
                    ConditionType = ConditionTypes.Equal,
                    TValue1 = "False",
                    ApplyToRow = true,
                    RowForeColor = Color.Red
                };

                column.ConditionalFormattingObjectList.Add(obj);
            }
        }

        private void PrepareColumns()
        {
            var count = mArchiveRecordsGridView.ColumnCount;
            for (int i = 0; i < 6 && i < count; ++i)
                mArchiveRecordsGridView.Columns[i].PinPosition = PinnedColumnPosition.Left;
            
            mArchiveRecordsGridView.BestFitColumns();
        }

        #endregion

        #endregion
    }
}
