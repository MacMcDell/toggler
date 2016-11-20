using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toggler.Tests
{
    internal class ToggleTestData
    {
        //    <Start>11/19/2016 8:15:01 PM</Start>
        //<End>11/19/2016 8:17:01 PM</End>

        public List<Toggle> TestData()
        {
            var t = new List<Toggle>()
            { new Toggle()
                {
                Name = "first",
                IsEnabled = true,
                StartTime = new DateTime(2016,11,19),
                EndTime = new DateTime(2016,11,19)    ,
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
