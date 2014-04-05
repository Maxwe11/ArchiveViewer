namespace GroundControl.Common.Decoders.Archives
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum ArchiveDecoderType
    {
        [EnumMember]
        Complex,
        [EnumMember]
        CustomSimple
    };
}
