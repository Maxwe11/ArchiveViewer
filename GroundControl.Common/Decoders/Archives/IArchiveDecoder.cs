namespace GroundControl.Common.Decoders.Archives
{
    internal interface IArchiveDecoder
    {
        ArchiveDecodeResult Decode(byte[] data);

        ArchiveDecodeResult Decode(ushort[] data);
    }
}
