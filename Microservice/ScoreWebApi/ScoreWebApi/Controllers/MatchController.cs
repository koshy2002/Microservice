using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreWebApi.Models;

namespace ScoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        public List<Match> dbMatchContext = MatchDBContext.match;
        public List<Leaderboard> dbLeaderboardContext = LeaderboardDBContext.leaderboard;

        [HttpGet]
        public List<Match> Get()
        {
            return dbMatchContext.ToList();

        }

        [HttpGet("{id}")]
        public Match Get(int id)
        {
            return dbMatchContext.Find(e => e.MatchId == id);
        }

        [HttpPost]
        public List<Match> Post([FromBody]Match obj)
        {
            int MatchData = 0;
            if (dbMatchContext.Count == 0)
                obj.MatchId = 1;
            else
            {
                MatchData = dbMatchContext.Max(x => x.MatchId);
                MatchData = MatchData + 1;
                obj.MatchId = MatchData;
            }


            obj.Status = "in-progess";
            obj.PotentialPoints = (obj.Level + obj.OpponentLevel) * 10;
            obj.Winner = "";

            dbMatchContext.Add(obj);
            return dbMatchContext.ToList();
        }


        [HttpPut("{id}")]
        public Match Put(int id, [FromBody]Match obj)
        {

            var matchData = dbMatchContext.Find(e => e.MatchId == id);
            if (matchData == null)
            {
                return null;
            }
            var data = dbMatchContext.Where(e => e.MatchId == id)
             .Select(ele => { ele.Winner = obj.Winner; ele.Status = obj.Status; return ele; })
             .ToList();

            var getPlayerData = dbLeaderboardContext.Find(e => e.Player == obj.Winner);
            if (getPlayerData == null)
            {
                int LeaderData = 0;
                if (dbLeaderboardContext.Count == 0)
                    LeaderData = 1;
                else
                {
                    LeaderData = dbLeaderboardContext.Max(x => x.PlayerID);
                    LeaderData = LeaderData + 1;

                }
                dbLeaderboardContext.Add(new Leaderboard() { PlayerID = LeaderData, Player = obj.Winner, Rank = 0, Score = data[0].PotentialPoints });
            }
            else
            {
                getPlayerData.Score = getPlayerData.Score + data[0].PotentialPoints;
            }
            if (dbLeaderboardContext.Count > 0)
            {
                var descScoreData = dbLeaderboardContext.OrderByDescending(ele => ele.Score);
                int RankCount = 1;
                foreach (Leaderboard lb in descScoreData)
                {
                    lb.Rank = RankCount;
                    RankCount = RankCount + 1; ;
                }
            }

            return dbMatchContext.Find(e => e.MatchId == id);

        }


    }
}