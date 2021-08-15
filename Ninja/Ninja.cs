using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class Ninja
    {
        public string name; 

        //Жизнь
        public int MaxHealth { get; }
        internal int nowHealth;
        public int NowHealth { get { return nowHealth; } }
        

        public bool isDead = false; //смерть ниндзя

        //Ярость
        /*
        public int MaxRage { get; }
        internal int nowRage;
        public int NowRage { get { return nowRage; } }
        */

        //Сила
        public int BaseStrength;
        public int AddStrength;
        public int Strength
        {
            get { return BaseStrength + AddStrength; }
        }

        //Чакра
        public int BaseChakra;
        public int AddChakra;
        public int Chakra
        {
            get { return BaseChakra + AddChakra; }
        }

        //Выносливость
        public int BaseEndurance;
        public int AddEndurance;
        public int Endurance
        {
            get { return BaseEndurance + AddEndurance; }
        }

        //Ловкость
        public int BaseAgility;
        public int AddAgility;
        public int Agility
        {
            get { return BaseAgility + AddAgility; }
        }


        public List<Buff> buffs = new List<Buff>();


        public Ninja(string name, int MaxHealth)
        {
            this.name = name;
            this.nowHealth = MaxHealth;
            this.MaxHealth = MaxHealth;

            BaseStrength = 10;
            BaseChakra = 6;
            BaseEndurance = 8;
            BaseStrength = 15;
        }


        internal int ReducaDamage(int damage, DamageTypeEnum damageType)
        {
            switch (damageType)
            {
                case DamageTypeEnum.Physical:
                    damage = damage - Endurance;
                    break;
                case DamageTypeEnum.Magic:
                    damage = damage - Chakra;
                    break;
                case DamageTypeEnum.Poison:
                    break;
            }
            if (damage < 1)
            damage = 1;
            return damage;
        }

        //Получаемый урон
        public virtual void GetDamage(int damage, DamageTypeEnum damageType)
        {
            int realDamage = ReducaDamage(damage, damageType);

            nowHealth -= realDamage;

            if (nowHealth <= 0)
                nowHealth = 0;

            Console.Write($"{name} получил ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{realDamage}");
            Console.ResetColor();
            Console.Write(" потери здоровья.");
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( $" HP: {nowHealth}/{MaxHealth}");
            Console.ResetColor();

            if (nowHealth <= 0)
                Die();

        }

        //Сообщение о смерти ниндзя
        internal void Die()
        {
            isDead = true;
            Console.WriteLine($"Ninja {name} die... "); 
        }


        //Получить хилл
        public void GetHealing(int healing)
        {
            if (isDead == false)
            {
                nowHealth = Math.Min(MaxHealth, nowHealth + healing);
                if (nowHealth >= MaxHealth) nowHealth = MaxHealth;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} получает {healing} восстановления здоровья\t HP:     {nowHealth}");
                Console.ResetColor();
                //Specifications();
            }

         /*   if (nowHealth >= MaxHealth)
                Console.WriteLine($"{name} полностью здоров");*/


        }

        //Характерискики ниндзя
        public void Specifications()
        {
            Console.WriteLine($"\t\tSpecifications {name}" +
                              $"\nStrength: {Strength}\n" +
                              $"Chakra: {Chakra}\n" +
                              $"Endurance: {Endurance}\n" +
                              $"Agility: {Agility}");
        }
        
        //Атакуем 
        public /*virtual*/ void Attack(Ninja target)
        {
            
            if (isDead)
                return;
            if (target.isDead)
                return;
                /*if (typeof(Orochimaru).IsInstanceOfType(target))
                    GetDamage(5, DamageTypeEnum.Poison);
                */
                // Console.Write(name + " нанёс урон " + target.name);
                int rand = 0;
                if (target.Agility <= this.Agility)
                    target.GetDamage(Strength, DamageTypeEnum.Magic);

                else if (target.Agility >= this.Agility)
                {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int shans = 100 - (target.Agility - Agility) * 5;
                    Random random = new Random();
                    rand = random.Next(1, 100);
                    if (rand > shans)
                        Console.Write($"Ninja {target.name} увернулся и не потерял здоровье!\n");
                    else target.GetDamage(Strength, DamageTypeEnum.Magic);
                Console.ResetColor();
            }

        }

        public void NextTurn()
        {
            for (int i = 0; i < buffs.Count; i++)
            {
                Buff buff = buffs[i];
                buff.EveryTurn(this);
                buff.trunsLeft--;
                if (buff.trunsLeft <= 0)
                {
                    buff.Remove(this);
                    i--;
                }
                Console.WriteLine($"Сейчас ходит {name}");
                PrintBuffs();
            }
        }

        //Информация о баффе
        public void PrintBuffs()
        {

            Console.WriteLine($"\n\tБаффы {name}");
            Console.Write("+--------------------+\n");
            foreach (Buff buff in buffs)
                Console.WriteLine(buff);
            Console.Write("+--------------------+\n");
        }

        //Строка
        public override string ToString()
        {
            
            return $"Ninja {name}     \t\tHealth: {nowHealth }/{ MaxHealth}";

            /*---------------\n|Strength: {Strength}|\n|Chakra: {Chakra}|\n|Endurance: {Endurance}|\n|Agility: {Agility}|\n---------------"*/;
        }
    }

}
