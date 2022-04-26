using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace database
{
    public class Reading : IAdventurerRepository
    {

        private readonly IDatabaseProvider provider;
        private readonly IAdventurerMapper mapper;
        private IDbConnection connection;

        public Reading(IDatabaseProvider provider, IAdventurerMapper mapper)
        {
            this.provider = provider;
            this.mapper = mapper;
        }

        public void CreateDatabaseTables()
        {

            //CREATE TABLE IF NOT EXISTS 
            var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS administrator (Id INTEGER PRIMARY KEY, Buget VARCHAR(50));", (SQLiteConnection)connection);
            var cmdd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS tournament (tournamentName TINYTEXT, country TINYTEXT, amountofteam VARCHAR(30), money VARCHAR(50));", (SQLiteConnection)connection);



            cmdd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();



            ////DELETE
            //var cmdd = new SQLiteCommand($"DELETE FROM characters;", (SQLiteConnection)connection);

            //cmdd.ExecuteNonQuery();


        }
        public void AddTornament(string tournamentName, string Country, int amountofteam, int money)
        {
            var cmd = new SQLiteCommand($"INSERT INTO tournament (tournamentName,country,amountofteam,money) VALUES ('{tournamentName}', '{Country}',{amountofteam},{money})", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();
        }

        public void AddAdmin(int Buget)
        {
            var cmd = new SQLiteCommand($"INSERT INTO administrator ( Buget) VALUES ({Buget})", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();
        }



        public List<Character> GetAllAdmin()
        {
            var cmd = new SQLiteCommand($"SELECT  * from administrator", (SQLiteConnection)connection);

            var reader = cmd.ExecuteReader();

            var result = mapper.MapCharactersFromReader(reader);
            return result;

        }






 





        public void Open()
        {

            if (connection == null)
            {
                connection = provider.CreateConnection();
            }
            connection.Open();

            CreateDatabaseTables();
        }

        public void Close()
        {
            connection.Close();
        }


    }
}
