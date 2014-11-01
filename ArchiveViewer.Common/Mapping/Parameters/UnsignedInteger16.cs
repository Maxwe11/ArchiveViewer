namespace ArchiveViewer.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;
    using Visitors;

    [DataContract]
    public class UnsignedInteger16 : Parameter
    {
        #region Constructors

        public UnsignedInteger16(string name, int bitsCount = 16)
            : this(name, name, bitsCount)
        {
        }

        public UnsignedInteger16(string name, string displayName, int bitsCount = 16)
            : base(name, displayName, bitsCount, 16)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(ushort); } }

        public ushort TypedValue { get; set; }

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
