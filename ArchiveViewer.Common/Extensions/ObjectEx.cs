namespace ArchiveViewer.Common.Extensions
{
    using System;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using Properties;

    public static class ObjectEx
    {
        [Conditional("DEBUG")]
        public static void CheckNull(this object obj, [InvokerParameterName] string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        [Conditional("DEBUG")]
        public static void CheckNull(this string str, [InvokerParameterName] string name)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException(name);
        }

        public static string MemberName<TClass, TMember>(this TClass obj, Expression<Func<TClass, TMember>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
                return member.Member.Name;

            throw new ArgumentException("Expression is not a member access", "expression");
        }
    }
}
