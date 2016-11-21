using System.Collections.Generic;
using System.Xml;

namespace Toggler
{
    public interface IToggleData
    {
        IEnumerable<Toggle> Data();
        bool Save(Toggle toggle); 
    }
}