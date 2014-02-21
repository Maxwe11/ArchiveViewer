namespace GroundControl.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;

    using GroundControl.Common.Mapping.Visitors;

    [DataContract]
    public class UnsignedInteger32 : Parameter
    {
        #region Constructors

        public UnsignedInteger32(string name, int bitsCount = 32)
            : this(name, name, bitsCount)
        {
        }

        public UnsignedInteger32(string name, string displayName, int bitsCount = 32)
            : base(name, displayName, bitsCount, 32)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(uint); } }

        public uint TypedValue { get; set; }

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
