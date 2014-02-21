namespace GroundControl.Archives
{
    using System;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Helpers;
    using GroundControl.Common.Models.Archives;
    using GroundControl.Common.Services;

    internal class ArchiveManager
    {
        #region Fields

        private readonly ArchiveType mArchive;

        private readonly ISerialPortService mPort;

        private readonly IModbusMasterService mModbus;

        private const int MaximumRegistersPerRequest = 121;

        #endregion

        #region Constructors

        internal ArchiveManager(ArchiveType archiveType, ISerialPortService port, IModbusMasterService modbus)
        {
            port.CheckNull("port");
            modbus.CheckNull("modbus");

            mArchive = archiveType;
            mPort = port;
            mModbus = modbus;
        }

        #endregion

        #region Methods

        internal ushort[] ReadRecords(ushort recordPosition, int recordsCount)
        {
            Write(mArchive.PositionRegister, new[] { recordPosition });

            if (recordsCount == 0)
                return null;

            var result = new ushort[recordsCount * mArchive.RecordRegistersCount];
            int recordsPerRequest = MaximumRegistersPerRequest / mArchive.RecordRegistersCount;
            int maximumRequestsCount = recordsCount / recordsPerRequest;
            int index = 0;
            int recordsRegsPerRequest = recordsPerRequest * mArchive.RecordRegistersCount;
            var registersToRead = (ushort)(1 + recordsRegsPerRequest);


            for (; index < maximumRequestsCount; ++index)
            {
                var regs = Read(mArchive.PositionRegister, registersToRead);

                Array.Copy(regs, 1, result, index * recordsRegsPerRequest, regs.Length - 1);
                recordsCount -= recordsPerRequest;
            }

            if (recordsCount > 0)
            {
                registersToRead = (ushort)(1 + recordsCount * mArchive.RecordRegistersCount);
                var regs = Read(mArchive.PositionRegister, registersToRead);
                Array.Copy(regs, 1, result, index * recordsRegsPerRequest, regs.Length - 1);
            }

            return result;
        }

        internal ushort[] Read(ushort address, ushort regsToRead)
        {
            using (new SerialPortBlocker(mPort))
                return mModbus.ReadHoldingRegs(mArchive.SlaveId, address, regsToRead);
        }

        internal void Write(ushort address, ushort[] regs)
        {
            regs.CheckNull("regs");

            using (new SerialPortBlocker(mPort))
                mModbus.WriteRegs(mArchive.SlaveId, address, regs);
        }

        #endregion
    }
}
