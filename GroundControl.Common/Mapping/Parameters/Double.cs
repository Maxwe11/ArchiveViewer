namespace GroundControl.Common.Mapping.Parameters
{
    using System;
    using System.Runtime.Serialization;

    using GroundControl.Common.Mapping.Visitors;

    [DataContract]
    public class Double : Parameter
    {
        #region Constructors

        public Double(string name)
            : this(name, name)
        {
        }

        public Double(string name, string displayName)
            : base(name, displayName, 64, 64)
        {
        }

        #endregion

        #region Properties

        public override Type Type { get { return typeof(double); } }

        public double TypedValue { get; set; }

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
