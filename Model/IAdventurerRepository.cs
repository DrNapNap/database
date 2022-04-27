using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
   public interface IAdventurerRepository
    {
        void AddAdmin(int buget);

        void AddTornament(string tournamentName, string country, int amountOfTeam, int money, int teamCVRnumber);

        void AddTeam(string teamsName, int cvrNumber, int administratorId);

        void AddRider(int cprNumber, string firstName, string lastName, int abilities, int power, int endurance, int speed, int price, int teamCVRnumber);

        //Character FindCharacter(string name);
        List<Character> GetAllAdmin();
        void Open();

        void Close();
    }
}
