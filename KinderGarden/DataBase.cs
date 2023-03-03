using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinderGarden
{
    public class DataBase
    {
        private Random _rand = new Random();
        internal List<KinderGarden> kinderGarden { get; private set; }
        
       
        public DataBase()
            
        {
            List<Kid> kids = new List<Kid>()//Дети 1 садика
            {
                new Kid("Костя",5,Sex.M,new Parent("Валера",_rand.Next(21,70),Sex.M)),
                new Kid ("Настя",6,Sex.W,new Parent("Дима",_rand.Next(21,70),Sex.M)),
                new Kid("Витя",3,Sex.M,new Parent("Михаил",_rand.Next(21,70),Sex.M)),
                new Kid("Женя",4,Sex.M,new Parent("Марина",_rand.Next(21,70),Sex.W))
            };


            List<Kid> kids1 = new List<Kid>()//Дети 2 садика
            {
                new Kid("Дима",6,Sex.M,new Parent("Оля",_rand.Next(21,70),Sex.W)),
                new Kid ("Витя",6,Sex.M,new Parent("Валя",_rand.Next(21,70),Sex.W)),
                new Kid("Даниил",2,Sex.M,new Parent("Наташа",_rand.Next(21,70),Sex.W)),
                new Kid("Михаил",5,Sex.M,new Parent("Марина",_rand.Next(21,70),Sex.W)),
                new Kid("Женя",7,Sex.M,new Parent("Олу",_rand.Next(21,70),Sex.W))
            };


            kinderGarden = new List<KinderGarden>()
            {
                new KinderGarden(kids,new City("Москва","Россия"),"Солнышко"),
                new KinderGarden(kids1,new City("Санкт-Петербург","Россия"),"Тормозок")

            };
        }
        
                   

        
    }
}
