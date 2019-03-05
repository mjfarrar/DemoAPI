using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Services
{
    public class TeamsRepository
    {
        string cacheKey = "teams";
        private SportsRepository sportsRepo;

        public TeamsRepository() 
        {
            sportsRepo = new SportsRepository();
            var ctx = HttpContext.Current;
            IEnumerable<SportInfo> sports = sportsRepo.GetAllSports();

            if (ctx != null) 
            {
                if (ctx.Cache[cacheKey] == null) 
                {
                    TeamInfo teamOne = new TeamInfo()
                    {
                        TeamName = "Miami Heat",
                        TeamSport = sports.FirstOrDefault(x => x.SportName == "Basketball")
                    };
 
                    TeamInfo teamTwo = new TeamInfo()
                    {
                        TeamName = "Los Angeles Lakers",
                        TeamSport = sports.FirstOrDefault(x => x.SportName == "Basketball")
                    };

                    TeamInfo teamThree = new TeamInfo()
                    {
                        TeamName = "Pittsburg Steelers",
                        TeamSport = sports.FirstOrDefault(x => x.SportName == "Football")
                    };

                    TeamInfo teamFour = new TeamInfo()
                    {
                        TeamName = "Indianapolis Colts",
                        TeamSport = sports.FirstOrDefault(x => x.SportName == "Football")
                    };

                    List<TeamInfo> teams = new List<TeamInfo>();
                    teams.Add(teamOne);
                    teams.Add(teamTwo);
                    teams.Add(teamThree);
                    teams.Add(teamFour);

                    ctx.Cache[cacheKey] = teams;
                }
            }
        }

        public IEnumerable<TeamInfo> GetAllTeams() 
        {
            var ctx = HttpContext.Current;

            if (ctx != null) 
            {
                return (List<TeamInfo>)ctx.Cache[cacheKey];
            }

            return null;
        }

        public TeamInfo GetTeam(string teamName)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                List<TeamInfo> teams = (List<TeamInfo>)ctx.Cache[cacheKey];
                return teams.FirstOrDefault(x => x.TeamName == teamName);
            }

            return null;
        }

        public bool AddTeam(TeamInfo teamInfo)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    List<TeamInfo> teams = ((List<TeamInfo>)ctx.Cache[cacheKey]).ToList();
                    teams.Add(teamInfo);
                    ctx.Cache[cacheKey] = teams;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}