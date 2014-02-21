namespace GroundControl.Common.Decoders.Archives
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum ArchiveDecoderType
    {
        [EnumMember]
        Simple,
        [EnumMember]
        Complex,
        [EnumMember]
        CustomSimple
    };
}
