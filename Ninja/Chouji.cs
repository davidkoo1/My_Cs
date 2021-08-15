using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Chouji : Ninja
    {
        public Chouji(string name) : base(name, 100)
        {
            BaseStrength = 55;
            BaseChakra = 1;
            BaseEndurance = 25;
            BaseAgility = 0;
        }

        public override void GetDamage(int damage, DamageTypeEnum damageType)
        {
            int realDamage = ReducaDamage(damage, damageType);
            realDamage = realDamage / 2; 
            
            nowHealth -= realDamage;
            if (nowHealth <= 0)
                nowHealth = 0;

            Console.WriteLine($"{name} получает {realDamage} урона\t " +
            $" HP: {nowHealth}/{MaxHealth}");

            if (nowHealth <= 0)
                Die();
        }

        public void butterfly()
        {
            nowHealth = MaxHealth;

        }
    }
}
