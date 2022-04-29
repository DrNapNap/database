

using database;

namespace UserInterface
{
    class SCommand : ICommand
    {
        public void Execute(Player player)
        {

            var mapper = new AdventurerMapper();
            var provider = new SQLiteDatabaseProvider("Data Source=cyklingmanager.db;Version=3;new=true");

            var repo = new Reading(provider, mapper);
            repo.Open();

            repo.AddTornament("Tour De France", "Frankrig", 50, 2000000000);
            repo.AddTornament("Danmark rundt", "Danmark", 30, 500000 );
            repo.AddTornament("Giro d’Italia", "Italien", 50, 1500000000);

            repo.Close();
        }

    }
}
