namespace ArchiveViewer.Common.Helpers
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Pair<TFirst, TSecond>
    {
        #region Constructors

        public Pair(TFirst key, TSecond value)
        {
            First = key;
            Second = value;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 0)]
        public TFirst First { get; private set; }

        [DataMember(IsRequired = true, Order = 1)]
        public TSecond Second { get; private set; }

        #endregion
    }

    public static class Pair
    {
        public static Pair<TFirst, TSecond> Create<TFirst, TSecond>(TFirst first, TSecond second)
        {
            return new Pair<TFirst, TSecond>(first, second);
        }
    }
}
