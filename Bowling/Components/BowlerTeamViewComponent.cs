using Microsoft.AspNetCore.Mvc;
using Bowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Components
{
    public class BowlerTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public BowlerTeamViewComponent (BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {

            return View(context.Teams
                   .Distinct()
                   .OrderBy(x => x)
                 
                );
        }
    }
}
