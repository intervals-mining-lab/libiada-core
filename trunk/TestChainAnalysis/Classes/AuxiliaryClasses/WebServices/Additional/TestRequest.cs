using System.IO;
using System.Xml.Serialization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Types;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.WebServices.Additional
{
    ///<summary>
    /// Класс тестирует класс Request
    ///</summary>
    [TestFixture]
    public class TestRequest
    {
/*        ///<summary>
        /// Тест проверяющий корректность сериализации и десериализации
        ///</summary>
        public void TestSerializationDeSerialization()
        {
            Request Request = new Request();
            Request.Action = ActionType.CreateAlphabetByBlock;

            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, Request);
            MS.Position = 0;
            SF = new SoapFormatter();

            Request ATAfter = (Request) SF.Deserialize(MS);
            Assert.IsTrue(Request.Equals(ATAfter));
        }*/

        ///<summary>
        /// Тест проверяющий корректность Xml сериализации и десериализации
        ///</summary>
        ///
        /*[Test]
        public void TestXmlSerializationDeSerialization()
        {
            Request Request = new Request();
            //Request.Action = ActionType.CreateAlphabetByBlock;

            MemoryStream MS = new MemoryStream();
            XmlSerializer SF = new XmlSerializer(typeof (Request));
            SF.Serialize(MS, Request);
            MS.Position = 0;
            SF = new XmlSerializer(typeof (Request));

            Request ATAfter = (Request) SF.Deserialize(MS);
            Assert.IsTrue(Request.Equals(ATAfter));
        }*/
    }
}