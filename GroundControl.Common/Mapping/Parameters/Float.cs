namespace GroundControl.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;

    using GroundControl.Common.Mapping.Visitors;

    [DataContract]
    public class Float : Parameter
    {
        #region Constructors

        public Float(string name)
            : this(name, name)
        {
        }

        public Float(string name, string displayName)
            : base(name, displayName, 32, 32)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(float); } }

        public float TypedValue { get; set; }

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
