using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSISSystem.ViewModels
{
    public class GameItemView
    {
        public int GameID { get; set; }
        public DateTime GameDate { get; set; }
        public int HomeTeamID { get; set; }
        public int VisitingTeamID { get; set; }
        public int HomeTeamScore { get; set; }
        public int VisitingTeamScore { get; set; }
        public string HomeName { get; set; }
        public string VisitingName { get; set; }
    }
}
