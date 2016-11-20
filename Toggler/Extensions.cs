using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Xml;

namespace Toggler
{
   public static class Extensions
    {
        /// <summary>
        /// convert string to xml and parse for toggle nodes.
        /// </summary>
        /// <param name="input">the xml string</param>
        /// <param name="environment">the environment of toggles you want to return or work with.</param>
        /// <returns></returns>
        public static IEnumerable<Toggle> ToToggle(this string input, string environment = null)
        {                                
            XDocument d = XDocument.Parse(input);
           var result = from x in d.Descendants("Toggle")
                       select new Toggle()
            {
                Name =  x.Element("Name").Value   ,
                Environment =  x.Element("Environment").Value   ,
                EndTime =  Convert.ToDateTime(x.Element("End").Value)    ,
                StartTime =  Convert.ToDateTime(x.Element("Start").Value)    ,
                DependsOn =  (x.Element("DependsOn").Value)    ,
                IsEnabled =  Convert.ToBoolean(x.Element("IsEnabled").Value)    
            };
            return !string.IsNullOrEmpty(environment) ? result.Where(x=>x.Environment.IndexOf(environment,StringComparison.CurrentCultureIgnoreCase) > -1) : result;
        }

        /// <summary>
        /// Checks against the string to determine if toggle exists and is currently active.
        /// if no toggle is found return is true
        /// </summary>
        /// <param name="input">The name of the toggle to look for</param>
        /// <returns></returns>
        public static bool FeatureIsEnabled(this string input,string environment = null, ToggleRepository repository = null)
        {
            var repo = repository ?? new ToggleRepository();

            bool stat = true;

            while (stat)
            {
                
                var toggle = repo.GetToggle(input);
                if(toggle == null)
                return true; 

                stat = toggle != null && toggle.IsEnabled;
                if (stat)
                {
                    var now = DateTime.Now;
                    if (toggle.StartTime != null)
                    stat = now >= toggle.StartTime.Value; 
                    
                    if (toggle.EndTime != null)
                   stat = now <= toggle.EndTime.Value;

                    if (toggle.EndTime.HasValue && toggle.StartTime.HasValue)
                        stat = now > toggle.StartTime.Value && now < toggle.EndTime.Value;

                    return stat; 
                }
            }
            return stat; 


        }
    }
}
