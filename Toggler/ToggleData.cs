using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Toggler
{
  internal  class ToggleData : IToggleData
    {
       
      
        public IEnumerable<Toggle> Data()
        {
            return XmlToggleData();

           
        }

        private IEnumerable<Toggle> XmlToggleData()
        {
            Init();
            var path = AppDomain.CurrentDomain.BaseDirectory + "toggler.xml";
            using (var reader = new StreamReader(path))
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