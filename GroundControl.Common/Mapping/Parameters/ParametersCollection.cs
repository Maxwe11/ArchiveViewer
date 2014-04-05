namespace GroundControl.Common.Mapping.Parameters
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;

    [DataContract]
    public class ParametersCollection : IEnumerable<Parameter>
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

        #region IEnumerable

        public IEnumerator<Parameter> GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public int Count { get { return Parameters.Count; } }

        public Parameter this[int index] { get { return Parameters[index]; } }
    }
}
