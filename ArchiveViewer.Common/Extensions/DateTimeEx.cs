namespace ArchiveViewer.Common.Extensions
{
    using System;

    public static class DateTimeEx
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static int ToUnixTime(this DateTime dt)
        {
            if (dt < UnixEpoch)
                throw new ArgumentException("DateTime should be greater or equal to " + UnixEpoch, "dt");

            return (int)(dt - UnixEpoch).TotalSeconds;
        }

        public static DateTime ToUnixDateTime(this int unixTime)
        {
            if (unixTime < 0)
                throw new ArgumentException("Should be greater than zero", "unixTime");

            var dt = UnixEpoch;
            return dt.AddSeconds(unixTime);
        }
    }
}
