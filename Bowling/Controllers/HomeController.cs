using Bowling.Models;
using Bowling.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
         }

        public IActionResult Index(long? bowlingteamid, string bowlingteam, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowler = (context.Bowlers
                .FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {bowlingteamid} OR {bowlingteamid} IS NULL")
                .OrderBy(x => x.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //If no bowlingteamid selected, get full count, otherwise count only the number from bowler team that has been selected
                    TotalNumItems = (bowlingteamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == bowlingteamid).Count())
                },

                BowlingTeam = bowlingteam

            }) ; 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
