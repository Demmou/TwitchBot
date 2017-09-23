using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    class RPGUser
    {
        private string RPGName;
        private int Life;
        private int angriff;
        private int verteidigung;
        private Level level;
        private Inventory inventar;

        public RPGUser(string username, int life, int angriff, int verteidigung)
        {
            this.RPGName = username;
            this.Life = life;
            this.angriff = angriff;
            this.verteidigung = verteidigung;
            this.level = new Level(username);
        }

        public int getAttack()
        {
            int totalAtk = inventar.getTotalAtkOfItems() + this.angriff;
            return totalAtk;
        }
        public int getLife() { return this.Life; }
        public string getInventoryItemNames()
        {
            List<string> names = new List<string>();
            names = inventar.getNameOfAllItems();
            string itemNameStr = "";
            foreach(var name in names)
            {
                itemNameStr += name + " ";
            }
            return itemNameStr;
        }
        public void addLife(int value)
        {
            this.Life += value;
        }

        public void updateUser()
        {

        }

    }
}
