namespace ArchiveViewer.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;
    using Visitors;

    [DataContract]
    public class Integer16 : Parameter
    {
        #region Constructors

        public Integer16(string name, int bitsCount = 16)
            : this(name, name, bitsCount)
        {
        }

        public Integer16(string name, string displayName, int bitsCount = 16)
            : base(name, displayName, bitsCount, 16)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(short); } }

        public short TypedValue { get; set; }

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
