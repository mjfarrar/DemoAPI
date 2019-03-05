using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Services
{
    public class PlayersRepository
    {string cacheKey = "players";
        private SportsRepository sportsRepo;
        private TeamsRepository teamRepo;

        public PlayersRepository() 
        {
            sportsRepo = new SportsRepository();
            teamRepo = new TeamsRepository();
            var ctx = HttpContext.Current;
            IEnumerable<SportInfo> sports = sportsRepo.GetAllSports();
            IEnumerable<TeamInfo> teams = teamRepo.GetAllTeams();

            if (ctx != null) 
            {
                if (ctx.Cache[cacheKey] == null) 
                {
                    List<PlayerInfo> players = new List<PlayerInfo>();

                    createBasketballPlayersData(players, teams);
                    createFootballPlayersData(players, teams);

                    ctx.Cache[cacheKey] = players;
                }
            }
        }

        public IEnumerable<PlayerInfo> GetAllPlayers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                List<PlayerInfo> players = (List<PlayerInfo>)ctx.Cache[cacheKey];
                return players;
            }

            return null;
        }

        public PlayerInfo GetPlayer(string playerName)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                List<PlayerInfo> players = (List<PlayerInfo>)ctx.Cache[cacheKey];
                return players.FirstOrDefault(x => x.PlayerName == playerName);
            }

            return null;
        }

        public bool AddPlayer(PlayerInfo player)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    List<PlayerInfo> players = ((List<PlayerInfo>)ctx.Cache[cacheKey]).ToList();
                    players.Add(player);
                    ctx.Cache[cacheKey] = players;

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

        public void createBasketballPlayersData(List<PlayerInfo> players, IEnumerable<TeamInfo> teams) 
        {
            //Basketball Players
            //Miami
            PlayerInfo allen = new PlayerInfo()
            {
                PlayerName = "Ray Allen",
                PlayerPosition = "Shooting Guard",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Miami Heat")
            };
            List<PlayerStat> allenStats = new List<PlayerStat>();
            allenStats.Add(new PlayerStat() { StatName = "Points", StatValue = 18 });
            allenStats.Add(new PlayerStat() { StatName = "Assists", StatValue = 4 });
            allenStats.Add(new PlayerStat() { StatName = "Rebounds", StatValue = 2 });
            allen.PlayerStats = allenStats;
            players.Add(allen);

            PlayerInfo wade = new PlayerInfo()
            {
                PlayerName = "Dwayne Wade",
                PlayerPosition = "Shooting Guard",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Miami Heat")
            };
            List<PlayerStat> wadeStats = new List<PlayerStat>();
            wadeStats.Add(new PlayerStat() { StatName = "Points", StatValue = 26 });
            wadeStats.Add(new PlayerStat() { StatName = "Assists", StatValue = 6 });
            wadeStats.Add(new PlayerStat() { StatName = "Rebounds", StatValue = 5 });
            wade.PlayerStats = wadeStats;
            players.Add(wade);

            //Lakers
            PlayerInfo bryant = new PlayerInfo()
            {
                PlayerName = "Kobe Bryant",
                PlayerPosition = "Shooting Guard",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Los Angeles Lakers")
            };
            List<PlayerStat> bryantStats = new List<PlayerStat>();
            bryantStats.Add(new PlayerStat() { StatName = "Points", StatValue = 18 });
            bryantStats.Add(new PlayerStat() { StatName = "Assists", StatValue = 4 });
            bryantStats.Add(new PlayerStat() { StatName = "Rebounds", StatValue = 2 });
            bryant.PlayerStats = bryantStats;
            players.Add(bryant);

            PlayerInfo james = new PlayerInfo()
            {
                PlayerName = "Lebron James",
                PlayerPosition = "Small Forward",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Los Angeles Lakers")
            };
            List<PlayerStat> jamesStats = new List<PlayerStat>();
            jamesStats.Add(new PlayerStat() { StatName = "Points", StatValue = 28 });
            jamesStats.Add(new PlayerStat() { StatName = "Assists", StatValue = 9 });
            jamesStats.Add(new PlayerStat() { StatName = "Rebounds", StatValue = 8 });
            james.PlayerStats = jamesStats;
            players.Add(james);
        }

        public void createFootballPlayersData(List<PlayerInfo> players, IEnumerable<TeamInfo> teams)
        {
            //Football Players
            //Pittsburg
            PlayerInfo ben = new PlayerInfo()
            {
                PlayerName = "Ben Rothelisberger",
                PlayerPosition = "QuarterBack",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Pittsburg Steelers")
            };
            List<PlayerStat> benStats = new List<PlayerStat>();
            benStats.Add(new PlayerStat() { StatName = "Passing Yards", StatValue = 56000 });
            benStats.Add(new PlayerStat() { StatName = "Touchdowns", StatValue = 454 });
            benStats.Add(new PlayerStat() { StatName = "Interceptions", StatValue = 213 });
            ben.PlayerStats = benStats;
            players.Add(ben);

            PlayerInfo brown = new PlayerInfo()
            {
                PlayerName = "Antonio Brown",
                PlayerPosition = "Wide Receiver",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Pittsburg Steelers")
            };
            List<PlayerStat> brownStats = new List<PlayerStat>();
            brownStats.Add(new PlayerStat() { StatName = "Receiving Yards", StatValue = 25000 });
            brownStats.Add(new PlayerStat() { StatName = "Touchdowns", StatValue = 146 });
            brownStats.Add(new PlayerStat() { StatName = "YAC Average", StatValue = 6 });
            brown.PlayerStats = brownStats;
            players.Add(brown);

            //Colts
            PlayerInfo luck = new PlayerInfo()
            {
                PlayerName = "Andrew Luck",
                PlayerPosition = "QuarterBack",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Indianapolis Colts")
            };
            List<PlayerStat> luckStats = new List<PlayerStat>();
            luckStats.Add(new PlayerStat() { StatName = "Passing Yards", StatValue = 23000 });
            luckStats.Add(new PlayerStat() { StatName = "Touchdowns", StatValue = 189 });
            luckStats.Add(new PlayerStat() { StatName = "Interceptions", StatValue = 67 });
            luck.PlayerStats = luckStats;
            players.Add(luck);

            PlayerInfo hilton = new PlayerInfo()
            {
                PlayerName = "T.Y Hilton",
                PlayerPosition = "Wide Receiver",
                PlayerTeam = teams.FirstOrDefault(x => x.TeamName == "Indianapolis Colts")
            };
            List<PlayerStat> hiltonStats = new List<PlayerStat>();
            hiltonStats.Add(new PlayerStat() { StatName = "Receiving Yards", StatValue = 25000 });
            hiltonStats.Add(new PlayerStat() { StatName = "Touchdowns", StatValue = 146 });
            hiltonStats.Add(new PlayerStat() { StatName = "YAC Average", StatValue = 6 });
            hilton.PlayerStats = hiltonStats;
            players.Add(hilton);
        }
    }
}