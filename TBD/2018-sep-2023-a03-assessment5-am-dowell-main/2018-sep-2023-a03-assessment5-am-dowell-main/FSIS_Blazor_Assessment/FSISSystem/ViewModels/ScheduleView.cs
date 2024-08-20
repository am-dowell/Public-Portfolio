using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSISSystem.ViewModels
{
    public class ScheduleView
    {
        //Technical unique field to be used when setting up
        //   the command model fields on the web page
        //the value for this should be .Max(GameIndex) plus 1.
        public int GameIndex { get; set; }
        public int HomeTeamID { get; set; }
        public int VisitingTeamID { get; set; }
    }
}
