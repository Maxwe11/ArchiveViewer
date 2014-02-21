namespace GroundControl.Common.Extensions
{
    public static class UInt16Ex
    {
        public static byte Low(this ushort value)
        {
            return (byte)(value & 0x00FF);
        }

        public static byte Hi(this ushort value)
        {
            return (byte)((value & 0xFF00) >> 8);
        }

        public static sbyte LowSByte(this ushort value)
        {
            return (sbyte)(value & 0x00FF);
        }

        public static sbyte HiSByte(this ushort value)
        {
            return (sbyte)((value & 0xFF00) >> 8);
        }
    }
}
