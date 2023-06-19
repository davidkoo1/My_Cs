using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaWiki
{
    public class Ninja
    {
        public int NinjaID { get; set; }
        public string NinjaName { get; set; }
        public int IDClan { get; set; }
        public int IDVillage { get; set; }
        public int IDRank { get; set; } //а вторичные ключи можно наследовать? с базового класса
        public bool Traitor { get; set; }

        public Ninja(int _ninjaID, string _ninjaName, int _idClan, int _idVillage, int _idRank, bool _traitor)
        {
            NinjaID = _ninjaID;
            NinjaName = _ninjaName;
            IDClan = _idClan;
            IDVillage = _idVillage;
            IDRank = _idRank;
            Traitor = _traitor;
        }

        public Ninja()
        {

        }

        public override string ToString()
        {
            return $"\n{NinjaID} | {NinjaName} | {IDClan} | {IDVillage} | {IDRank} | {Traitor}\n";
        }
    }
}
