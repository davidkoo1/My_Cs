using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaWiki
{
    public static class DatabaseConnector
    {
        private static readonly string ConnectionStr = @"Data Source=DESKTOP-IQ404L4;Initial Catalog=Ninja;Integrated Security=true;";

        public static async Task<List<Ninja>> GetNinjas()
        {
            List<Ninja> ninjas = new List<Ninja>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();
                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "SELECT * FROM Ninja";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = await command.ExecuteReaderAsync();
                while (await dataReader.ReadAsync())
                {
                    Ninja ninja = new Ninja
                    {
                        NinjaID = dataReader.GetInt32(0),
                        NinjaName = dataReader.GetString(1),
                        IDClan = dataReader.GetInt32(2),
                        IDVillage = dataReader.GetInt32(3),
                        IDRank = dataReader.GetInt32(4),
                        Traitor = dataReader.GetBoolean(5)
                    };

                    ninjas.Add(ninja);
                }



            }

            return ninjas;
        }

        public static async Task AddNinja(Ninja newNinja)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Ninja VALUES (@NinjaID, @NinjaName, @IDClan, @IDVillage, @IDRank, @Traitor)"; //функцию бы использовать sql которая

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NinjaID", newNinja.NinjaID);
                    command.Parameters.AddWithValue("@NinjaName", newNinja.NinjaName);
                    command.Parameters.AddWithValue("@IDClan", newNinja.IDClan);
                    command.Parameters.AddWithValue("@IDVillage", newNinja.IDVillage);
                    command.Parameters.AddWithValue("@IDRank", newNinja.IDRank);
                    command.Parameters.AddWithValue("@Traitor", newNinja.Traitor);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateNinja(Ninja upadeNinja)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Ninja SET NinjaName = @NinjaName, IDClan = @IDClan, IDVillage = @IDVillage, IDRank = @IDRank, Traitor = @Traitor WHERE NinjaID = @NinjaID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NinjaID", upadeNinja.NinjaID);
                    command.Parameters.AddWithValue("@NinjaName", upadeNinja.NinjaName);
                    command.Parameters.AddWithValue("@IDClan", upadeNinja.IDClan);
                    command.Parameters.AddWithValue("@IDVillage", upadeNinja.IDVillage);
                    command.Parameters.AddWithValue("@IDRank", upadeNinja.IDRank);
                    command.Parameters.AddWithValue("@Traitor", upadeNinja.Traitor);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteNinja(Ninja delNinja)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Ninja WHERE NinjaID = @NinjaID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NinjaID", delNinja.NinjaID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        
        ///////

        public static async Task<List<Clan>> GetClans()
        {
            List<Clan> clans = new List<Clan>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM Clan";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Clan clan = new Clan
                    {
                        ClanID = dataReader.GetInt32(0),
                        ClanName = dataReader.GetString(1),
                        ClanDiscription = dataReader.GetString(2)

                    };

                    clans.Add(clan);
                }
            }

            return clans;

        }

        public static async Task AddClan(Clan newClan)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Clan VALUES (@ClanID, @ClanName, @ClanDiscription)"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClanID", newClan.ClanID);
                    command.Parameters.AddWithValue("@ClanName", newClan.ClanName);
                    command.Parameters.AddWithValue("@ClanDiscription", newClan.ClanDiscription);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateClan(Clan upadeClan)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Clan SET ClanName = @ClanName, ClanDiscription = @ClanDiscription WHERE ClanID = @ClanID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClanID", upadeClan.ClanID); //Возможно это действие лишнее
                    command.Parameters.AddWithValue("@ClanName", upadeClan.ClanName);
                    command.Parameters.AddWithValue("@ClanDiscription", upadeClan.ClanDiscription);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteClan(Clan delClan)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Clan WHERE ClanID = @ClanID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClanID", delClan.ClanID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //////////////

        public static async Task<List<Village>> GetVillages()
        {
            List<Village> villages = new List<Village>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM Village";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Village village = new Village
                    {
                        VillageID = dataReader.GetInt32(0),
                        VillageName = dataReader.GetString(1),
                        
                    };

                    villages.Add(village);
                }
            }

            return villages;

        }

        public static async Task AddVillage(Village newVillage)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Village VALUES (@VillageID, @VillageName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VillageID", newVillage.VillageID);
                    command.Parameters.AddWithValue("@VillageName", newVillage.VillageName);
                    


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateVillage(Village upadeVillage)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Village SET VillageName = @VillageName  WHERE VillageID = @VillageID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VillageID", upadeVillage.VillageID); //Возможно это действие лишнее
                    command.Parameters.AddWithValue("@VillageName", upadeVillage.VillageName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteVillage(Village delVillage)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Village WHERE VillageID = @VillageID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VillageID", delVillage.VillageID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        ///////////

        public static async Task<List<Rank>> GetRanks()
        {
            List<Rank> ranks = new List<Rank>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM Rank";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Rank rank = new Rank
                    {
                        RankID = dataReader.GetInt32(0),
                        RankName = dataReader.GetString(1),
                        RankLetter = dataReader.GetString(2),

                    };

                    ranks.Add(rank);
                }
            }

            return ranks;

        }

        public static async Task AddRank(Rank newRank)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Rank VALUES (@RankID, @RankName, @RankLetter)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RankID", newRank.RankID);
                    command.Parameters.AddWithValue("@RankName", newRank.RankName);
                    command.Parameters.AddWithValue("@RankLetter", newRank.RankLetter);



                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateRank(Rank upadeRank)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Rank SET RankName = @RankName, RankLetter = @RankLetter WHERE RankID = @RankID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RankID", upadeRank.RankID); 
                    command.Parameters.AddWithValue("@RankName", upadeRank.RankName);
                    command.Parameters.AddWithValue("@RankLetter", upadeRank.RankLetter);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteRank(Rank delRank)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Rank WHERE RankID = @RankID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RankID", delRank.RankID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //////////

        public static async Task<List<SkillCategory>> GetSkillCategories()
        {
            List<SkillCategory> skillCategories = new List<SkillCategory>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM SkillCategory";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    SkillCategory skillCategory = new SkillCategory
                    {
                        CategoryID = dataReader.GetInt32(0),
                        CategoryName = dataReader.GetString(1),

                    };

                    skillCategories.Add(skillCategory);
                }
            }

            return skillCategories;

        }

        public static async Task AddSkillCategory(SkillCategory newSkillCategory)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO SkillCategory VALUES (@CategoryID, @CategoryName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", newSkillCategory.CategoryID);
                    command.Parameters.AddWithValue("@CategoryName", newSkillCategory.CategoryName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateSkillCategory(SkillCategory upadeSkillCategory)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE SkillCategory SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", upadeSkillCategory.CategoryID);
                    command.Parameters.AddWithValue("@CategoryName", upadeSkillCategory.CategoryName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteSkillCategory(SkillCategory delSkillCategory)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM SkillCategory WHERE CategoryID = @CategoryID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", delSkillCategory.CategoryID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        ///////////////

        public static async Task<List<Skill>> GetSkills()
        {
            List<Skill> skills = new List<Skill>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM Skill";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Skill skill = new Skill
                    {
                        SkillID = dataReader.GetInt32(0),
                        SkillName = dataReader.GetString(1),
                        SkillDiscription = dataReader.GetString(2),
                        IDCategory = dataReader.GetInt32(3),
                        IDRank = dataReader.GetInt32(4),

                    };

                    skills.Add(skill);
                }
            }

            return skills;

        }

        public static async Task AddSkill(Skill newSkill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Skill VALUES (@SkillID, @SkillName, @SkillDiscription, @IDCategory, @IDRank)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {    
                    
                    command.Parameters.AddWithValue("@SkillID", newSkill.SkillID);
                    command.Parameters.AddWithValue("@SkillName", newSkill.SkillName);
                    command.Parameters.AddWithValue("@SkillDiscription", newSkill.SkillDiscription);
                    command.Parameters.AddWithValue("@IDCategory", newSkill.IDCategory);
                    command.Parameters.AddWithValue("@IDRank", newSkill.IDRank);
 

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateSkill(Skill upadeSkill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Skill SET SkillName = @SkillName, SkillDiscription = @SkillDiscription, IDCategory = @IDCategory, IDRank = @IDRank WHERE SkillID = @SkillID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@SkillID", upadeSkill.SkillID);
                    command.Parameters.AddWithValue("@SkillName", upadeSkill.SkillName);
                    command.Parameters.AddWithValue("@SkillDiscription", upadeSkill.SkillDiscription);
                    command.Parameters.AddWithValue("@IDCategory", upadeSkill.IDCategory);
                    command.Parameters.AddWithValue("@IDRank", upadeSkill.IDRank);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteSkill(Skill delSkill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Skill WHERE SkillID = @SkillID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SkillID", delSkill.SkillID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //////////

        public static async Task<List<NinjaSkills>> GetSkillsNinja()
        {
            List<NinjaSkills> ninjaSkills = new List<NinjaSkills>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM NinjaSkills";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    NinjaSkills ninjaSkill = new NinjaSkills
                    {
                        IDNinja = dataReader.GetInt32(0),
                        IDSkill = dataReader.GetInt32(1),
                        

                    };

                    ninjaSkills.Add(ninjaSkill);
                }
            }

            return ninjaSkills;

        }

        public static async Task AddNinjaSkill(NinjaSkills newSkill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO NinjaSkills VALUES (@IDNinja, @IDSkill)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@IDNinja", newSkill.IDNinja);
                    command.Parameters.AddWithValue("@IDSkill", newSkill.IDSkill);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteNinjaSkill(NinjaSkills delSkill)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM NinjaSkills WHERE IDNinja = @IDNinja AND IDSkill = @IDSkill";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDNinja", delSkill.IDNinja);
                    command.Parameters.AddWithValue("@IDSkill", delSkill.IDSkill);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /////////

        public static async Task<List<Battle>> GetBattles()
        {
            List<Battle> battles = new List<Battle>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM Battle";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Battle battle = new Battle
                    {
                        BattleID = dataReader.GetInt32(0),
                        BattleName = dataReader.GetString(1),
                        BattleDiscription = dataReader.GetString(2),
                        IDVillage = dataReader.GetInt32(3)
                        

                    };

                    battles.Add(battle);
                }
            }

            return battles;

        }

        public static async Task AddBattle(Battle newBattle)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO Battle VALUES (@BattleID, @BattleName, @BattleDiscription, @IDVillage)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BattleID", newBattle.BattleID);
                    command.Parameters.AddWithValue("@BattleName", newBattle.BattleName);
                    command.Parameters.AddWithValue("@BattleDiscription", newBattle.BattleDiscription);
                    command.Parameters.AddWithValue("@IDVillage", newBattle.IDVillage);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task UpdateBattle(Battle upadeBattle)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "UPDATE Battle SET BattleName = @BattleName, BattleDiscription = @BattleDiscription, IDVillage = @IDVillage WHERE BattleID = @BattleID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BattleID", upadeBattle.BattleID);
                    command.Parameters.AddWithValue("@BattleName", upadeBattle.BattleName);
                    command.Parameters.AddWithValue("@BattleDiscription", upadeBattle.BattleDiscription);
                    command.Parameters.AddWithValue("@IDVillage", upadeBattle.IDVillage);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteBattle(Battle delBattle)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM Battle WHERE BattleID = @BattleID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BattleID", delBattle.BattleID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        ////////////

        public static async Task<List<NinjaBattles>> GetBattlesNinja()
        {
            List<NinjaBattles> ninjaBattles = new List<NinjaBattles>();

            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                await connection.OpenAsync();

                string GetSqlCommand = "SELECT * FROM NinjaBattles";
                SqlCommand command = new SqlCommand(GetSqlCommand, connection);
                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    NinjaBattles ninjaBattle = new NinjaBattles
                    {
                        IDNinja = dataReader.GetInt32(0),
                        IDBattle = dataReader.GetInt32(1),


                    };

                    ninjaBattles.Add(ninjaBattle);
                }
            }

            return ninjaBattles;

        }

        public static async Task AddNinjaBattle(NinjaBattles newBattle)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                String query = "INSERT INTO NinjaBattles VALUES (@IDNinja, @IDBattle)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@IDNinja", newBattle.IDNinja);
                    command.Parameters.AddWithValue("@IDBattle", newBattle.IDBattle);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task DeleteNinjaBattle(NinjaBattles delBattle)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStr))
            {
                string query = "DELETE FROM NinjaBattles WHERE IDNinja = @IDNinja AND IDBattle = @IDBattle";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDNinja", delBattle.IDNinja);
                    command.Parameters.AddWithValue("@IDBattle", delBattle.IDBattle);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }

}
