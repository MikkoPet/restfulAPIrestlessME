using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apicashon.Classes.models
{
    internal class Production
    {
        private int _index;
        private string _name;
        private string _unit;
        public string Name { get { return _name; } }
        public string Unit { get { return _unit; } }
        public int Index { get { return _index; } }

        public Production(int index, string name, string unit)
        {            
            _index = index;
            _name = name;
            _unit = unit;
        }
    }
}
