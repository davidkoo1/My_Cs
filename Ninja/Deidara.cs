using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Deidara : Ninja
    {
        public Deidara(string name) : base(name, 100)
        {
            BaseStrength = 30;
            BaseChakra = 25;
            BaseEndurance = 2;
            BaseAgility = 11;
        }
        public void Explode(List<Ninja> targets)
        {
            foreach (Ninja n in targets)
                n.GetDamage(Strength + Chakra, DamageTypeEnum.Magic);
        }
    }

}
