using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toggler;

namespace runner
{
    class Program
    {
        
        static void Main(string[] args)
        {
          

            if ("FirstToggle".FeatureIsEnabled())
            {
                Console.WriteLine("exists");
            }
            else
            {
                Console.WriteLine("cant find it");
            }
            var repo = new ToggleRepository();
foreach (var environmentToggle in repo.GetToggles())
            {
               Console.WriteLine(environmentToggle.Name);
            }
         

           
            Console.ReadLine();
        }
    }
}
