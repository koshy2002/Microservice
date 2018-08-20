using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreClient.Models;
using ScoreClient.ViewModels;

namespace ScoreClient.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Index()
        {
            DataClient dc = new DataClient();
            ViewBag.listAllLeaderboard = dc.findAllScore().OrderBy(sc => sc.Rank).Take(10);
            ViewBag.listAllScores = dc.findAllMatch();
            return View();
        }


        public ActionResult Reset()
        {
            DataClient dc = new DataClient();
            dc.Reset();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(MatchViewModel mvm)
        {
            if (!String.IsNullOrEmpty(mvm.Match.Player) && !String.IsNullOrEmpty(mvm.Match.OpponentName)
               && (mvm.Match.Level >= 0) && (mvm.Match.OpponentLevel >= 0))
            {
                mvm.Match.Player = mvm.Match.Player.ToUpper();
                mvm.Match.OpponentName = mvm.Match.OpponentName.ToUpper();
                DataClient dc = new DataClient();
                dc.CreateMatch(mvm.Match);
            }

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            DataClient dc = new DataClient();
            MatchViewModel mvm = new MatchViewModel();
            mvm.Match = dc.FindMatch(id);
            return View("Edit", mvm);
        }

        [HttpPost]
        public ActionResult Edit(MatchViewModel mvm)
        {
            if (String.IsNullOrEmpty(mvm.Match.Winner))
                return RedirectToAction("Index");

            if(mvm.Match.Winner.ToUpper() != mvm.Match.Player.ToUpper() &&  mvm.Match.Winner.ToUpper() != mvm.Match.OpponentName.ToUpper())
                return RedirectToAction("Index");

            mvm.Match.Status = "complete";
            mvm.Match.Winner = mvm.Match.Winner.ToUpper();
            DataClient dc = new DataClient();
            dc.EditMatch(mvm.Match);
            return RedirectToAction("Index");
        }




        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
