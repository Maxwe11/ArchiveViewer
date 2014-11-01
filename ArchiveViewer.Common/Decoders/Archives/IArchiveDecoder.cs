namespace ArchiveViewer.Common.Decoders.Archives
{
    using System.Data;

    internal interface IArchiveDecoder
    {
        ArchiveDecodeResult Decode(byte[] data);

        ArchiveDecodeResult Decode(ushort[] data);

        DataTable Template { get; }
    }
}
