namespace ArchiveViewer.Common.Helpers
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MutablePair<TFirst, TSecond>
    {
        #region Constructors

        public MutablePair()
        {
        }

        public MutablePair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        #endregion

        #region Properties

        [DataMember(IsRequired = true, Order = 0)]
        public TFirst First { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public TSecond Second { get; set; }

        #endregion
    }

    public static class MutablePair
    {
        public static MutablePair<TFirst, TSecond> Create<TFirst, TSecond>(TFirst first, TSecond second)
        {
            return new MutablePair<TFirst, TSecond>(first, second);
        }
    }
}
