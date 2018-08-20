using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreWebApi.Models;

namespace ScoreWebApi.Controllers
{

    public class LeaderboardController : Controller
    {
        public List<Leaderboard> dbLeaderboardContext = LeaderboardDBContext.leaderboard;
        public List<Match> dbMatchContext = MatchDBContext.match;

        [HttpGet]
        [Route("api/leaderboard")]
        public List<Leaderboard> Get()
        {
            return dbLeaderboardContext.ToList();

        }

        [HttpGet("{id}")]
        [Route("api/leaderboard/{id}")]
        public Leaderboard Get(int id)
        {
            return dbLeaderboardContext.Find(e => e.PlayerID == id);
        }

        [HttpPost]
        [Route("api/leaderboard/reset")]
        public List<Leaderboard> Reset()
        {
            dbLeaderboardContext.RemoveAll(e => e.PlayerID != 0);
            dbMatchContext.RemoveAll(e => e.MatchId != 0);
            return dbLeaderboardContext.ToList();
        }


    }
}
