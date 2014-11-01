namespace Temp
{
    using System.Runtime.Serialization;
    using System.Xml;
    using ArchiveViewer.Common.Decoders.Archives;
    using ArchiveViewer.Common.Mapping.Converters;
    using ArchiveViewer.Common.Mapping.Parameters;
    using ArchiveViewer.Common.Models.Archives;

    class Program
    {
        static void Main(string[] args)
        {
            //CreateConverters();
            //CreateEventsArchive();
            CreatePosArchive();
        }

        private static void CreateConverters()
        {
            var c = new ConvertersCollection();

            var conv = new ToStringConverter<int>("SatRtcSourceConverter");
            conv.Collection.Add(1, "бит 0 - машина состяний RTC в случае сбоя");
            conv.Collection.Add(2, "бит 1 - GPS модуль");
            conv.Collection.Add(4, "бит 2 - modbus (радиолиния)");
            c.Add(conv);

            var bits = new BitsToStringConverter("SatErrorsConverter");
            bits.Collection.Add(0, "Неисправность часов реального времени (RTC)");
            bits.Collection.Add(1, "Неисправность внутреннего АЦП");
            bits.Collection.Add(2, "Неисправность SPI1(Внешняя флеш AT45 т.е архивы спутника)");
            bits.Collection.Add(3, "Неисправность SPI2(Внешнее АЦП ADS1248)");
            bits.Collection.Add(4, "Неисправность USART1(Мастер)");
            bits.Collection.Add(5, "Неисправность USART3(Подчинённый)");
            bits.Collection.Add(6, "Неисправность UART5(GPS-модуль)");
            bits.Collection.Add(7, "Неисправность шины  I2C (цифровые магнитометр и гироскоп)");
            bits.Collection.Add(8, "Неисправность таймера управления катушками");
            bits.Collection.Add(9, "Неисправна микросхема АЦП");
            bits.Collection.Add(10, "Неисправна микросхема FLASH");
            bits.Collection.Add(11, "Нет связи с модулем GPS");
            bits.Collection.Add(12, "MAG3110(цифр. маг.).Нет подтверждения окончания измерений ногой");
            bits.Collection.Add(13, "MAG3110.Нет связи по I2C");
            bits.Collection.Add(14, "L3G4200(цифр. гиро).Нет подтверждения окончания измерений ногой");
            bits.Collection.Add(15, "L3G4200.Нет связи по I2C");
            bits.Collection.Add(16, "Нет связи с модулем питания");
            bits.Collection.Add(17, "Нет связи с радиомодулем");
            bits.Collection.Add(18, "Недостоверные данные аналогового магнитометра (выходят за диапазон значений)");
            bits.Collection.Add(19, "Недостоверные данные аналогового гироскопа (выходят за диапазон значений)");
            bits.Collection.Add(20, "Измерения модулем GPS не состоялись (нет приёма сигнала GPS)");
            bits.Collection.Add(21, "Недостоверные данные цифрового магнитометра (выходят за диапазон значений)");
            bits.Collection.Add(22, "Недостоверные данные цифрового гироскопа (выходят за диапазон значений)");
            c.Add(bits);

            var def = new DefaultConverter();
            var unix = new ToUnixTimeConverter();

            var customSimple = new ToStringConverterPairConverter<sbyte>("EventsArchiveConverter");
            customSimple.Collection.Add(new StringConverterPair<sbyte>(-6, "-6: Отключение подачи питания на модуль GSM", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(-2, "-2: Сброс битов ошибок в слове SatErrors", bits.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(-1, "-1: Отключение спутника", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(1, "1: Включение спутника", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(2, "2: Установка битов ошибок в слове SatErrors", bits.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(3, "3: Переключение режимов спутника", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(4, "4: Переключение подрежимов спутника", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(5, "5: Переключение машины состояний ПОС", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(6, "6: Включение подачи питания на модуль GSM", def.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(7, "7: Установка бортового RTC", conv.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(8, "8: Установка бортового RTC", unix.Name));
            customSimple.Collection.Add(new StringConverterPair<sbyte>(9, "9: Установка бортового RTC", unix.Name));

            c.Add(customSimple);

            var ds = new DataContractSerializer(typeof(ConvertersCollection));

            var settings = new XmlWriterSettings { Indent = true };

            using (var w = XmlWriter.Create("D:/test_2.xml", settings))
            {
                ds.WriteObject(w, c);
            }
        }

        private static void CreateEventsArchive()
        {
            var c = new ParametersKeyedCollection();
            c.Add(
                new ParametersCollection(
                    new Parameter[] { new Integer8("EventId", "EventsArchiveConverter"), new Integer32("EventData") }));
            var archive = new ArchiveType(
                id: 1,
                displayName: "Архів подій",
                slaveId: 1,
                cmdRegAdr: 3000,
                recordRegsCount: 8,
                recordsCount: 65406,
                type: ArchiveDecoderType.CustomSimple,
                metadataSize: 11,
                parameters: c);

            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create("D:/test_3.xml", settings))
            {
                var ds = new DataContractSerializer(typeof(ArchiveType));
                ds.WriteObject(writer, archive);
            }
        }

        private static void CreatePosArchive()
        {
            var c = new ParametersKeyedCollection();
            
            var archive = new ArchiveType(
                id: 2,
                displayName: "Архів ПОС",
                slaveId: 1,
                cmdRegAdr: 3009,
                recordRegsCount: 66,
                recordsCount: 31992,
                type: ArchiveDecoderType.Complex,
                metadataSize: 12,
                parameters: c);

            var c1 = new ParametersCollection(0, new Parameter[]
            {
                new Integer32("Foo"), 
                new Integer32("Bar", 24)
            });

            c.Add(c1);

            c1 = new ParametersCollection(1, new Parameter[]
            {
                new Float("Spam")
            });

            c.Add(c1);

            var settings = new XmlWriterSettings { Indent = true };
            using (var writer = XmlWriter.Create("D:/test_3.xml", settings))
            {
                var ds = new DataContractSerializer(typeof(ArchiveType));
                ds.WriteObject(writer, archive);
            }
        }
    }
}
