using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    class Inventory
    {
        private List<RPGItem> inventory;

        public Inventory()
        {
            this.inventory = new List<RPGItem>();
        }

        public void addItem(string username, RPGItem item)
        {
            if (this.inventory.Count == 6) return;
            this.inventory.Add(item);
        }
        public void removeItem(string username, RPGItem item)
        {
            foreach(RPGItem checkItem in inventory)
            {
                if (checkItem == item)
                    inventory.Remove(item);

            }
        }


        public int getTotalAtkOfItems()
        {
            int total = 0;
            foreach (RPGItem item in inventory)
            {
                total += item.getAtkValue();
            }
            return total;
        }
        public int getTotalDefOfItems()
        {
            int total = 0;
            foreach (RPGItem item in inventory)
            {
                total += item.getDefValue();
            }
            return total;
        }
        public int getTotalLifeOfItems()
        {
            int total = 0;
            foreach (RPGItem item in inventory)
            {
                total += item.getLifeValue();
            }
            return total;
        }

        public string getNameOfItem(RPGItem item) { return item.getName(); }
        public List<string> getNameOfAllItems()
        {
            List<string> namesOfItems = new List<string>();
            foreach (RPGItem item in inventory)
            {
                namesOfItems.Add(item.getName());
            }
            return namesOfItems;
        }
    }
}
