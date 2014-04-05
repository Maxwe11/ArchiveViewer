namespace GroundControl.Common.Mapping.Visitors
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    using GroundControl.Common.Extensions;
    using GroundControl.Common.Mapping.Parameters;

    public class ParametersReaderVisitor : IParameterVisitor
    {
        #region Fields

        #region Constants

        private const int ByteBitsCount = 8;

        private const int WordBitsCount = 16;

        private const int DWordBitsCount = 32;

        private const int QWordBitsCount = 64;

        #endregion

        private readonly BitArray mBitArray;

        private int mBitsRead;

        #endregion

        #region Constructors

        public ParametersReaderVisitor(byte[] bytes)
        {
            mBitArray = new BitArray(bytes);
        }

        public ParametersReaderVisitor(ushort[] regs)
        {
            var bytes = new byte[regs.Length * sizeof(ushort)];
            Buffer.BlockCopy(regs, 0, bytes, 0, bytes.Length);
            mBitArray = new BitArray(bytes);
        }

        #endregion

        #region Properties

        public int BitsRead { get { return mBitsRead; } }

        #endregion

        #region IPrimitiveVisitor

        public void Visit(Integer8 p)
        {
            p.TypedValue = ReadCustomInt8(p.BitsCount);
        }

        public void Visit(Integer16 p)
        {
            p.TypedValue = ReadCustomeInt16(p.BitsCount);
        }

        public void Visit(Integer32 p)
        {
            p.TypedValue = ReadCustomeInt32(p.BitsCount);
        }

//        public void Visit(Int64 p)
//        {
//            p.TypedValue = unchecked((long)ReadCustomeUInt64(p.BitsCount));
//        }

        public void Visit(UnsignedInteger8 p)
        {
            p.TypedValue = ReadCustomUInt8(p.BitsCount);
        }

        public void Visit(UnsignedInteger16 p)
        {
            p.TypedValue = ReadCustomeUInt16(p.BitsCount);
        }

        public void Visit(UnsignedInteger32 p)
        {
            p.TypedValue = ReadCustomeUInt32(p.BitsCount);
        }

//        public void Visit(UInt64 p)
//        {
//            p.TypedValue = ReadCustomeUInt64(p.BitsCount);
//        }

        public void Visit(Float p)
        {
            p.TypedValue = ReadFloat();
        }

        public void Visit(Parameters.Double p)
        {
            p.TypedValue = ReadDouble();
        }

//        public void Visit(UnixTime p)
//        {
//            p.TypedValue = ReadDateTime();
//        }

        #endregion

        #region Own methods

        public bool Read(IEnumerable<Parameter> parameters)
        {
            parameters.CheckNull("parameters");

            if (mBitsRead == mBitArray.Length)
                return false;

            foreach (var parameter in parameters)
                parameter.Apply(this);

            return true;
        }

        private byte GetByteFromArray(int offset = 0)
        {
            byte result = 0;

            for (int i = 0; i < ByteBitsCount; ++i)
            {
                if (mBitArray.Get(mBitsRead + offset + i))
                    result |= Convert.ToByte(1 << i);
            }

            return result;
        }

        private byte ReadCustomUInt8(int bitsCount)
        {
            EnsureBitsCount(bitsCount, ByteBitsCount);

            byte result = GetByteFromArray();

            if (bitsCount == ByteBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            byte mask = (byte)((1 << bitsCount) - 1);

            mBitsRead += bitsCount;

            return (byte)(result & mask);
        }

        private sbyte ReadCustomInt8(int bitsCount)
        {
            EnsureBitsCount(bitsCount, ByteBitsCount);

            sbyte result = unchecked((sbyte)GetByteFromArray());

            if (bitsCount == ByteBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            sbyte mask = (sbyte)((1 << bitsCount) - 1);
            sbyte signMask = (sbyte)(1 << (bitsCount - 1));

            if ((result & signMask) != 0)
                result |= (sbyte)~mask;

            mBitsRead += bitsCount;

            return (sbyte)(result & mask);
        }

        private ushort ReadCustomeUInt16(int bitsCount)
        {
            EnsureBitsCount(bitsCount, WordBitsCount);

            byte byte1, byte2 = 0;
            
            byte1 = GetByteFromArray();
            if (bitsCount > ByteBitsCount)
                byte2 = GetByteFromArray(ByteBitsCount);
            
            byte[] bytes = { byte1, byte2 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            ushort result = BitConverter.ToUInt16(bytes, 0);

            if (bitsCount == WordBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            ushort mask = (ushort)((1 << bitsCount) - 1);

            result &= mask;

            mBitsRead += bitsCount;

            return result;
        }

        private short ReadCustomeInt16(int bitsCount)
        {
            EnsureBitsCount(bitsCount, WordBitsCount);

            byte byte1, byte2 = 0;

            byte1 = GetByteFromArray();
            if (bitsCount > ByteBitsCount)
                byte2 = GetByteFromArray(ByteBitsCount);

            byte[] bytes = { byte1, byte2 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            short result = BitConverter.ToInt16(bytes, 0);

            if (bitsCount == WordBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            short mask = (short)((1 << bitsCount) - 1);
            short signMask = (short)(1 << (bitsCount - 1));

            result &= mask;

            if ((result & signMask) != 0)
                result |= (short)~mask;

            mBitsRead += bitsCount;

            return result;
        }

        private uint ReadCustomeUInt32(int bitsCount)
        {
            EnsureBitsCount(bitsCount, DWordBitsCount);
            byte byte1, byte2 = 0, byte3 = 0, byte4 = 0;

            byte1 = GetByteFromArray();

            if (bitsCount > ByteBitsCount)
            {
                byte2 = GetByteFromArray(ByteBitsCount);

                if (bitsCount > WordBitsCount)
                {
                    byte3 = GetByteFromArray(WordBitsCount);
                    const int Bits24 = ByteBitsCount + WordBitsCount;
                    
                    if (bitsCount > Bits24)
                        byte4 = GetByteFromArray(Bits24);
                }
            }

            byte[] bytes = { byte1, byte2, byte3, byte4 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            uint result = BitConverter.ToUInt32(bytes, 0);

            if (bitsCount == DWordBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            uint mask = (uint)((1 << bitsCount) - 1);

            result &= mask;

            mBitsRead += bitsCount;

            return result;
        }

        private int ReadCustomeInt32(int bitsCount)
        {
            EnsureBitsCount(bitsCount, DWordBitsCount);
            byte byte1, byte2 = 0, byte3 = 0, byte4 = 0;

            byte1 = GetByteFromArray();

            if (bitsCount > ByteBitsCount)
            {
                byte2 = GetByteFromArray(ByteBitsCount);

                if (bitsCount > WordBitsCount)
                {
                    byte3 = GetByteFromArray(WordBitsCount);
                    const int Bits24 = ByteBitsCount + WordBitsCount;

                    if (bitsCount > Bits24)
                        byte4 = GetByteFromArray(Bits24);
                }
            }

            byte[] bytes = { byte1, byte2, byte3, byte4 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            int result = BitConverter.ToInt32(bytes, 0);

            if (bitsCount == DWordBitsCount)
            {
                mBitsRead += bitsCount;
                return result;
            }

            int mask = (1 << bitsCount) - 1;
            int signMask = 1 << (bitsCount - 1);

            result &= mask;

            if ((result & signMask) != 0)
                result |= ~mask;

            mBitsRead += bitsCount;

            return result;
        }

//        private ulong ReadCustomeUInt64(int bitsCount)
//        {
//            EnsureBitsCount(bitsCount, QWordBitsCount);
//
//            byte byte1 = GetByteFromArray();
//            byte byte2 = GetByteFromArray(ByteBitsCount);
//            byte byte3 = GetByteFromArray(WordBitsCount);
//            byte byte4 = GetByteFromArray(WordBitsCount + ByteBitsCount);
//            byte byte5 = GetByteFromArray(DWordBitsCount);
//            byte byte6 = GetByteFromArray(DWordBitsCount + ByteBitsCount);
//            byte byte7 = GetByteFromArray(DWordBitsCount + WordBitsCount);
//            byte byte8 = GetByteFromArray(DWordBitsCount + WordBitsCount + ByteBitsCount);
//            byte[] bytes = { byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8 };
//
//            if (!BitConverter.IsLittleEndian)
//                Array.Reverse(bytes);
//
//            ulong result = BitConverter.ToUInt64(bytes, 0);
//
//            if (bitsCount == QWordBitsCount)
//                return result;
//
//            ulong mask = ((1UL << bitsCount) - 1);
//
//            result &= mask;
//
//            mBitsRead += bitsCount;
//
//            return result;
//        }

        private float ReadFloat()
        {
            byte byte1 = GetByteFromArray();
            byte byte2 = GetByteFromArray(ByteBitsCount);
            byte byte3 = GetByteFromArray(WordBitsCount);
            byte byte4 = GetByteFromArray(ByteBitsCount + WordBitsCount);
            byte[] bytes = { byte1, byte2, byte3, byte4 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            float result = BitConverter.ToSingle(bytes, 0);

            mBitsRead += DWordBitsCount;

            return result;
        }

        private double ReadDouble()
        {
            byte byte1 = GetByteFromArray();
            byte byte2 = GetByteFromArray(ByteBitsCount);
            byte byte3 = GetByteFromArray(WordBitsCount);
            byte byte4 = GetByteFromArray(WordBitsCount + ByteBitsCount);
            byte byte5 = GetByteFromArray(DWordBitsCount);
            byte byte6 = GetByteFromArray(DWordBitsCount + ByteBitsCount);
            byte byte7 = GetByteFromArray(DWordBitsCount + WordBitsCount);
            byte byte8 = GetByteFromArray(DWordBitsCount + WordBitsCount + ByteBitsCount);
            byte[] bytes = { byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8 };

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            double result = BitConverter.ToDouble(bytes, 0);

            mBitsRead += QWordBitsCount;

            return result;
        }

//        private DateTime ReadDateTime()
//        {
//            int unixTime = unchecked((int)ReadCustomeUInt32(DWordBitsCount));
//            return unixTime.ToUnixDateTime();
//        }

        /*
         * EnsureBitsCount called only in debug because bitsCount have already
         * been ensured when primitive created
         */
        [Conditional("DEBUG")]
        private static void EnsureBitsCount(int bitsCount, int maxBitsCount)
        {
            if (bitsCount <= 0 || bitsCount > maxBitsCount)
            {
                var message = "bitsCount should be in inclusive range [0, " + maxBitsCount + "]";
                throw new ArgumentException(message);
            }

        }

        #endregion
    }
}
