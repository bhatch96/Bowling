using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowler { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string BowlingTeam { get; set; }
    }
}
