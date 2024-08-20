#nullable disable
using FSISSystem.DAL;
using FSISSystem.Entities;
using FSISSystem.ViewModels;

namespace FSISSystem.BAL
{
    public class GameService
    {
        #region Constructor and Context Dependency
        private readonly FSIS_2018Context _context;

        //obtain the context link from IServiceCollection when this
        //  set of service is injected into the "outside user"
        internal GameService(FSIS_2018Context context)
        {
            _context = context;
        }
        #endregion

        #region Services:Queries
        public List<GameItemView> GameServices_GetList()
        {
            IEnumerable<GameItemView> results = _context.Games
                                                .OrderByDescending(x => x.GameDate)
                                                .Select(x => new GameItemView()
                                                {
                                                    GameID = x.GameID,
                                                    GameDate = x.GameDate,
                                                    HomeTeamID = x.HomeTeamID,
                                                    HomeName = x.HomeTeam.TeamName,
                                                    HomeTeamScore = x.HomeTeamScore,
                                                    VisitingTeamID = x.VisitingTeamID,
                                                    VisitingName = x.VisitingTeam.TeamName,
                                                    VisitingTeamScore = x.VisitingTeamScore
                                                });
            return results.Take(50).ToList();
        }
        #endregion

        #region Services: Command
        public void GameServices_ScheduleGames(DateTime gamedate, List<ScheduleView> gameschedule)
        {
            List<Exception> errors = new List<Exception>();
            Team teamexists = null;
            string hometeamname = "";
            string visitingteamname = "";
            int scheduledcount = 0;
            Game newgame = null;
            Game gameexists = null;

            if (gameschedule is null)
            {
                throw new ArgumentNullException("No game schedule list has been provided.");
            }
            //past date test
            if (gamedate < DateTime.Today)
            {
                errors.Add(new Exception("Game date is in the past."));
            }
            // at least one game scheduled test
            if (gameschedule.Count < 1)
            {
                errors.Add(new Exception("Game schedule list has no entries."));
            }
            foreach (ScheduleView game in gameschedule)
            {
                //home team id exists
                teamexists = _context.Teams.FirstOrDefault(x => x.TeamID == game.HomeTeamID);
                if (teamexists == null)
                {
                    errors.Add(new Exception($"An invalid Home teamid has been entered: {game.HomeTeamID}"));
                    hometeamname = "Unknown";
                }
                else
                {
                    hometeamname = teamexists.TeamName;
                }
                //visiting team id exists
                teamexists = _context.Teams.FirstOrDefault(x => x.TeamID == game.VisitingTeamID);
                if (teamexists == null)
                {
                    errors.Add(new Exception($"An invalid Visitng teamid has been entered: {game.VisitingTeamID}"));
                    visitingteamname = "Unknown";
                }
                else
                {
                    visitingteamname = teamexists.TeamName;
                }
                //team cannot play itself test
                if (game.HomeTeamID == game.VisitingTeamID)
                {
                    errors.Add(new Exception($"Team cannot play iteself {hometeamname} ({game.HomeTeamID})"));
                }
                //home team not already scheduled to play on game date test
                gameexists = _context.Games
                    .FirstOrDefault(x => x.GameDate == gamedate && (x.HomeTeamID == game.HomeTeamID || x.VisitingTeamID == game.HomeTeamID));
                if (gameexists != null)
                {
                    errors.Add(new Exception($"Scheduled home team {hometeamname} ({game.HomeTeamID}) already schedule to play on {gamedate}"));
                    visitingteamname = "Unknown";
                }
                //visiting team not already scheduled to play on game date test
                gameexists = _context.Games
                   .FirstOrDefault(x => x.GameDate == gamedate && (x.HomeTeamID == game.VisitingTeamID || x.VisitingTeamID == game.VisitingTeamID));
                if (gameexists != null)
                {
                    errors.Add(new Exception($"Scheduled visiting team {hometeamname} ({game.VisitingTeamID}) already schedule to play on {gamedate}"));
                    visitingteamname = "Unknown";
                }
            }
            foreach (Team team in _context.Teams)
            {
                //team can only be scheduled to play once on a date test
                scheduledcount = gameschedule
                                .Where(x => x.HomeTeamID == team.TeamID
                                        || x.VisitingTeamID == team.TeamID)
                                .Count();
                if (scheduledcount > 1)
                {
                    errors.Add(new Exception($"{team.TeamName} ({team.TeamID}) can only be scheduled to play once a day"));
                }
            }

            if (errors.Count() > 0)
            {
                throw new AggregateException("Unable to schedule games, view following concerns:", errors);
            }
            else
            {
                foreach (ScheduleView game in gameschedule)
                {
                    newgame = new Game()
                    {
                        HomeTeamID = game.HomeTeamID,
                        VisitingTeamID = game.VisitingTeamID,
                        GameDate = gamedate,
                        HomeTeamScore = 0,
                        VisitingTeamScore = 0
                    };
                    _context.Games.Add(newgame);
                }
                _context.SaveChanges();
            }
        }
        #endregion

    }
}