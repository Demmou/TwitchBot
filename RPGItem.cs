using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    class RPGItem
    {
        private string name = "";
        private int atkValue;
        private int defValue;
        private int lifeValue;

        public RPGItem(int atk, int def, int life)
        {
            this.atkValue = atk;
            this.defValue = def;
            this.lifeValue = life;
        }
        public static bool operator ==(RPGItem item1, RPGItem item2)
        {
            if (item1.name == item2.name)
                return true;
            return false;
        }
        public static bool operator !=(RPGItem item1, RPGItem item2)
        {

            return true;
        }

        public int getAtkValue() { return this.atkValue; }
        public int getDefValue() { return this.defValue; }
        public int getLifeValue() { return this.lifeValue; }
        public string getName() { return this.name; }
        private static void initializeItems(Dictionary<string,RPGItem> itemDict)
        {
            itemDict.Add("schwert", new RPGItem(5, 0, 10));
            itemDict.Add("mastersword", new RPGItem(25, 5, 15));
            itemDict.Add("bogen", new RPGItem(8, 0, 7));

            itemDict.Add("stoffrüstung", new RPGItem(0, 10, 25));
            itemDict.Add("lederrüstung", new RPGItem(0, 18, 35));
            itemDict.Add("plattenrüstung", new RPGItem(0, 25, 45));

            return;
        }
    }
}
