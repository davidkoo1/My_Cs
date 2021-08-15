using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class NinjaFactory
    {
     /*   public static Ninja CreateNinja()
        {
            return new Ninja("Ninja");
        }
     */
        public static Naruto CreateNaruto()
        {
            return new Naruto("Naruto");
        }

        public static Sakura CreateSakura()
        {
            return new Sakura("Sakura");
        }

        public static Deidara CreateDeidara()
        {
            return new Deidara("Deidara");
        }

        public static Chouji CreateChouji()
        {
            return new Chouji("Chouji");
        }

        public static Orochimaru CreateOrochimaru()
        {
            return new Orochimaru("Orochimaru");
        }

    }
}
