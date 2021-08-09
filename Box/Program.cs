using System;
using System.Collections.Generic;

namespace boxexer
{
    public class Box
    {
        public string nameBox;
        public int numberBox;
        public List<string> thingsInBox = new List<string>();

        
        /*
        public void PrintInfoBox()
        {
            Console.Write(nameBox +" " + numberBox + "\n");

            foreach (string s in thingsInBox)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
        */
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Box lotBox = new Box();
            lotBox.nameBox = "Lot box";
            lotBox.numberBox = 1;
            lotBox.thingsInBox = new List<string>();
            
            lotBox.thingsInBox.Add("Silver");
            lotBox.thingsInBox.Add("Ore");
            lotBox.thingsInBox.Add("Materials");


            //lotBox.PrintInfoBox();

            Box foodBox = new Box();
            foodBox.nameBox = "Food box";
            foodBox.numberBox = 2;
            foodBox.thingsInBox = new List<string>();

            foodBox.thingsInBox.Add("Eggs");
            foodBox.thingsInBox.Add("Potatoes ");
            foodBox.thingsInBox.Add("Bread");

           // foodBox.PrintInfoBox();

            Box weaponsBox = new Box();
            weaponsBox.nameBox = "Weapons box";
            weaponsBox.numberBox = 3;
            weaponsBox.thingsInBox = new List<string>();

            weaponsBox.thingsInBox.Add("Bow");
            weaponsBox.thingsInBox.Add("Sword ");
            weaponsBox.thingsInBox.Add("Hand");

            //weaponsBox.PrintInfoBox();


            List<List<string>> inBox = new List<List<string>>();
            inBox.Add(lotBox.thingsInBox);
            inBox.Add(foodBox.thingsInBox);
            inBox.Add(weaponsBox.thingsInBox);


            foreach (List<string> list in inBox)
            {
                foreach (string informationOfBox in list)
                {
                    Console.WriteLine(informationOfBox);
                }
                Console.WriteLine();
            }

        }
    }
}
