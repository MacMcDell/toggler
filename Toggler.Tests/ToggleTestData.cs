using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toggler.Tests
{
    internal class ToggleTestData
    {
      public List<Toggle> TestData()
        {
            var t = new List<Toggle>()
            { new Toggle()
                {
                Name = "first",
                IsEnabled = true,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(1) 
                
                },
                new Toggle()
                {
                Name = "firstDependsOnSecond",
                IsEnabled = true,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(1)    ,
                DependsOn = "second"
                },
             new Toggle()
             {
                 Name = "second",
                 IsEnabled = false,
                 StartTime = new DateTime(2016,11,19),
                 EndTime = new DateTime(2016,11,19)
             },
            new Toggle()
            {
                Name = "third",
                IsEnabled = true,
                StartTime = new DateTime(2016,11,19),
                EndTime = new DateTime(2016,11,19)
            } };
            return t;
        }
    }
}
