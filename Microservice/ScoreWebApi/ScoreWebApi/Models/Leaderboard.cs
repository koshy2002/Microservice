using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreWebApi.Models
{
    public class Leaderboard
    {
        public int PlayerID { get; set; }
        public string Player { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }

    }
}
