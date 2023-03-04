using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderGarden
{
    class City
    {
        private string _name;
        private string _country;
        public City(string name) 
        {
            _name = name;
            _country = "Россия";
        }
        public string Name
        { 
            get => _name;
        }
        public string Country
        { 
            get => _country; 
        }
    }
}
