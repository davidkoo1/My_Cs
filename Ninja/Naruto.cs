using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Naruto : Ninja
    {

        public Naruto(string name) : base (name, 100)
        {
            BaseStrength = 50;  //сила
            BaseChakra = 5;   //чакра
            BaseEndurance = 2; //выносливость 
            BaseAgility = 0;  //ловкость 
        }

        public Naruto CreateClone()
        {
            Console.WriteLine("Naruto Crete Clone...");
            return new Naruto("Clone Naruto");
        }

        public /*override*/ new void Attack(Ninja target)
        {
            target.GetDamage(Strength * Endurance, DamageTypeEnum.Physical);
        }

    }

}
