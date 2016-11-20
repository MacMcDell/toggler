using System.Linq;
using NUnit.Framework;


namespace Toggler.Tests
{
    [TestFixture]
    public class XmlConversionTests
    {
        private string setup =
    "<Toggles>\r\n  <Toggle>\r\n    <Environment>Production</Environment>\r\n    <Name>FirstToggle</Name>\r\n    <IsEnabled>True</IsEnabled>\r\n    <DependsOn />\r\n    <Start>11/19/2016 2:33:19 PM</Start>\r\n    <End>11/19/2016 2:35:19 PM</End>\r\n  </Toggle>\r\n  <Toggle>\r\n    <Environment>Dev</Environment>\r\n    <Name>FirstToggle</Name>\r\n    <IsEnabled>True</IsEnabled>\r\n    <DependsOn />\r\n    <Start>11/19/2016 2:33:19 PM</Start>\r\n    <End>11/19/2016 2:35:19 PM</End>\r\n  </Toggle>\r\n</Toggles>";


        [Test]
        public void ConvertXMLtoToggle()
        {
           var result = setup.ToToggle(); 
            Assert.AreEqual(2,result.Count());
        }

        [Test]
        public void CanConvertMultipleToggles()
        {
            var result = setup.ToToggle(); 
            Assert.AreEqual(2,result.Count());
        }

        [Test]
        public void ReturnSingleProductionResult()
        {
            var result = setup.ToToggle("Production"); 
            Assert.AreEqual("Production", result.First().Environment);
            Assert.AreEqual(1,result.Count());
        }
    }
}
