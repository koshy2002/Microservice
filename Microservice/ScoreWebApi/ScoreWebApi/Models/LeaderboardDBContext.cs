using ScoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreWebApi.Models
{
    public class LeaderboardDBContext
    {


        public static List<Leaderboard> leaderboard = new List<Leaderboard>
        {



            new Leaderboard() { PlayerID = 1 , Player = "JEROME" , Rank = 1 , Score = 40},
            new Leaderboard() { PlayerID = 2 , Player = "CHRIS" , Rank = 2 , Score = 30},
            new Leaderboard() { PlayerID = 3 , Player = "RYAN" , Rank = 3 , Score = 10}

        };
    }
}
