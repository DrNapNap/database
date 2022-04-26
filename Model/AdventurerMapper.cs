using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace database
{
    public class AdventurerMapper : IAdventurerMapper
    {
        public List<Character> MapCharactersFromReader(SQLiteDataReader reader)
        {
            var result = new List<Character>();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var xp = reader.GetInt32(0);

                result.Add(new Character() { Id = id, Buget  = xp });
            }
            return result;
        }

    }
}
