﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Toggler
{
    public class ToggleRepository : IToggleRepository
    {
        private readonly IToggleData ToggleData;
        private IEnumerable<Toggle> data;

        public ToggleRepository()
        {
            ToggleData = new ToggleData();
            data = ToggleData.Data();
        }

        public ToggleRepository(IToggleData data)
        {
            ToggleData = data;
            this.data = ToggleData.Data();
        }

        public IEnumerable<Toggle> GetToggles(string environment = null)
        {
            return string.IsNullOrEmpty(environment)
                ? data
                : data.Where(x => x.Environment == environment);
        }

        public Toggle GetToggle(string name, string environment = null)
        {
            return string.IsNullOrEmpty(environment)
                ? data.FirstOrDefault(x => x.Name == name)
                : data.FirstOrDefault(x => x.Name == name && x.Environment == environment);
        }

        public Toggle SetToggle(Toggle toggle)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteToggle(Toggle toggle)
        {
            throw new System.NotImplementedException();
        }


    }
}