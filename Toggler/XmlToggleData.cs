using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Toggler
{
  internal  class XmlToggleData : IToggleData
    {
       
      
        public IEnumerable<Toggle> Data()
        {
            return DataSource();

           
        }

        public bool Save(Toggle toggle)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "toggler.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            //  XmlNode node = document.DocumentElement.
            //create node and add value
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Toggle", null);


            XmlNode nodeName = doc.CreateElement("Name");
            nodeName.InnerText = toggle.Name;

            XmlNode nodeEnabled = doc.CreateElement("IsEnabled");
            nodeEnabled.InnerText = toggle.IsEnabled.ToString();

            node.AppendChild(nodeName);
            node.AppendChild(nodeEnabled);
            doc.DocumentElement.AppendChild(node);
            
            doc.Save(path);
            return true; 

        }

        private IEnumerable<Toggle> DataSource()
        {
            Init();
            var doc = AppDomain.CurrentDomain.BaseDirectory + "toggler.xml";
            using (var reader = new StreamReader(doc))
            {
                return reader.ReadToEnd().ToToggle();
            }


        }
        static void Init()
        {
            if (!File.Exists("toggler.xml"))
            {
                var t = new Toggle()
                {
                    Name = "FirstToggle",
                    DependsOn = null,
                    EndTime = DateTime.Now.AddMinutes(2),
                    StartTime = DateTime.Now,
                    IsEnabled = true
                };
                using (XmlWriter writer = XmlWriter.Create(AppDomain.CurrentDomain.BaseDirectory + "toggler.xml"))
                {
                    writer.WriteStartElement("Toggles");

                    writer.WriteStartElement("Toggle");
                    writer.WriteElementString("Environment", "Production");
                    writer.WriteElementString("Name", t.Name);
                    writer.WriteElementString("IsEnabled", t.IsEnabled.ToString());
                    writer.WriteElementString("DependsOn", t.DependsOn);
                    writer.WriteElementString("Start", t.StartTime.ToString());
                    writer.WriteElementString("End", t.EndTime.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

            }

        }
    }
}