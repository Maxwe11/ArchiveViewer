namespace Temp
{
    using System.Runtime.Serialization;
    using System.Xml;

    using GroundControl.Common.Decoders.Archives;
    using GroundControl.Common.Mapping.Parameters;
    using GroundControl.Common.Models.Archives;

    class Program
    {
        static void Main(string[] args)
        {
            var c = new ParametersKeyedCollection();
            c.Add(new ParametersCollection(new Parameter[] { new Integer8("EventId"), new Integer32("EventData") }));
            var archive = new ArchiveType(1, "Архів подій", 1, 3000, 8, ArchiveDecoderType.CustomSimple, c);
            

            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create("D:/test_3.xml", settings))
            {
                var ds = new DataContractSerializer(typeof(ArchiveType));
                ds.WriteObject(writer, archive);
            }
        }
    }
}
