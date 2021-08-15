using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Battle
    {
        Queue<Ninja> turnQueue; //очередь

        public List<Ninja> playerNinja = new List<Ninja>(); //список ниндзя игрока


        public List<Ninja> enemyNinja = new List<Ninja>();  //список ниндзя врага


        
        public List<Ninja> AlivePlayerNinja
        {
            get
            {
                List<Ninja> livePlayerNinja = new List<Ninja>();
                foreach (var item in playerNinja)
                    if (!item.isDead) livePlayerNinja.Add(item);
                return livePlayerNinja;
            }
        }

        public List<Ninja> AliveEnemyNinja
        {
            get
            {
                List<Ninja> liveEnemyNinja = new List<Ninja>();
                foreach (var item in enemyNinja)
                    if (item.isDead) liveEnemyNinja.Add(item);
                return liveEnemyNinja;
            }
        }


        public void PrintAllInfo()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\tPlayer ninja:");
            Console.ResetColor();
            foreach (Ninja i in playerNinja)
                Console.WriteLine(i + "\t");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tEnemy ninja:");
            Console.ResetColor();
            foreach (Ninja i in enemyNinja)
                Console.WriteLine(i + "\t");
        }
        
        public void StartBattle()
        {
            //Объединяем всех персонажий в 1 список
            List<Ninja> allNinja = new List<Ninja>
                (playerNinja.Union(enemyNinja));

            //Сортируем по скорости(по убыванию)
            List<Ninja> sortedNinja = new List<Ninja>
                (allNinja.OrderByDescending(ninja => ninja.Agility));//лямбда выражений

            //Queue - очередь
            turnQueue = new Queue<Ninja>(sortedNinja);

        }

        public bool AllNinjaDead(List<Ninja> ninjas)
        {
            foreach (Ninja i in ninjas)
                if (!i.isDead) return false;
                return true;

        }
        public bool BattleOver()
        {
            bool enemyNinjaDead = AllNinjaDead(enemyNinja);
            bool playerNinjaDead = AllNinjaDead(playerNinja);

            return enemyNinjaDead || playerNinjaDead;

            /*
            if(!enemyNinjaDead || !playerNinjaDead)
            return true;
            return false;
            */
        }

        public Ninja NextNinja()
        {

            turnQueue = new Queue<Ninja>
                (turnQueue.Where(ninja => !ninja.isDead));

            Ninja nextNinja = turnQueue.Dequeue();
            turnQueue.Enqueue(nextNinja);

            return nextNinja;
        }
    }
}
