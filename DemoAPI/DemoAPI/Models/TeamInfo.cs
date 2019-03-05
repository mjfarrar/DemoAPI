using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class TeamInfo
    {   
        public string TeamName { get; set; }

        public SportInfo TeamSport { get; set; }
    }
}