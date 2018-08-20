using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreWebApi.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string Player { get; set; }
        public int Level { get; set; }
        public string OpponentName { get; set; }
        public int OpponentLevel { get; set; }
        public string Status { get; set; }
        public int PotentialPoints { get; set; }
        public string Winner { get; set; }
    }
}
