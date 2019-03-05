using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class PlayerInfo
    {
        public string PlayerName { get; set; }

        public TeamInfo PlayerTeam { get; set; }

        public string PlayerPosition { get; set; }

        public IEnumerable<PlayerStat> PlayerStats { get; set; }
    }

    public class PlayerStat 
    {
        public string StatName { get; set; }

        public int StatValue { get; set; }
    }
}