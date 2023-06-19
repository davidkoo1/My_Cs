using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    //Абстракный класс баффов
    public abstract class Buff
    {
        public string name;
        public int trunsLeft;

        public abstract void Apply(Ninja applyTo, int duration);
        public abstract void EveryTurn(Ninja applyTo);
        public abstract void Remove(Ninja removeFrom);
    }

    //Бафф атаки 
    class AttackBuff : Buff
    {

        public override void Apply(Ninja applyTo, int duration)
        {
            applyTo.AddStrength += (int)Math.Floor(applyTo.BaseStrength * 0.15); //атака +15%
            trunsLeft = duration;
            applyTo.buffs.Add(this);
            applyTo.PrintBuffs();
        }

        public override void EveryTurn(Ninja applyTo)
        {

        }

        public override void Remove(Ninja removeFrom)
        {
            removeFrom.AddStrength -= (int)Math.Floor(removeFrom.BaseStrength * 0.15); //атака -15%
            removeFrom.buffs.Remove(this);
        }

        public override string ToString()
        {
            return "Aтака на 15%\nОсталось ходов: " + trunsLeft;
        }

    }

    //Бафф яда
    class PoisonBuff : Buff
    {
        public override void Apply(Ninja applyTo, int duration)
        {
            trunsLeft = duration;
            applyTo.buffs.Add(this);
            applyTo.PrintBuffs();
        }

        public override void EveryTurn(Ninja applyTo)
        {
            int poisonDamage = (int)Math.Floor(applyTo.NowHealth * 0.15);
            applyTo.GetDamage(poisonDamage, DamageTypeEnum.Poison);
        }

        public override void Remove(Ninja removeFrom)
        {
            removeFrom.buffs.Remove(this);
        }

        public override string ToString()
        {
            return "Яд, осталось ходов: " + trunsLeft;
        }
    }

    //Бафф базовой ловкости 
    class SpeedBuff : Buff
    {
        public override void Apply(Ninja applyTo, int duration)
        {
            applyTo.AddAgility += (int)Math.Floor(applyTo.BaseAgility * 0.70); //+75%
            trunsLeft = duration;
            applyTo.buffs.Add(this);
            applyTo.PrintBuffs();
        }

        public override void EveryTurn(Ninja applyTo)
        {

        }

        public override void Remove(Ninja removeFrom)
        {
            removeFrom.AddAgility -= (int)Math.Floor(removeFrom.BaseAgility * 0.70); //-75%
            removeFrom.buffs.Remove(this);
        }

        public override string ToString()
        {
            return "Ловкость увеличилась на 75%\nОсталось ходов: " + trunsLeft;
        }
    }

    //Бафф базовой чакры
    class ChakraBuff : Buff
    {
        public override void Apply(Ninja applyTo, int duration)
        {
            applyTo.AddChakra += (int)Math.Floor(applyTo.BaseChakra * 0.15); //+15%
            trunsLeft = duration;
            applyTo.buffs.Add(this);
            applyTo.PrintBuffs();
        }

        public override void EveryTurn(Ninja applyTo)
        {

        }

        public override void Remove(Ninja removeFrom)
        {
            removeFrom.AddChakra -= (int)Math.Floor(removeFrom.BaseChakra * 0.15); //-75%
            removeFrom.buffs.Remove(this);
        }

        public override string ToString()
        {
            return "Чакра увеличилась на 15%\nОсталось ходов: " + trunsLeft;
        }
    }
}
