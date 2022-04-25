using System;
using System.Data;

namespace database
{
    public class Reading 
    {

        private readonly IDatabaseProvider provider;

        private IDbConnection connection;

        public Reading(IDatabaseProvider provider)
        {
            this.provider = provider;

        }

        private void CreateDatabaseTables()
        {
            var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS characters (Id INTEGER PRIMARY KEY, Name VARCHAR(50), Experience INTEGER);", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();
        }



        public event Action <int> OnActualUpdate;
        private int actluel;


        public int Actluel { get { return actluel; } set { actluel = value; PostActuaalUdated(); } }




        private void PostActuaalUdated ()
        {
            OnActualUpdate?.Invoke(GetVariance());
        }


        public int GetVariance()
        {
            if (Actluel % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public VarianceCategory GetVarianceCategory()
        {
            if (GetVariance() == 0)
            {
                return VarianceCategory.Normal;
            }
           else
            {
                return VarianceCategory.Severe;
            }

        }

    }
}
