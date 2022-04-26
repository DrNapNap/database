using System;
using System.Collections.Generic;
using System.Text;

namespace database
{
   public interface IAdventurerRepository
    {
        void AddCharacter(int experience);
        //Character FindCharacter(string name);
        List<Character> GetAllAdmin();
        void Open();

        void Close();
    }
}
