namespace ArchiveViewer.Archives.ViewModels
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Common;
    using Common.Decoders.Archives;
    using Common.Extensions;
    using Common.Helpers;
    using Common.Models.Archives;
    using Common.Properties;

    internal sealed class ArchiveViewModel : ViewModelBase
    {
        #region Fields

        private readonly ArchiveType mArchive;

        private readonly ArchiveManager mManager;

        private readonly ArchiveDecoder mDecoder;

        private ushort mRecordPosition;

        private int mRecordsCount;

        private ushort mCmndRegValue;

        private ushort mPosRecRegValue;

        private ushort mDataRegValue;

        #endregion

        #region Constructor

        internal ArchiveViewModel(ArchiveType type, ArchiveManager manager)
        {
            type.CheckNull("type");
            manager.CheckNull("manager");

            mArchive = type;
            mManager = manager;
            mDecoder = type.Decoder;

            ArchiveRecords = mDecoder.Template;
            DisplayName = type.DisplayName;

            ReadRecordsCommand = new RelayCommand(ReadRecords);
            ReadRegistersCommand = new RelayCommand(ReadRegisters);
            EraseArchiveCommand = new RelayCommand(EraseArchive);
        }

        #endregion

        #region Properties

        #region Data

        #region Read registers options

        public ushort RecordPosition
        {
            get { return mRecordPosition; }
            set
            {
                if (value == mRecordPosition)
                    return;

                mRecordPosition = value;
                OnPropertyChanged("RecordPosition");
            }
        }

        public int RecordsCount
        {
            get { return mRecordsCount; }
            set
            {
                if (value == mRecordsCount)
                    return;

                mRecordsCount = value;
                OnPropertyChanged("RecordsCount");
            }
        }

        public int MaximumPosition { get { return mArchive.RecordsCount - 1; } }

        public int MaximumRecordsCount { get { return mArchive.RecordsCount; } }

        #endregion

        #region Registers

        public ushort CmndRegValue
        {
            get { return mCmndRegValue; }
            private set
            {
                if (value == mCmndRegValue)
                    return;

                mCmndRegValue = value;
                OnPropertyChanged("CmndRegValue");
            }
        }

        public ushort PosRecRegValue
        {
            get { return mPosRecRegValue; }
            private set
            {
                if (value == mPosRecRegValue)
                    return;

                mPosRecRegValue = value;
                OnPropertyChanged("PosRecRegValue");
            }
        }

        public ushort DataRegValue
        {
            get { return mDataRegValue; }
            private set
            {
                if (value == mDataRegValue)
                    return;

                mDataRegValue = value;
                OnPropertyChanged("DataRegValue");
            }
        }

        #endregion

        #region Summary data

        public ushort CmndRegAddress { get { return mArchive.CommandRegister; } }

        public ushort RecordRegistersCount { get { return mArchive.RecordRegistersCount; } }

        public ushort ArchiveDeepness { get { return mArchive.RecordsCount; } }

        #endregion

        #region Archive records

        [UsedImplicitly]
        public DataTable ArchiveRecords { get; private set; }

        #endregion

        #endregion

        #region Commands

        public ICommand ReadRecordsCommand { get; private set; }

        public ICommand ReadRegistersCommand { get; private set; }

        public ICommand EraseArchiveCommand { get; private set; }

        #endregion

        #endregion

        #region Methods

        private async void ReadRecords(object[] objects)
        {
            try
            {
                using (new ViewModelBlocker(this))
                {
                    ArchiveRecords.Clear();
                    var regs = await Task.Factory.StartNew(() => mManager.ReadRecords(RecordPosition, RecordsCount));

                    if (regs == null)
                        return;

                    var decodeResult = await Task.Factory.StartNew(() => mDecoder.Decode(regs));
                    ArchiveRecords.Merge(decodeResult.Data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ReadRegisters(object[] objects)
        {
            try
            {
                using (new ViewModelBlocker(this))
                {
                    var regs = await Task.Factory.StartNew(() => mManager.Read(mArchive.CommandRegister, 3));
                    CmndRegValue = regs[0];
                    PosRecRegValue = regs[1];
                    DataRegValue = regs[2];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void EraseArchive(object[] obj)
        {
            try
            {
                using (new ViewModelBlocker(this))
                {
                    var reg = new[] { ArchiveType.EraseOpCodeCommand };
                    await Task.Factory.StartNew(() => mManager.Write(mArchive.CommandRegister, reg));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
