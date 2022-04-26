using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
   public interface IAdventurerRepository
    {
        void AddAdmin(int experience);
        void AddTornament(string tournamentName , string country, int amountofteam, int money);

        
        //Character FindCharacter(string name);
        List<Character> GetAllAdmin();
        void Open();

        void Close();
    }
}
