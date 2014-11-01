namespace ArchiveViewer.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;
    using Visitors;

    [DataContract]
    public class Integer32 : Parameter
    {
        #region Constructors

        public Integer32(string name, int bitsCount = 32)
            : this(name, name, bitsCount)
        {
        }

        public Integer32(string name, string displayName, int bitsCount = 32)
            : base(name, displayName, bitsCount, 32)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(int); } }

        public int TypedValue { get; set; }

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
