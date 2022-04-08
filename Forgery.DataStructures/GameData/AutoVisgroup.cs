using System.Collections.Generic;

namespace Forgery.DataStructures.GameData
{
    public class AutoVisgroup
    {
        public string Name { get; set; }
        public List<string> EntityNames { get; private set; }

        public AutoVisgroup()
        {
            EntityNames = new List<string>();
        }
    }
}