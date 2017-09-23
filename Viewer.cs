using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    class Viewer
    {
        private string username;
        private int points;
        private int minutesWatched;
        private RPGUser user;
        
        public Viewer(string username, int points, int minuteswatched, int experience)
        {
            this.username = username;
            this.points = points;
            this.minutesWatched = minuteswatched;
        }

        public void createRPGUser()
        {
            user = new RPGUser(this.username, 100,10,10);
        }

    }
}
