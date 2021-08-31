using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Sakura : Ninja
    {
        public Sakura(string name) : base(name, 100)
        {
            BaseStrength = 15;
            BaseChakra = 350;
            BaseEndurance = 20;
            BaseAgility = 550;
        }
        public void Heal(Ninja target)
        {
            target.GetHealing(BaseChakra);
        }
        public void MegaHeal(List<Ninja> targets)
        {
            Console.WriteLine("Sakura use MEGAhiling");
            foreach (Ninja item in targets)
                item.GetHealing(Chakra);
        }

        public new void Attack(Ninja target)
        {
            target.GetDamage(Chakra / 2, DamageTypeEnum.Physical);
        }
    }

}
