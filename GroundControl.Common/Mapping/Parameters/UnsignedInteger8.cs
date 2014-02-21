namespace GroundControl.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;

    using GroundControl.Common.Mapping.Visitors;

    [DataContract]
    public class UnsignedInteger8 : Parameter
    {
        #region Constructors

        public UnsignedInteger8(string name, int bitsCount = 8)
            : this(name, name, bitsCount)
        {
        }

        public UnsignedInteger8(string name, string displayName, int bitsCount = 8)
            : base(name, displayName, bitsCount, 8)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(byte); } }

        public byte TypedValue { get; set; }

        public override object Value { get { return TypedValue; } }

        #endregion

        #region Methods

        public override void Apply(IParameterVisitor visitor)
        {
            visitor.Visit(this);
        }

        #endregion
    }
}
