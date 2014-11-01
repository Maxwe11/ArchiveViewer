namespace ArchiveViewer.Common.Mapping.Visitors
{
    using Parameters;

    public interface IParameterVisitor
    {
        void Visit(Integer8 p);
        void Visit(Integer16 p);
        void Visit(Integer32 p);
//        void Visit(Int64 p);
        void Visit(UnsignedInteger8 p);
        void Visit(UnsignedInteger16 p);
        void Visit(UnsignedInteger32 p);
//        void Visit(UInt64 p);
        void Visit(Float p);
        void Visit(Double p);
//        void Visit(UnixTime p);
    }
}
