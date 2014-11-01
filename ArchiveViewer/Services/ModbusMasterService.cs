namespace ArchiveViewer.Services
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Extensions;
    using Common.Services;
    using Modbus.Device;

    internal class ModbusMasterService : IModbusMasterService
    {
        #region Fields
        
        private const int MaxHoldingRegsReadCount = 121;

        private const int MaxRegsWriteCount = 123;

        private readonly IModbusMaster mMaster;

        #endregion

        #region Constructor

        internal ModbusMasterService(IModbusMaster master)
        {
            master.CheckNull("master");

            mMaster = master;
        }

        #endregion

        #region IModbusMasterService

        ushort[] IModbusMasterService.ReadHoldingRegs(byte slaveId, ushort address, ushort regsCount)
        {
            var startAddress = address;
            var result = new ushort[regsCount];
            int registersToRead = regsCount;
            ushort[] registers;

            while (registersToRead >= MaxHoldingRegsReadCount)
            {
                registers = mMaster.ReadHoldingRegisters(slaveId, address, MaxHoldingRegsReadCount);
                registers.CopyTo(result, address - startAddress);
                
                registersToRead -= MaxHoldingRegsReadCount;
                address += MaxHoldingRegsReadCount;
            }

            if (registersToRead > 0)
            {
                registers = mMaster.ReadHoldingRegisters(slaveId, address, (ushort)registersToRead);
                registers.CopyTo(result, address - startAddress);
            }

            return result;
        }

        Task<ushort[]> IModbusMasterService.ReadHoldingRegsAsync(byte slaveId, ushort address, ushort regsCount)
        {
            var i = this as IModbusMasterService;
            return Task.Factory.StartNew(() => i.ReadHoldingRegs(slaveId, address, regsCount));
        }

        Task<ushort[]> IModbusMasterService.ReadHoldingRegsAsync(byte slaveId, ushort address, ushort regsCount, CancellationToken token)
        {
            var i = this as IModbusMasterService;
            return Task.Factory.StartNew(() => i.ReadHoldingRegs(slaveId, address, regsCount), token);
        }

        void IModbusMasterService.WriteRegs(byte slaveId, ushort address, ushort[] regs)
        {
            regs.CheckNull("regs");

            int offSet = 0;

            while ((regs.Length - offSet) >= MaxRegsWriteCount)
            {
                var packet = regs.Skip(offSet).Take(MaxRegsWriteCount).ToArray();
                mMaster.WriteMultipleRegisters(slaveId, address, packet);
                offSet += MaxRegsWriteCount;
                address += MaxRegsWriteCount;
            }

            if (regs.Length > offSet)
            {
                var packet = regs.Skip(offSet).Take(regs.Length - offSet).ToArray();
                mMaster.WriteMultipleRegisters(slaveId, address, packet);
            }
        }

        Task IModbusMasterService.WriteRegsAsync(byte slaveId, ushort address, ushort[] regs)
        {
            regs.CheckNull("regs");

            var i = this as IModbusMasterService;
            return Task.Factory.StartNew(() => i.WriteRegs(slaveId, address, regs));
        }

        Task IModbusMasterService.WriteRegsAsync(byte slaveId, ushort address, ushort[] regs, CancellationToken token)
        {
            regs.CheckNull("regs");

            var i = this as IModbusMasterService;
            return Task.Factory.StartNew(() => i.WriteRegs(slaveId, address, regs), token);
        }

        #endregion
    }
}
