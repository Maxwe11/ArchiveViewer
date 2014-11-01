namespace ArchiveViewer.Common.Services
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IModbusMasterService
    {
        ushort[] ReadHoldingRegs(byte slaveId, ushort address, ushort regsCount);

        Task<ushort[]> ReadHoldingRegsAsync(byte slaveId, ushort address, ushort regsCount);

        Task<ushort[]> ReadHoldingRegsAsync(byte slaveId, ushort address, ushort regsCount, CancellationToken token);

        void WriteRegs(byte slaveId, ushort address, ushort[] regs);

        Task WriteRegsAsync(byte slaveId, ushort address, ushort[] regs);

        Task WriteRegsAsync(byte slaveId, ushort address, ushort[] regs, CancellationToken token);
    }
}
