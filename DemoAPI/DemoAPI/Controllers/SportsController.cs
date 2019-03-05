using DemoAPI.Models;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class SportsController : ApiController
    {
        [HttpGet]
        [Route("GetSports")]
        public IHttpActionResult GetAllSports() 
        {
            SportInfo sportOne = new SportInfo() 
            { 
                SportName = "Football"
            };

            List<SportInfo> sports = new List<SportInfo>();
            sports.Add(sportOne);

            return Ok(sports);
        }

        [HttpGet]
        public IHttpActionResult GetAllTeams() 
        {
            TeamInfo teamOne = new TeamInfo()
            {
                TeamName = "Team One",
                TeamSport = new SportInfo() 
                {
                    SportName = "Football"
                }
            }; 
            
            TeamInfo teamTwo = new TeamInfo()
            {
                TeamName = "Team Two",
                TeamSport = new SportInfo()
                {
                    SportName = "Football"
                }
            };

            List<TeamInfo> teams = new List<TeamInfo>();
            teams.Add(teamOne);
            teams.Add(teamTwo);

            return Ok(teams);
        }

        [HttpGet]
        public IHttpActionResult GetPlayersByTeam(string sportName)
        {
            return null;
        }

        [HttpGet]
        public IHttpActionResult GetPlayer(string playerName) 
        {
            return null;
        }
    }
}