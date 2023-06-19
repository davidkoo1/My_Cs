using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace NinjaWiki
{
    class Program
    {
        static int GetNewNinjaID(List<Ninja> ninjas) => ninjas.Count > 0 ? ninjas.Max(x => x.NinjaID) + 1 : 1;
        static int GetNewClanID(List<Clan> clans) => clans.Count > 0 ? clans.Max(x => x.ClanID) + 1 : 1;
        static int GetNewVillageID(List<Village> villages) => villages.Count > 0 ? villages.Max(x => x.VillageID) + 1 : 1;
        static int GetNewRankID(List<Rank> ranks) => ranks.Count > 0 ? ranks.Max(x => x.RankID) + 1 : 1;
        static int GetNewSkillCategoryID(List<SkillCategory> skillCategories) => skillCategories.Count > 0 ? skillCategories.Max(x => x.CategoryID) + 1 : 1;
        static int GetNewSkillID(List<Skill> skills) => skills.Count > 0 ? skills.Max(x => x.SkillID) + 1 : 1;
        static int GetNewBattleID(List<Battle> battles) => battles.Count > 0 ? battles.Max(x => x.BattleID) + 1 : 1;

        static void Successful()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfull!");
            Console.ResetColor(); ;
        }
        static void UnSuccessful()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("UnSuccessfull, try again!");
            Console.ResetColor();
        }

        static List<Ninja> ninjas = new List<Ninja>();
        static List<Clan> clans = new List<Clan>();
        static List<Village> villages = new List<Village>();
        static List<Rank> ranks = new List<Rank>();
        static List<SkillCategory> skillCategories = new List<SkillCategory>();
        static List<Skill> skills = new List<Skill>();
        static List<NinjaSkills> ninjaSkills = new List<NinjaSkills>();
        static List<Battle> battles = new List<Battle>();
        static List<NinjaBattles> ninjaBattles = new List<NinjaBattles>();

        static async void DataReader()
        {
            while (true)
            {
                Thread.Sleep(1000);
                ninjas = await DatabaseConnector.GetNinjas();
                clans = await DatabaseConnector.GetClans();
                villages = await DatabaseConnector.GetVillages();
                ranks = await DatabaseConnector.GetRanks();
                skillCategories = await DatabaseConnector.GetSkillCategories();
                skills = await DatabaseConnector.GetSkills();
                ninjaSkills = await DatabaseConnector.GetSkillsNinja();
                battles = await DatabaseConnector.GetBattles();
                ninjaBattles = await DatabaseConnector.GetBattlesNinja();
            }
        }
        static async Task Main(string[] args)
        {


            new Thread(DataReader).Start(); //поток


            while (true)
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Ninja"); 
                Console.WriteLine("2 - Clan"); 
                Console.WriteLine("3 - Village");
                Console.WriteLine("4 - Rank");
                Console.WriteLine("5 - SkillCategory");
                Console.WriteLine("6 - Skill");
                Console.WriteLine("7 - NinjaSkill");
                Console.WriteLine("8 - Battle");
                Console.WriteLine("9 - NinjaBattle");


                int globalOption = int.Parse(Console.ReadLine());

                if (globalOption == 0) break;
                switch (globalOption)
                {
                    //Ninja Case (CRUD)
                    case 1:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Ninja");
                                Console.WriteLine("2 - Insert Ninja");
                                Console.WriteLine("3 - Update Ninja");
                                Console.WriteLine("4 - Delete Ninja");
                                int ninjaOption = int.Parse(Console.ReadLine());

                                if (ninjaOption == 0) break;
                                switch (ninjaOption)
                                {
                                    case 1:
                                        {
                                            /*
                                                                                        foreach (Ninja ninja in ninjas)
                                                                                            Console.WriteLine(ninja.ToString());*/
                                            foreach (var ninja in ninjas)
                                            {
                                                Console.Write(ninja.NinjaName + " ");
                                                foreach (var clan in clans)
                                                {
                                                    if (ninja.IDClan == clan.ClanID)
                                                        Console.Write(clan.ClanName + " ");
                                                }
                                                foreach (var village in villages)
                                                {
                                                    if (village.VillageID == ninja.IDVillage)
                                                        Console.Write("деревня \"" + village.VillageName + "\" ");
                                                }

                                                foreach (var rank in ranks)
                                                    if (rank.RankID == ninja.IDRank)
                                                        Console.WriteLine(rank.RankName + " " + rank.RankLetter);
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Insert new ninja\n");
                                            Console.WriteLine("Input name of ninja:");
                                            string ninjaName = Console.ReadLine();


                                            Clan selectedClan = null;
                                            while (selectedClan == null)
                                            {
                                                Console.WriteLine("Select Clan name");
                                                for (int i = 1; i <= clans.Count; i++)
                                                    Console.WriteLine(clans[i - 1].ClanName);
                                                Console.WriteLine("+ - Add new");

                                                string selectedClanName = Console.ReadLine();
                                                if (selectedClanName != "+")
                                                    selectedClan = clans.Where(x => x.ClanName == selectedClanName).FirstOrDefault();
                                                else
                                                {
                                                    //Предлогаем добавить клан
                                                    Clan newClan = new Clan();
                                                    newClan.ClanID = GetNewClanID(clans);
                                                    Console.WriteLine("Input new name clan: ");
                                                    newClan.ClanName = Console.ReadLine();
                                                    Console.WriteLine("Input clan discription: ");
                                                    newClan.ClanDiscription = Console.ReadLine();

                                                    try
                                                    {
                                                        await DatabaseConnector.AddClan(newClan);
                                                        clans.Add(newClan);
                                                        Successful();
                                                    }
                                                    catch (Exception)
                                                    {
                                                        UnSuccessful();
                                                    }
                                                }

                                            }


                                            Village selectedVillage = null;
                                            while (selectedVillage == null)
                                            {
                                                Console.WriteLine("Select Village name");
                                                for (int i = 1; i <= villages.Count; i++)
                                                    Console.WriteLine(villages[i - 1].VillageName);
                                                Console.WriteLine("+ - Add new");

                                                string selectedVillageName = Console.ReadLine();
                                                if (selectedVillageName != "+")
                                                    selectedVillage = villages.Where(x => x.VillageName == selectedVillageName).FirstOrDefault();
                                                else
                                                {
                                                    //Предлогаем добавить деревню
                                                    Village newVillage = new Village();
                                                    newVillage.VillageID = GetNewVillageID(villages);
                                                    Console.WriteLine("Input new name clan: ");
                                                    newVillage.VillageName = Console.ReadLine();

                                                    try
                                                    {
                                                        await DatabaseConnector.AddVillage(newVillage);
                                                        villages.Add(newVillage);
                                                        Successful();
                                                    }
                                                    catch (Exception)
                                                    {
                                                        UnSuccessful();
                                                    }
                                                }

                                            }


                                            Rank selectedRank = null;
                                            while (selectedRank == null)
                                            {
                                                Console.WriteLine("Select Rank");
                                                for (int i = 1; i <= ranks.Count; i++)
                                                    Console.WriteLine(i + " " + ranks[i - 1].RankName + " " + ranks[i - 1].RankLetter);


                                                int selectedRankIndex = int.Parse(Console.ReadLine());
                                                selectedRank = ranks[selectedRankIndex - 1];

                                            }


                                            Console.WriteLine("is Traitor? Yes\\No");
                                            string tmpIS = Console.ReadLine();
                                            bool isTraitor = (tmpIS.ToLower() == "yes") ? true : false;


                                            Ninja newNinja = new Ninja
                                                (GetNewNinjaID(ninjas),
                                                ninjaName,
                                                selectedClan.ClanID,
                                                selectedVillage.VillageID,
                                                selectedRank.RankID,
                                                isTraitor);

                                            try
                                            {
                                                await DatabaseConnector.AddNinja(newNinja);
                                                ninjas.Add(newNinja);
                                                Successful();
                                            }
                                            catch (Exception e)
                                            {
                                                UnSuccessful();
                                                //Console.WriteLine(e.Message);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {

                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + " " + ninjas[i - 1].ToString());
                                            int selectNinjaIndex = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Выбери ниндзя которого будем изменять");

                                            Ninja selectedNinjaForUpdateDate = ninjas[selectNinjaIndex - 1];


                                            Type type = typeof(Ninja);
                                            PropertyInfo[] properties = type.GetProperties();

                                            Console.WriteLine("Выберите изменяемое поле:");
                                            for (int i = 1; i < properties.Length; i++)
                                            {
                                                PropertyInfo property = properties[i];
                                                Console.WriteLine($"{i} - {property.Name}");
                                            }

                                            int propertyNumber = int.Parse(Console.ReadLine());

                                            switch (propertyNumber)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine($"Input new name for {selectedNinjaForUpdateDate.NinjaName}");
                                                        selectedNinjaForUpdateDate.NinjaName = Console.ReadLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("Select new Clan");
                                                        for (int i = 1; i <= clans.Count; i++)
                                                            Console.WriteLine(i + " - " + clans[i - 1].ClanName + "\nDiscription: " + clans[i - 1].ClanDiscription);
                                                        int slectedClanIndex = int.Parse(Console.ReadLine());
                                                        selectedNinjaForUpdateDate.IDClan = clans[slectedClanIndex - 1].ClanID;

                                                        break;
                                                    }
                                                case 3:
                                                    {

                                                        Console.WriteLine("Select new Village");
                                                        for (int i = 1; i <= villages.Count; i++)
                                                            Console.WriteLine(i + " " + villages[i - 1].VillageName);
                                                        int slectedVillageIndex = int.Parse(Console.ReadLine());
                                                        selectedNinjaForUpdateDate.IDVillage = villages[slectedVillageIndex - 1].VillageID;

                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        Console.WriteLine("Select new Rank");
                                                        for (int i = 1; i <= ranks.Count; i++)
                                                            Console.WriteLine(i + " " + ranks[i - 1].RankName + " " + ranks[i - 1].RankLetter);
                                                        int slectedRankIndex = int.Parse(Console.ReadLine());
                                                        selectedNinjaForUpdateDate.IDVillage = ranks[slectedRankIndex - 1].RankID;

                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        selectedNinjaForUpdateDate.Traitor = !selectedNinjaForUpdateDate.Traitor;

                                                        break;
                                                    }
                                            }

                                            try
                                            {
                                                await DatabaseConnector.UpdateNinja(selectedNinjaForUpdateDate);
                                                ninjas[selectNinjaIndex - 1] = selectedNinjaForUpdateDate;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }


                                            break;
                                        }
                                    case 4:
                                        {

                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + "\t" + ninjas[i - 1].NinjaName);
                                            int selectIndex = 0;
                                            while (selectIndex < 1 || selectIndex > ninjas.Count)
                                            {
                                                Console.WriteLine("Input selected index");
                                                selectIndex = int.Parse(Console.ReadLine());
                                            }
                                            Ninja delNinja = ninjas[selectIndex - 1];
                                            try
                                            {
                                                await DatabaseConnector.DeleteNinja(delNinja);
                                                ninjas.Remove(delNinja);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }


                                }


                            }



                            break;
                        }

                    //Clan Case (CRUD)
                    case 2:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Clan");
                                Console.WriteLine("2 - Insert Clan");
                                Console.WriteLine("3 - Update Clan");
                                Console.WriteLine("4 - Delete Clan");
                                int clanOption = int.Parse(Console.ReadLine());

                                if (clanOption == 0) break;
                                switch (clanOption)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("List <Clans>: ");
                                            foreach (var clan in clans)
                                                Console.WriteLine(clan.ClanName + "\nDiscription: " + clan.ClanDiscription);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Clan newClan = new Clan();
                                            newClan.ClanID = GetNewClanID(clans);
                                            Console.WriteLine("Enter new Name for clan: ");
                                            newClan.ClanName = Console.ReadLine();
                                            Console.WriteLine("Write discription clan");
                                            newClan.ClanDiscription = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.AddClan(newClan);
                                                clans.Add(newClan);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            for (int i = 1; i <= clans.Count; i++)
                                                Console.WriteLine(i + " " + clans[i - 1].ClanName + "\nDiscription: " + clans[i - 1].ClanDiscription);
                                            int selectClanForUpdate = int.Parse(Console.ReadLine());
                                            Clan updateClan = clans[selectClanForUpdate - 1];
                                            Console.WriteLine("1 - Update Name");
                                            Console.WriteLine("2 - Update Discription");
                                            Console.WriteLine("3 - FullUpdate");
                                            int updateClanOption = int.Parse(Console.ReadLine());

                                            switch (updateClanOption)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Input new name");
                                                        updateClan.ClanName = Console.ReadLine();
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("Input new Discription");
                                                        updateClan.ClanDiscription = Console.ReadLine();

                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.WriteLine("Input new name");
                                                        updateClan.ClanName = Console.ReadLine();
                                                        Console.WriteLine("Input new Discription");
                                                        updateClan.ClanDiscription = Console.ReadLine();
                                                        break;
                                                    }

                                            }
                                            try
                                            {
                                                await DatabaseConnector.UpdateClan(updateClan);
                                                clans[selectClanForUpdate - 1] = updateClan;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();

                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            for (int i = 1; i <= clans.Count; i++)
                                                Console.WriteLine(i + " " + clans[i - 1].ClanName);
                                            int selectClanForDelete = int.Parse(Console.ReadLine());
                                            Clan deleteClan = clans[selectClanForDelete - 1];
                                            try
                                            {
                                                await DatabaseConnector.DeleteClan(deleteClan);
                                                clans.Remove(deleteClan);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    //Village Case (CRUD)
                    case 3:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Villages");
                                Console.WriteLine("2 - Insert Village");
                                Console.WriteLine("3 - Update Village");
                                Console.WriteLine("4 - Delete Village");
                                int villageOption = int.Parse(Console.ReadLine());

                                if (villageOption == 0) break;
                                switch (villageOption)
                                {
                                    case 1:
                                        {
                                            for (int i = 1; i <= villages.Count; i++)
                                                Console.WriteLine(villages[i - 1].VillageName);

                                            break;
                                        }
                                    case 2:
                                        {
                                            Village newVillage = new Village();
                                            Console.WriteLine("Input new name Village: ");
                                            newVillage.VillageID = GetNewVillageID(villages);
                                            newVillage.VillageName = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.AddVillage(newVillage);
                                                villages.Add(newVillage);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();

                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            for (int i = 1; i <= villages.Count; i++)
                                                Console.WriteLine(i + " " + villages[i - 1].VillageName);
                                            Console.WriteLine("Select village index");

                                            int selectVilladeIndexUpdate = int.Parse(Console.ReadLine());

                                            Village village = villages[selectVilladeIndexUpdate - 1];

                                            Console.WriteLine("Print update name: ");
                                            village.VillageName = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.UpdateVillage(village);
                                                villages[selectVilladeIndexUpdate - 1] = village;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {

                                                UnSuccessful();
                                            }

                                            break;
                                        }
                                    case 4:
                                        {
                                            for (int i = 1; i <= villages.Count; i++)
                                                Console.WriteLine(i + " " + villages[i - 1].VillageName);
                                            Console.WriteLine("Select village index");
                                            int selectVilladeIndexDelete = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.DeleteVillage(villages[selectVilladeIndexDelete - 1]);
                                                villages.Remove(villages[selectVilladeIndexDelete - 1]);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }

                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    //Rank Case (CRUD)
                    case 4:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Ranks");
                                Console.WriteLine("2 - Insert Rank");
                                Console.WriteLine("3 - Update Rank");
                                Console.WriteLine("4 - Delete Rank");
                                int rankOption = int.Parse(Console.ReadLine());

                                if (rankOption == 0) break;
                                switch (rankOption)
                                {
                                    case 1:
                                        {
                                            for (int i = 1; i <= ranks.Count; i++)
                                                Console.WriteLine(ranks[i - 1].RankName + " " + ranks[i - 1].RankLetter);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Rank newRank = new Rank();
                                            Console.WriteLine("Enter new rank name");
                                            newRank.RankID = GetNewRankID(ranks);
                                            newRank.RankName = Console.ReadLine();
                                            Console.WriteLine("Enter Rank Letter");
                                            newRank.RankLetter = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.AddRank(newRank);
                                                ranks.Add(newRank);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            for (int i = 1; i <= ranks.Count; i++)
                                                Console.WriteLine(i + " " + ranks[i - 1].RankName + " " + ranks[i - 1].RankLetter);
                                            Console.WriteLine("Select Rank Index");
                                            int selectRankIndexUpdate = int.Parse(Console.ReadLine());

                                            Console.WriteLine("1 - Update Rank Name");
                                            Console.WriteLine("2 - Update Rank Letter");
                                            Console.WriteLine("3 - Update Full");

                                            int rankUpdateOption = int.Parse(Console.ReadLine());
                                            Rank updateRank = ranks[selectRankIndexUpdate - 1];
                                            switch (rankUpdateOption)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Print new name for Rank");
                                                        updateRank.RankName = Console.ReadLine();

                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("Print new letter for Rank");
                                                        updateRank.RankLetter = Console.ReadLine();

                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.WriteLine("Print new name for Rank");
                                                        updateRank.RankName = Console.ReadLine();
                                                        Console.WriteLine("Print new letter for Rank");
                                                        updateRank.RankLetter = Console.ReadLine();
                                                        break;
                                                    }

                                            }

                                            try
                                            {
                                                await DatabaseConnector.UpdateRank(updateRank);
                                                ranks[selectRankIndexUpdate - 1] = updateRank;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }

                                            break;
                                        }
                                    case 4:
                                        {
                                            for (int i = 1; i <= ranks.Count; i++)
                                                Console.WriteLine(i + " " + ranks[i - 1].RankName + " " + ranks[i - 1].RankLetter);
                                            Console.WriteLine("Select Rank Index");
                                            int selectRankIndexDelete = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.DeleteRank(ranks[selectRankIndexDelete - 1]);
                                                ranks.RemoveAt(selectRankIndexDelete - 1);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }

                                }
                            }
                            break;
                        }

                    //SkillCategory Case (CRUD)
                    case 5:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show SkillCategory");
                                Console.WriteLine("2 - Insert SkillCategory");
                                Console.WriteLine("3 - Update SkillCategory");
                                Console.WriteLine("4 - Delete SkillCategory");
                                int SkillCategoryOption = int.Parse(Console.ReadLine());

                                if (SkillCategoryOption == 0) break;
                                switch (SkillCategoryOption)
                                {
                                    case 1:
                                        {
                                            for (int i = 1; i <= skillCategories.Count; i++)
                                                Console.WriteLine(skillCategories[i - 1].CategoryName);
                                            break;
                                        }

                                    case 2:
                                        {
                                            SkillCategory newSkillCategory = new SkillCategory();

                                            Console.WriteLine("Enter name for new Skill-Category");
                                            newSkillCategory.CategoryID = GetNewSkillCategoryID(skillCategories);
                                            newSkillCategory.CategoryName = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.AddSkillCategory(newSkillCategory);
                                                skillCategories.Add(newSkillCategory);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }

                                            break;
                                        }

                                    case 3:
                                        {
                                            for (int i = 1; i <= skillCategories.Count; i++)
                                                Console.WriteLine(i + " " + skillCategories[i - 1].CategoryName);
                                            Console.WriteLine("Select index skill-category for update");
                                            int skillCategoryIndexUpdate = int.Parse(Console.ReadLine());

                                            SkillCategory updateSkillCategory = skillCategories[skillCategoryIndexUpdate - 1];

                                            Console.WriteLine("Print new name skill-category");
                                            updateSkillCategory.CategoryName = Console.ReadLine();

                                            try
                                            {
                                                await DatabaseConnector.UpdateSkillCategory(updateSkillCategory);
                                                skillCategories[skillCategoryIndexUpdate - 1] = updateSkillCategory;
                                                Successful();

                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }


                                            break;
                                        }

                                    case 4:
                                        {
                                            for (int i = 1; i <= skillCategories.Count; i++)
                                                Console.WriteLine(i + " " + skillCategories[i - 1].CategoryName);
                                            Console.WriteLine("Select index skill-category for delete");
                                            int skillCategoryIndexDelete = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.DeleteSkillCategory(skillCategories[skillCategoryIndexDelete - 1]);
                                                skillCategories.RemoveAt(skillCategoryIndexDelete - 1);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    //Skill Case (CRUD)
                    case 6:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Skills");
                                Console.WriteLine("2 - Insert Skill");
                                Console.WriteLine("3 - Update Skill");
                                Console.WriteLine("4 - Delete Skill");
                                int SkillOption = int.Parse(Console.ReadLine());

                                if (SkillOption == 0) break;
                                switch (SkillOption)
                                {
                                    case 1:
                                        {
                                            foreach (var skill in skills)
                                            {
                                                Console.Write(skill.SkillName + " " + skill.SkillDiscription + " ");
                                                foreach (var category in skillCategories)
                                                    if (category.CategoryID == skill.IDCategory)
                                                        Console.Write(category.CategoryName + " ");
                                                foreach (var rank in ranks)
                                                    if (rank.RankID == skill.IDRank)
                                                        Console.WriteLine(rank.RankLetter + " ");
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Skill newSkill = new Skill();
                                            newSkill.SkillID = GetNewSkillID(skills);
                                            Console.WriteLine("Input name for future skill");
                                            newSkill.SkillName = Console.ReadLine();
                                            Console.WriteLine("Input Discription for future skill");
                                            newSkill.SkillDiscription = Console.ReadLine();

                                            for (int i = 1; i <= skillCategories.Count; i++)
                                                Console.WriteLine(i + " " + skillCategories[i - 1].CategoryName);
                                            Console.WriteLine("Select category Index ");
                                            int selectCategoryIndex = int.Parse(Console.ReadLine());

                                            for (int i = 1; i <= ranks.Count; i++)
                                                Console.WriteLine(i + " " + ranks[i - 1].RankName + " - " + ranks[i - 1].RankLetter);
                                            Console.WriteLine("Select Rank Index ");
                                            int selectRankIndex = int.Parse(Console.ReadLine());

                                            newSkill.IDCategory = skillCategories[selectCategoryIndex - 1].CategoryID;
                                            newSkill.IDRank = ranks[selectRankIndex - 1].RankID;

                                            try
                                            {
                                                await DatabaseConnector.AddSkill(newSkill);
                                                skills.Add(newSkill);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }

                                            break;
                                        }
                                    case 3:
                                        {
                                            for (int i = 1; i <= skills.Count; i++)
                                                Console.WriteLine(i + " " + skills[i - 1].SkillName);
                                            Console.WriteLine("Select index skill for update");
                                            int indexSkillForUpdate = int.Parse(Console.ReadLine());

                                            Skill updateSkill = skills[indexSkillForUpdate - 1];

                                            Console.WriteLine("1 - Update Skill Name");
                                            Console.WriteLine("2 - Update Skill Discription");
                                            Console.WriteLine("3 - Update Skill Category");
                                            Console.WriteLine("4 - Update Skill Rank");
                                            Console.WriteLine("5 Update Full Skill");

                                            int updateSkillOption = int.Parse(Console.ReadLine());


                                            switch (updateSkillOption)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Input new Name");
                                                        updateSkill.SkillName = Console.ReadLine();

                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("Input new Discription");
                                                        updateSkill.SkillDiscription = Console.ReadLine();

                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        for (int i = 1; i <= skillCategories.Count; i++)
                                                            Console.WriteLine(i + " " + skillCategories[i - 1].CategoryName);
                                                        Console.WriteLine("Select new Category for skill");
                                                        int selectIndexCategory = int.Parse(Console.ReadLine());

                                                        //можно было бы сделать чтобы была возможность добавить сразу новый

                                                        updateSkill.IDCategory = skillCategories[selectIndexCategory - 1].CategoryID;

                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        for (int i = 1; i <= ranks.Count; i++)
                                                            Console.WriteLine(i + " " + ranks[i - 1].RankName);
                                                        Console.WriteLine("Select new Rank for skill");
                                                        int selectIndexRank = int.Parse(Console.ReadLine());

                                                        //можно было бы сделать чтобы была возможность добавить сразу новый

                                                        updateSkill.IDRank = ranks[selectIndexRank - 1].RankID;

                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        Console.WriteLine("Input new Name");
                                                        updateSkill.SkillName = Console.ReadLine();

                                                        Console.WriteLine("Input new Discription");
                                                        updateSkill.SkillDiscription = Console.ReadLine();

                                                        for (int i = 1; i <= skillCategories.Count; i++)
                                                            Console.WriteLine(i + " " + skillCategories[i - 1].CategoryName);
                                                        Console.WriteLine("Select new Category for skill");
                                                        int selectIndexCategory = int.Parse(Console.ReadLine());
                                                        updateSkill.IDCategory = skillCategories[selectIndexCategory - 1].CategoryID;

                                                        for (int i = 1; i <= ranks.Count; i++)
                                                            Console.WriteLine(i + " " + ranks[i - 1].RankName);
                                                        Console.WriteLine("Select new Rank for skill");
                                                        int selectIndexRank = int.Parse(Console.ReadLine());
                                                        updateSkill.IDRank = ranks[selectIndexRank - 1].RankID;

                                                        break;
                                                    }


                                            }
                                            try
                                            {
                                                await DatabaseConnector.UpdateSkill(updateSkill);
                                                skills[indexSkillForUpdate - 1] = updateSkill;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            for (int i = 1; i <= skills.Count; i++)
                                                Console.WriteLine(i + " " + skills[i - 1].SkillName);
                                            Console.WriteLine("Select index skill for delete this skill");
                                            int deleteIndexSkill = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.DeleteSkill(skills[deleteIndexSkill - 1]);
                                                skills.RemoveAt(deleteIndexSkill - 1);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }


                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    //NinjaSkills Case (CRUD) //Отстутствует Update, поскольку -_- а что обновлять вообще
                    case 7:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Ninja with skills");
                                Console.WriteLine("2 - Insert new skill for Ninja");
                                Console.WriteLine("3 - Delete skill for Ninja");
                                int ninjaSkillOption = int.Parse(Console.ReadLine());

                                if (ninjaSkillOption == 0) break;
                                switch (ninjaSkillOption)
                                {
                                    case 1:
                                        {
                                            foreach (var ninja in ninjas)
                                            {


                                                var ninjaSkillIDs = ninjaSkills.Where(ns => ns.IDNinja == ninja.NinjaID).Select(ns => ns.IDSkill);

                                                var ninjaSkillsList = skills.Where(s => ninjaSkillIDs.Contains(s.SkillID)).Select(s => s.SkillName);
                                                if (ninjaSkillsList.Count() > 0)
                                                {
                                                    Console.WriteLine(ninja.NinjaName);

                                                    foreach (var skill in ninjaSkillsList)
                                                    {
                                                        Console.WriteLine(skill);
                                                    }

                                                    Console.WriteLine();
                                                }
                                            }


                                            break;
                                        }
                                    case 2:
                                        {
                                            NinjaSkills ninjaSkill = new NinjaSkills();
                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + " - " + ninjas[i - 1].NinjaName);
                                            Console.WriteLine("Select ninja for insert skill");
                                            ninjaSkill.IDNinja = int.Parse(Console.ReadLine());

                                            for (int i = 1; i <= skills.Count; i++)
                                                Console.WriteLine(i + " - " + skills[i - 1].SkillName);
                                            Console.WriteLine("Select skill for insert skill");
                                            ninjaSkill.IDSkill = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.AddNinjaSkill(ninjaSkill);
                                                ninjaSkills.Add(ninjaSkill);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {


                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + " - " + ninjas[i - 1].NinjaName);
                                            Console.WriteLine("Select ninja for delete skill");
                                            int indexNinja = int.Parse(Console.ReadLine());
                                            Ninja ninja = ninjas[indexNinja - 1];

                                            var ninjaSkillIDs = ninjaSkills.Where(ns => ns.IDNinja == ninja.NinjaID).Select(ns => ns.IDSkill);

                                            var ninjaSkillsList = skills.Where(s => ninjaSkillIDs.Contains(s.SkillID)).ToList();
                                            Console.WriteLine(ninja.NinjaName);
                                            if (ninjaSkillsList.Count() > 0)
                                            {
                                                for (int i = 1; i <= ninjaSkillsList.Count(); i++)
                                                {
                                                    Console.WriteLine(i + " - " + ninjaSkillsList.ElementAt(i - 1).SkillName);
                                                }
                                                Console.WriteLine("Select index delete skill");
                                                int indexSkillDelete = int.Parse(Console.ReadLine());

                                                NinjaSkills delNinjaSkills = new NinjaSkills();
                                                delNinjaSkills.IDNinja = ninja.NinjaID;
                                                delNinjaSkills.IDSkill = ninjaSkillsList.ElementAt(indexSkillDelete - 1).SkillID;
                                                try
                                                {
                                                    await DatabaseConnector.DeleteNinjaSkill(delNinjaSkills);
                                                    ninjaSkills.Remove(delNinjaSkills);
                                                    Successful();
                                                }
                                                catch (Exception)
                                                {
                                                    UnSuccessful();
                                                }
                                            }
                                            else
                                                Console.WriteLine(ninja.NinjaName + " do not have skills");
                                            break;
                                        }
                                }
                            }


                            break;
                        }

                    //Battle Case (CRUD)
                    case 8:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Battles");
                                Console.WriteLine("2 - Insert Battle");
                                Console.WriteLine("3 - Update Battle");
                                Console.WriteLine("4 - Delete Battle");
                                int battleOption = int.Parse(Console.ReadLine());

                                if (battleOption == 0) break;
                                switch (battleOption)
                                {
                                    case 1:
                                        {
                                            foreach(var battle in battles)
                                                Console.WriteLine(battle.BattleName);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Battle newBattle = new Battle();

                                            newBattle.BattleID = GetNewBattleID(battles);
                                            Console.WriteLine("Enter name for new Battle");
                                            newBattle.BattleName = Console.ReadLine();
                                            Console.WriteLine("Write Discription for this battle");
                                            newBattle.BattleDiscription = Console.ReadLine();

                                            for(int i = 1; i <= villages.Count; i++)
                                                Console.WriteLine(i + " " + villages[i - 1].VillageName);
                                            Console.WriteLine("Select index village");
                                            int indexVillageForInsert = int.Parse(Console.ReadLine());
                                            newBattle.IDVillage = villages[indexVillageForInsert - 1].VillageID;

                                            try
                                            {
                                                await DatabaseConnector.AddBattle(newBattle);
                                                battles.Add(newBattle);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                                throw;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            for (int i = 1; i <= battles.Count; i++)
                                            {
                                                Console.Write(i + " " + battles[i - 1].BattleName + " " + battles[i - 1].BattleDiscription + " ");
                                                foreach(var village in villages)
                                                    if(village.VillageID == battles[i -1].IDVillage)
                                                        Console.WriteLine(village.VillageName);
                                            }
                                            Console.WriteLine("Select battle index for update");
                                            int battleIndexUpdate = int.Parse(Console.ReadLine());
                                            Battle updateBattle = battles[battleIndexUpdate - 1];

                                            Console.WriteLine("1 - Update Name");
                                            Console.WriteLine("2 - Update Discription");
                                            Console.WriteLine("3 - Update Village");
                                            Console.WriteLine("4 - Full Update");
                                            int battleOptionUpdate = int.Parse(Console.ReadLine());

                                            switch (battleOptionUpdate)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Print new name");
                                                        updateBattle.BattleName = Console.ReadLine();

                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("Write new Discription");
                                                        updateBattle.BattleDiscription = Console.ReadLine();

                                                        break;
                                                    }
                                                case 3:
                                                    {

                                                        for(int i = 1; i <= villages.Count; i++)
                                                            Console.WriteLine(i + " " + villages[i -1].VillageName);
                                                        Console.WriteLine("Select new index village");
                                                        int newVillage = int.Parse(Console.ReadLine());

                                                        updateBattle.IDVillage = villages[newVillage - 1].VillageID;

                                                        break;
                                                    }
                                               case 4:
                                                    {
                                                        Console.WriteLine("Print new name");
                                                        updateBattle.BattleName = Console.ReadLine();
                                                        Console.WriteLine("Write new Discription");
                                                        updateBattle.BattleDiscription = Console.ReadLine();
                                                        for (int i = 1; i <= villages.Count; i++)
                                                            Console.WriteLine(i + " " + villages[i - 1].VillageName);
                                                        Console.WriteLine("Select new index village");
                                                        int newVillage = int.Parse(Console.ReadLine());

                                                        updateBattle.IDVillage = villages[newVillage - 1].VillageID;

                                                        break;
                                                    }
                                            }

                                            try
                                            {
                                                await DatabaseConnector.UpdateBattle(updateBattle);
                                                battles[battleIndexUpdate - 1] = updateBattle;
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }


                                            break;
                                        }
                                    case 4:
                                        {

                                            for (int i = 1; i <= battles.Count; i++)
                                            {
                                                Console.Write(i + " " + battles[i - 1].BattleName + " " + battles[i - 1].BattleDiscription + " ");
                                                foreach (var village in villages)
                                                    if (village.VillageID == battles[i - 1].IDVillage)
                                                        Console.WriteLine(village.VillageName);
                                            }
                                            Console.WriteLine("Select battle index for update");
                                            int battleIndexDelete = int.Parse(Console.ReadLine());
                                            Battle deleteBattle = battles[battleIndexDelete - 1];

                                            try
                                            {
                                                await DatabaseConnector.DeleteBattle(deleteBattle);
                                                battles.Remove(deleteBattle);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                }
                            }

                            break;
                        }

                    //NinjaBattles Case (CRUD)
                    case 9:
                        {
                            while (true)
                            {
                                Console.WriteLine("0 - Return");
                                Console.WriteLine("1 - Show Ninja with Battle");
                                Console.WriteLine("2 - Insert new battle for Ninja");
                                Console.WriteLine("3 - Delete battle for Ninja");
                                int ninjaBattleOption = int.Parse(Console.ReadLine());

                                if (ninjaBattleOption == 0) break;
                                switch (ninjaBattleOption)
                                {
                                    case 1:
                                        {
                                            foreach (var ninja in ninjas)
                                            {


                                                var ninjaBattleIDs = ninjaBattles.Where(ns => ns.IDNinja == ninja.NinjaID).Select(ns => ns.IDBattle);

                                                var ninjaBattlesList = battles.Where(s => ninjaBattleIDs.Contains(s.BattleID));
                                                if (ninjaBattlesList.Count() > 0)
                                                {
                                                    Console.WriteLine(ninja.NinjaName);

                                                    foreach (var battle in ninjaBattlesList)
                                                    {
                                                        Console.WriteLine(battle.BattleName);
                                                    }

                                                    Console.WriteLine();
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            NinjaBattles ninjaBattle = new NinjaBattles();
                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + " - " + ninjas[i - 1].NinjaName);
                                            Console.WriteLine("Select ninja for insert battle");
                                            ninjaBattle.IDNinja = int.Parse(Console.ReadLine());

                                            for (int i = 1; i <= battles.Count; i++)
                                                Console.WriteLine(i + " - " + battles[i - 1].BattleName);
                                            Console.WriteLine("Select battle for insert battle");
                                            ninjaBattle.IDBattle = int.Parse(Console.ReadLine());

                                            try
                                            {
                                                await DatabaseConnector.AddNinjaBattle(ninjaBattle);
                                                ninjaBattles.Add(ninjaBattle);
                                                Successful();
                                            }
                                            catch (Exception)
                                            {
                                                UnSuccessful();
                                            }
                                            break;
                                        }
                                    case 3:
                                        {

                                            for (int i = 1; i <= ninjas.Count; i++)
                                                Console.WriteLine(i + " - " + ninjas[i - 1].NinjaName);
                                            Console.WriteLine("Select ninja for delete battle");
                                            int indexNinja = int.Parse(Console.ReadLine());
                                            Ninja ninja = ninjas[indexNinja - 1];

                                            var ninjaBattleIDs = ninjaBattles.Where(ns => ns.IDNinja == ninja.NinjaID).Select(ns => ns.IDBattle);

                                            var ninjaBattlesList = battles.Where(s => ninjaBattleIDs.Contains(s.BattleID)).ToList();
                                            Console.WriteLine(ninja.NinjaName);
                                            if (ninjaBattlesList.Count() > 0)
                                            {
                                                for (int i = 1; i <= ninjaBattlesList.Count(); i++)
                                                {
                                                    Console.WriteLine(i + " - " + ninjaBattlesList.ElementAt(i - 1).BattleName);
                                                }
                                                Console.WriteLine("Select index delete battle");
                                                int indexBattleDelete = int.Parse(Console.ReadLine());

                                                NinjaBattles delNinjaBattles = new NinjaBattles();
                                                delNinjaBattles.IDNinja = ninja.NinjaID;
                                                delNinjaBattles.IDBattle = ninjaBattlesList.ElementAt(indexBattleDelete - 1).BattleID;
                                                try
                                                {
                                                    await DatabaseConnector.DeleteNinjaBattle(delNinjaBattles);
                                                    ninjaBattles.Remove(delNinjaBattles);
                                                    Successful();
                                                }
                                                catch (Exception)
                                                {
                                                    UnSuccessful();
                                                }
                                            }
                                            else
                                                Console.WriteLine(ninja.NinjaName + " do not have battles");
                                            break;
                                        }
                                }
                            }

                                        break;
                        }
                }
            }

            Console.WriteLine("Close");
        }
    }
}
