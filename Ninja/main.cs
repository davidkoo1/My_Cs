using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    class main
    {
        static void Main(string[] args)
        {
            string allies = @"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\OOP\Game\Game\bin\Debug\net5.0\allies.txt";
            string enemies = @"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\OOP\Game\Game\bin\Debug\net5.0\enemies.txt";

            string output = "output.dat";
            string output1 = "output1.dat";

            //Персонажи
            // Ninja ninja = new Ninja("KriKri", 100);
            Naruto naruto = new Naruto("Naruto");
            //naruto.CreateClone();
            Deidara deidara = new Deidara("Deidara");
            Sakura sakura = new Sakura("Sakura");
            Orochimaru orochi = new Orochimaru("Orochimaru");
            Chouji chouji = new Chouji("Chouji");

            //Баффы
            AttackBuff attackbuff = new AttackBuff();
            PoisonBuff poisonBuff = new PoisonBuff();
            SpeedBuff speedBuff = new SpeedBuff();
            ChakraBuff chakraBuff = new ChakraBuff();

            //Битва
            Battle battle = new Battle();

            //Читаем из файла

            //Команда игрока
            List<Ninja> playerNinja = //FileControl.DeserializeFromFile(@"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\OOP\Game\Game\bin\Debug\output1.dat");
                                       new List<Ninja>();
           /* playerNinja.Add(naruto);
            playerNinja.Add(orochi);
            playerNinja.Add(chouji);*/

            //Команда врага
            List<Ninja> enemyNinja = //FileControl.DeserializeFromFile(@"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\OOP\Game\Game\bin\Debug\output.dat");
                                        new List<Ninja>();
            playerNinja.Add(sakura);
            playerNinja.Add(deidara);

            //Запись в файл команду
            //FileControl.SerializeToFile(playerNinja, output);
            FileControl.SerializeToFile(enemyNinja, output1);

            battle.playerNinja = playerNinja;
            battle.enemyNinja = enemyNinja;

            //Информация о игроках
            battle.PrintAllInfo();

            //Начало битвы
            battle.StartBattle();

            //основной цикл
            while (!battle.BattleOver())
            {
                Ninja nowActing = battle.NextNinja();

               
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\tСейчас ходит:");
                Console.ResetColor();

                Console.WriteLine(nowActing);

                if (battle.playerNinja.Contains(nowActing))
                {
                    //Действия своего ниндзя
                    int index = 0;
                    foreach (var n in enemyNinja)
                    {
                        Console.WriteLine(index + " " + n);
                        index++;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"\nВыберите цель от 0 до {enemyNinja.Count - 1} >> ");
                    Console.ResetColor();
                    int targetindex = Convert.ToInt32(Console.ReadLine());
                    Ninja targetNinja = enemyNinja[targetindex];
                    nowActing.Attack(targetNinja);

                }
                else
                {
                    //Действия вражеского ниндзя

                    Random rand = new Random();
                    int indextarget = rand.Next(0, playerNinja.Count - 1);

                    Ninja targetNinja = playerNinja[indextarget];
                    nowActing.Attack(targetNinja);

                }
                
            }

            Console.WriteLine("Battle Over!");


            /*
            List<Ninja>  toExplode = new List<Ninja>();
            toExplode.Add(naruto);
            toExplode.Add(ninja);
            toExplode.Add(orochi);
            toExplode.Add(chouji);

            deidara.Explode(toExplode);
            */

            

        }
    }
}
