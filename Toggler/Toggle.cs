using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Toggler
{
    [Serializable]
    [XmlRoot("Toggle")]
    public class Toggle
    {
     /// <summary>
        /// The name of the faeture toggle
        /// </summary>
        [XmlElement("Name")]
        public string Name { get; set; }
        /// <summary>
        /// When the feature ends
        /// </summary>
       [XmlElement("End")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// When the feature starts
        /// </summary>
        [XmlElement("Start")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// If the feature is enabled
        /// </summary>
        [XmlElement("IsEnabled")]
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The name of the toggle this one depends on
        /// </summary>
        [XmlElement("DependsOn")]
        public string DependsOn { get; set; }

        /// <summary>
        /// The environment the toggle should be used in (dev, staging, prod)
        /// </summary>
        [XmlElement("Environment")]
        public string Environment { get; set; }



       
    }
}
