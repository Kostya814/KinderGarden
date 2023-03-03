using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderGarden
{
    class Kid: People
    {
        private Parent _parent;
        public Kid(string name, int age, Sex sex,Parent parent) : base(name, age, sex) 
        {
            
            _parent = parent;
        }
        public string Parent
        { 
            get => _parent.Name;
        }
    }
}
