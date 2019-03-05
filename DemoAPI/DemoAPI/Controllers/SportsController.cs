using DemoAPI.Models;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAPI.Services;

namespace DemoAPI.Controllers
{
    [RoutePrefix("api/sports")]
    public class SportsController : ApiController
    {
        private SportsRepository sportRepo;
        private TeamsRepository teamRepo;
        private PlayersRepository playerRepo;

        public SportsController() 
        {
            sportRepo = new SportsRepository();
            teamRepo = new TeamsRepository();
            playerRepo = new PlayersRepository();
        }

        [HttpGet]
        [Route("GetAllSports")]
        public IHttpActionResult GetAllSports() 
        {
            var sports = this.sportRepo.GetAllSports();

            return Ok(sports);
        }

        [HttpGet]
        [Route("GetSport")]
        public IHttpActionResult GetSport([FromUri]string sportName)
        {
            var sports = this.sportRepo.GetSport(sportName);

            return Ok(sports);
        }

        [HttpPost]
        [Route("AddSport")]
        public IHttpActionResult AddSport([FromUri]string sportName)
        {
            var success = this.sportRepo.AddSport(sportName);

            return Ok(success);
        }

        [HttpGet]
        [Route("GetAllTeams")]
        public IHttpActionResult GetAllSportTeams()
        {
            var teams = this.teamRepo.GetAllTeams();

            return Ok(teams);
        }

        [HttpGet]
        [Route("GetTeam")]
        public IHttpActionResult GetTeam([FromUri]string teamName)
        {
            var team = this.teamRepo.GetTeam(teamName);

            return Ok(team);
        }

        [HttpPost]
        [Route("AddTeam")]
        public IHttpActionResult AddTeam(TeamInfo teamInfo)
        {
            var success = this.teamRepo.AddTeam(teamInfo);

            return Ok(success);
        }

        [HttpGet]
        [Route("GetAllPlayers")]
        public IHttpActionResult GetAllPlayers()
        {
            var teams = this.playerRepo.GetAllPlayers();

            return Ok(teams);
        }

        [HttpGet]
        [Route("GetPlayer")]
        public IHttpActionResult GetPlayer([FromUri]string playerName)
        {
            var team = this.playerRepo.GetPlayer(playerName);

            return Ok(team);
        }

        [HttpPost]
        [Route("AddPlayer")]
        public IHttpActionResult AddTeam(PlayerInfo playerInfo)
        {
            var success = this.playerRepo.AddPlayer(playerInfo);

            return Ok(success);
        }
    }
}