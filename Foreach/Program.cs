using System;
using System.Collections.Generic;
using System.Linq;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
           //part I
            List<int> numberList = new List<int>();

            Console.Write("Number List: \t");
            for (int i = 0; i < 6; i++)
            {
                Random random = new Random();
                int val = random.Next(1, 50);
                
                numberList.Add(val);
            }

            foreach (int n in numberList)
                Console.Write(n + "\t");

            Console.WriteLine();

            Console.Write("Even number: \t");
            foreach (int evenNumber in numberList)
                if (evenNumber %  2 == 0)
                    Console.Write(evenNumber + "\t");

            Console.WriteLine();

            int pos1 = 1;
            int pos2 = 4;

            for (int i = pos1; i <= pos2; i++)
            {
                Console.WriteLine(numberList[i]);
            }

            //Part 2

            Ship ship1 = new Ship();
            ship1.name = "BBq-2";
            ship1.massa = 12;
            ship1.military = true;

            Ship ship2 = new Ship();
            ship2.name = "lIujn-212";
            ship2.massa = 9;
            ship2.military = false;

            Ship ship3 = new Ship();
            ship3.name = "akN-1";
            ship3.massa = 50;
            ship3.military = true;

            Ship ship4 = new Ship();
            ship4.name = "lIuj-12";
            ship4.massa = 5;
            ship4.military = false;

            Ship ship5 = new Ship();
            ship5.name = "lIujskj-1291902";
            ship5.massa = 2;
            ship5.military = false;

            List<Ship> ships = new List<Ship>();
            ships.Add(ship1);
            ships.Add(ship2);
            ships.Add(ship3);
            ships.Add(ship4);
            ships.Add(ship5);




            Console.WriteLine("Model ship: ");
            foreach (Ship model in ships)
                Console.WriteLine(model.name);

            Console.WriteLine();

            Console.WriteLine("Massa ship: ");
            foreach (Ship modelMassa in ships)
                Console.WriteLine(modelMassa.massa);

            Console.WriteLine();

            int m = 0;
            string s = "";
            foreach (Ship maxModel in ships)
            {
                m = Math.Max(m, maxModel.massa);
                if (m == maxModel.massa)
                    s = maxModel.name;
            }
            Console.WriteLine(s);

            Console.WriteLine();

            foreach (Ship militaryTrue in ships)
                if (militaryTrue.military)
                    Console.WriteLine(militaryTrue.name + " " + militaryTrue.massa);
            
            Console.WriteLine();


            int sum = 0;

            foreach (Ship n in ships)
                if (n.military)
                    sum += n.massa;
            Console.WriteLine(sum);

            Console.WriteLine();

            /*
            string h = ships.Where(x => x.military == false).Max(x => x.name);
            Console.WriteLine(h);
            */

            string h = "";
            int p = 0;
            foreach (var item in ships)
            {
                if (!item.military)
                {
                    p = Math.Max(p, item.name.Length);
                    if (p == item.name.Length)
                    {
                        h = item.name;
                    }
                }
            }
            Console.WriteLine(h);

        }
    }
}
