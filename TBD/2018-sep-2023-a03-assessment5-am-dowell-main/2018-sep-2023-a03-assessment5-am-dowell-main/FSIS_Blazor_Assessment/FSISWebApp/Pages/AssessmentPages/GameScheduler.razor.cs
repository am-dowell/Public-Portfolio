#nullable disable
using FSISSystem.BAL;
using FSISSystem.Entities;
using FSISSystem.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FSISWebApp.Pages.AssessmentPages
{
    public partial class GameScheduler
    {
        #region Services DO NOT ALTER
        /// <summary>
        /// Gets or sets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        [Inject]
        protected TeamService TeamService { get; set; }

        /// <summary>
        /// Gets or sets the navigation manager.
        /// </summary>
        /// <value>The navigation manager.</value>
        [Inject]
        protected GameService GameService { get; set; }
        #endregion

        #region Messaging and Error Handling DO NOT ALTER
        private string feedBackMessage { get; set; }

        private string errorMessage { get; set; }

        //a get property that returns the result of the lamda action
        private bool hasError => !string.IsNullOrWhiteSpace(errorMessage);
        private bool hasFeedBack => !string.IsNullOrWhiteSpace(feedBackMessage);

        // error details
        private List<string> errorDetails = new();

        // error list for collection 
        private List<Exception> errorList { get; set; } = new();
        #endregion

        #region Fields and Properties DO NOT ALTER

        //use for dropdown list: Home Team
        private List<SelectionListView> homeTeamList { get; set; }
        //use for dropdown list: Visiting Team
        private List<SelectionListView> visitTeamList { get; set; }

        //variables used to collect data from the web page form

        // Game Date
        private DateTime gameDate { get; set; } = DateTime.Today;

        //Home Team dropdown list value
        private int homeId { get; set; }

        //Visiting Team dropdown list value
        private int visitId { get; set; }

        // collection to hold game for scheduling
        private List<ScheduleView> gameSchedule { get; set; } = new();

        //Remove button value        
        private int SelectedGame { get; set; }
        #endregion

        //Do not alter this code
        #region Given code DO NOT ALTER

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            homeTeamList = TeamService.GetTeamList();
            visitTeamList = TeamService.GetTeamList();
        }

        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

        public void Clear()
        {
            gameSchedule.Clear();
        }
        #endregion

        //	TODO: 1 Create web page table code
        //        Open the .razor page and add the code to handle the table for game scheduling

        public void AddToSchedule()
        {
            //  TODO: 2 Implement Add to Schedule 
            //  See AddToSchedule Image for details

            //  YOUR CODE HERE

            //            Place your code within an user friendly error handling structure. The code should

            //validate the game date if today or in the future
            //validate a home team was selected
            //validate a visiting team was selected
            //generate a value to be used as a technique
                //index for the game to be scheduled
            //create a new instance to be added to the view model collection
            //add the instance to the collection

            if(gameDate < DateTime.Now)
            {
                errorList.Add(new Exception("Game cannot be in the past"));
            }
            if(homeId == null)
            {
                errorList.Add(new Exception("select a home team"));
            }
            if (visitId == null)
            {
                errorList.Add(new Exception("select a visiting team"));
            }

            ScheduleView game = new ScheduleView()
            {
                GameIndex = gameSchedule.Count() + 1,
                HomeTeamID = homeId,
                VisitingTeamID = visitId,
            };
            GameItemView.Add(game);
    }

        public void Remove(int gameIndex)
        {
            //	TODO: 3 Implement Remove from Schedule post
            //  See Remove Image for details

            //  YOUR CODE HERE

            var selectedItem =
                GameScheduler.FirstOrDefault(x => x.GameID == gameIndex);
            if (selectedItem != null)
            {
                GameScheduler.Remove(selectedItem);
            }
        }

        public void Save()
        {
            //	TODO: 4 Implement Schedule (service transaction call) post
            //  See Remove Image for details

            //  YOUR CODE HERE

            //  See Remove Image for details
            Game game = new Game();
            game.GameDate = gameDate;
            game.HomeTeamID = homeId;
            game.VisitingTeamID = visitId;

            // Handle new or existing line items.
            if (game.GameID == null)
            {
                gameSchedule.Add(game);
            }

            if (errorList.Count() > 0)
            {
                ChangeTracker.Clear();
                throw new AggregateException("Unable to proceed!  Check concerns", errorList);
            }
            else
            {
                //SaveChanges();
                SaveChanges();
            }
        }
    }
}