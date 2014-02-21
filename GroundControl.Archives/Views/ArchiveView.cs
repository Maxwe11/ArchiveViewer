namespace GroundControl.Archives.Views
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    using GroundControl.Archives.ViewModels;
    using GroundControl.Common;
    using GroundControl.Common.Extensions;

    using Telerik.WinControls.UI;

    internal partial class ArchiveView : UserControl
    {
        #region Fields

        private readonly ArchiveViewModel mViewModel;

        private readonly Dictionary<object, ICommand> mCommands = new Dictionary<object, ICommand>();

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

        private void OnArchiveRecordsGridViewDataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            foreach (var column in mArchiveRecordsGridView.Columns.Where(column => 
                column.Name.StartsWith("Raw", StringComparison.OrdinalIgnoreCase)))
            {
                column.IsVisible = false;
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

        private void OnButtonClick(object sender, EventArgs e)
        {
            mCommands[sender].Execute();
        }

        #endregion

        #region Own methods

        private void BindViewModel()
        {
            //archive records
            mArchiveRecordsBindingSource.DataSource = mViewModel;
            mArchiveRecordsBindingSource.DataMember = mViewModel.MemberName(x => x.ArchiveRecords);

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
            mCommands.Add(mReadRecordsBtn, mViewModel.ReadRecordsCommand);
            mCommands.Add(mReadRegistersBtn, mViewModel.ReadRegistersCommand);
            mCommands.Add(mEraseArchiveBtn, mViewModel.EraseArchiveCommand);

            //blocking ops
            //mRecordsReadingGroupBox.DataBindings.Add("Enabled", mViewModel, "Enabled");
            //mRegistersReadingGroupBox.DataBindings.Add("Enabled", mViewModel, "Enabled");

            mViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        #endregion

        #endregion
    }
}
