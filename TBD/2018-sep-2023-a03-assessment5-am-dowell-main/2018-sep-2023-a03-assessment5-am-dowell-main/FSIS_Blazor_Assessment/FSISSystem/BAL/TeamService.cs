using FSISSystem.DAL;
using FSISSystem.ViewModels;

namespace FSISSystem.BAL
{
    public class TeamService
    {
        #region Constructor and Context Dependency
        private readonly FSIS_2018Context _context;

        //obtain the context link from IServiceCollection when this
        //  set of service is injected into the "outside user"
        internal TeamService(FSIS_2018Context context)
        {
            _context = context;
        }
        #endregion

        #region Services:Queries
        public List<SelectionListView> GetTeamList()
        {
            IEnumerable<SelectionListView> results = _context.Teams
                                                .OrderBy(x => x.TeamName)
                                                .Select(x => new SelectionListView()
                                                {
                                                    ValueId = x.TeamID,
                                                    DisplayText = x.TeamName
                                                });
            return results.ToList();
        }
        #endregion
    }
}