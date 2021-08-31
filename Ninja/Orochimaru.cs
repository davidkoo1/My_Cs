using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Orochimaru : Ninja
    {
        public Orochimaru(string name) : base(name, 100)
        {
            BaseStrength = 30;
            BaseChakra = 20;
            BaseEndurance = 10;
            BaseAgility = 0;
        }

        public new void Attack(Ninja target)
        {
            target.GetDamage(Strength, DamageTypeEnum.Poison);
            //target.damage -= 1;
        }

    }
}
