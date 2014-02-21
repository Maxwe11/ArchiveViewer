namespace GroundControl.Common.Mapping.Parameters
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [DataContract]
    public class ParametersCollection
    {
        public ParametersCollection(IList<Parameter> parameters)
        {
            Parameters = new Collection<Parameter>(parameters);
        }

        public ParametersCollection(byte id, IList<Parameter> parameters)
        {
            CollectionId = id;
            Parameters = new Collection<Parameter>(parameters);
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 0)]
        public byte? CollectionId { get; private set; }

        [DataMember(IsRequired = true, Order = 1)]
        public Collection<Parameter> Parameters { get; private set; }
    }
}
