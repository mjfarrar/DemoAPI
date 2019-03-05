using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoAPI.Models;

namespace DemoAPI.Services
{
    public class SportsRepository
    {
        string cacheKey = "sports";

        public SportsRepository() 
        {
            var ctx = HttpContext.Current;

            if (ctx != null) 
            {
                if (ctx.Cache[cacheKey] == null) 
                {
                    SportInfo football = new SportInfo()
                    {
                        SportName = "Football"
                    };

                    SportInfo basketball = new SportInfo()
                    {
                        SportName = "Basketball"
                    };

                    List<SportInfo> sports = new List<SportInfo>();
                    sports.Add(football);
                    sports.Add(basketball);

                    ctx.Cache[cacheKey] = sports;
                }
            }
        }

        public IEnumerable<SportInfo> GetAllSports() 
        {
            var ctx = HttpContext.Current;

            if (ctx != null) 
            {
                return (List<SportInfo>)ctx.Cache[cacheKey];
            }

            return null;
        }

        public SportInfo GetSport(string sportName)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                List<SportInfo> sports = (List<SportInfo>)ctx.Cache[cacheKey];
                return sports.FirstOrDefault(x => x.SportName == sportName);
            }

            return null;
        }

        public bool AddSport(string sportName)
        {
            SportInfo sport = new SportInfo() 
            {
                SportName = sportName
            };

            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    List<SportInfo> sports = ((List<SportInfo>)ctx.Cache[cacheKey]).ToList();
                    sports.Add(sport);
                    ctx.Cache[cacheKey] = sports;

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