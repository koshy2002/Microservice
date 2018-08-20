using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScoreClient.Models
{
    public class Leaderboard
    {
        [Display(Name = "PlayerId")]
        public int PlayerID { get; set; }

        [Display(Name = "Player")]
        public string Player { get; set; }

        [Display(Name = "Rank")]
        public int Rank { get; set; }

        [Display(Name = "Score")]
        public int Score { get; set; }
    }
}
