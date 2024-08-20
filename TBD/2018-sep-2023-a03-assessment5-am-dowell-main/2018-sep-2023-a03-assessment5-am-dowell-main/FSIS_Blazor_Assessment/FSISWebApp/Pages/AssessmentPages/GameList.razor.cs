#nullable disable
using FSISSystem.BAL;
using FSISSystem.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FSISWebApp.Pages.AssessmentPages
{
    public partial class GameList
    {
        #region Properties
        /// <summary>
        /// Gets or sets the customer service.
        /// </summary>
        /// <value>The customer service.</value>
        [Inject]
        protected TeamService TeamServices { get; set; }

        /// <summary>
        /// Gets or sets the navigation manager.
        /// </summary>
        /// <value>The navigation manager.</value>
        [Inject]
        protected GameService GameService { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        protected List<GameItemView> Latest50Games { get; set; } = new();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Latest50Games = GameService.GameServices_GetList();
        }
    }
}
