namespace ArchiveViewer.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;
    using Visitors;

    [DataContract]
    public class Integer8 : Parameter
    {
        #region Constructors

        public Integer8(string name, string converterName = null, int bitsCount = 8)
            : this(name, name, converterName, bitsCount)
        {
        }

        public Integer8(string name, string displayName, string converterName, int bitsCount = 8)
            : base(name, displayName, bitsCount, 8, converterName)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(sbyte); } }

        public sbyte TypedValue { get; set; }

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
