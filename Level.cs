using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwitchBot
{
    class Level
    {
        // List goes from level 1 to 50
        private string username = "";
        private static List<int> levelExpRequired = new List<int>(new int[] { -1,0,83, 174, 276, 388, 512, 650, 801, 969, 1154, 1358,
                                                                              1584, 1833, 2107, 2411, 2746, 3115, 3523, 3973,
                                                                              4470,5018, 5624, 6291, 7028, 7842, 8740, 9730, 10824,
                                                                              12031, 13363, 14833, 16456, 18247, 20224, 22406, 30408,
                                                                              33648, 37224, 41171, 45529, 50339, 55649, 61512, 67993,
                                                                              75127, 83014, 91721, 101333 });

        private int experience;
        private int level = 0;


        public Level(string username)
        {
            this.username = username;
            this.experience = Database.GetExperience(username);
            getLevelFromExperience();

        }
        // adds experience to the current amount
        public void addExperience(int exp) {
            this.experience += exp;
            if (checkLevelUp()) this.level++;
            Database.AddExperience(username, exp);
        }
        // Checks if user has enough exp to level up
        public bool checkLevelUp()
        {
            if (this.experience > levelExpRequired[this.level + 1])
            {
                return true;
            }
            return false;
        }
        // Returns number of EXP required to hit next level
        public int getExpToNextLevel()
        {
            if (this.level == 50)
                return 0;
            return (levelExpRequired[level] - this.experience);
        }
        // Sets User level from Experience entry in Database
        private void getLevelFromExperience()
        {
            for (int i = 0; i < levelExpRequired.Count;i++)
            {
                if (this.experience >= levelExpRequired[i] && this.experience < levelExpRequired[i+1]) this.level = i;
            }
        }

        public int getLevel() { return this.level; }
        public int getExperience() { return this.experience; }

    }
}
