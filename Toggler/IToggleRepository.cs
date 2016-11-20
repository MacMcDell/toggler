using System.Collections;
using System.Collections.Generic;

namespace Toggler
{
    public interface IToggleRepository
    {
        IEnumerable<Toggle> GetToggles(string environment);
        Toggle GetToggle(string name, string environment);
        Toggle SetToggle(Toggle toggle);
        void DeleteToggle(Toggle toggle);
    }
}