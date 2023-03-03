using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderGarden
{
    class KinderGarden
    {
        private List<Kid> _kids;
        private City _city;
        private string _name;
        public KinderGarden(List<Kid> kinds, City city, string name)
        {
            _kids = kinds;
            _city = city;
            _name = name;
        }
        public string Name
        { 
            get => _name;
        }
        public string City
        {
            get => _city.Name;
        }
        public int CountKids
        { 
            get => _kids.Count;
        }
        public List<Kid> kids
        {
            get => _kids;
        }
    }
}
