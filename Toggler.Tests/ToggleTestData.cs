using System;
using System.Collections.Generic;


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
                Name = "SecondDependsOnThird",
                IsEnabled = true,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(1)    ,
                DependsOn = "ThirdDependsOnFourth"
                },
             new Toggle()
             {
                 Name = "ThirdDependsOnFourth",
                 IsEnabled = true,
                 StartTime = DateTime.Now.AddMinutes(-1),
                 EndTime = DateTime.Now.AddMinutes(2),
                 DependsOn = "Fourth"
             },
                 new Toggle()
             {
                 Name = "Fourth",
                 IsEnabled = true,
                 EndTime = new DateTime(2016,11,18)
             },




            new Toggle()
            {
                Name = "DateExpired",
                IsEnabled = true,
                StartTime = new DateTime(2016,11,18,0,0,0),
                EndTime = new DateTime(2016,11,19,23,59,0,0)
            },    new Toggle()
            {
                Name = "NoEndDate",
                IsEnabled = true,
                StartTime = new DateTime(2016,11,18,0,0,0)

            }
            ,    new Toggle()
            {
                Name = "NoStartDateEndExpired",
                IsEnabled = true,
                EndTime = new DateTime(2016,11,18,0,0,0)

            }
            , new Toggle() {
                Name = "NoStartDateEndNotExpired",
                IsEnabled = true,
                EndTime = DateTime.Now.AddMinutes(2)

            }, };
            return t;
        }
    }
}
