<Query Kind="Program">
  <Connection>
    <ID>9091d1fc-950c-4b91-88bb-75a90449622b</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>FSIS_2018</Database>
    <DisplayName>FSIS_Entity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	try
	{

		//Driver
		//display team players with stats BEFORE
		DisplayTeamPlayers(23);

		//FOR TESTING: uncomment test to run, comment test not to run

		//call service method bad parameters
		//Game_RecordGame(0, null, null); //test one --> game not found
		//Game_RecordGame(23, null, null);  //test two --> missing parameter
		//create instance of PlayerStat with BAD test data
		List<PlayerGameStat> hometeam = BadLoadHomeTeam();
		//Game_RecordGame(23, hometeam, null); //test three --> missing parameter
		List<PlayerGameStat> visitingteam = BadLoadVisitingTeam();
		//Game_RecordGame(233, hometeam, visitingteam); //test four --> game not found
		//Game_RecordGame(23, hometeam, visitingteam); //test five --> scores incorrect
		//Game_RecordGame(25, hometeam, visitingteam); //test six --> game already has stats
		hometeam = BadStatsHomeTeam();
		visitingteam = BadStatsVisitingTeam();
		//Game_RecordGame(23, hometeam, visitingteam); //test seven --> bad game stats



		//create instances of PlayerStat with GOOD test data
		//To rerun, go to your sql and remove any gameid = 23 off the PlayerStats
		//On the displays view 
		//         GamesPlayed (should be +1 between before and after)
		//         Expand PlayerStats and look for GameID 23 instances
		hometeam = GoodHomeTeam();
		visitingteam = GoodVisitingTeam();
		Game_RecordGame(23, hometeam, visitingteam); //test good results 


		//display team players with stats AFTER
		DisplayTeamPlayers(23);


	}
	catch (ArgumentNullException ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	catch (ArgumentException ex)
	{

		GetInnerException(ex).Message.Dump();
	}
	catch (AggregateException ex)
	{
		//having collected a number of errors
		//	each error should be dumped to a separate line
		foreach (var error in ex.InnerExceptions)
		{
			error.Message.Dump();
		}
	}
	catch (Exception ex)
	{
		GetInnerException(ex).Message.Dump();
	}

}

// You can define other methods, fields, classes and namespaces here

public class PlayerGameStat
{
	public int PlayerID { get; set; }
	public int Goals { get; set; }
	public int Assists { get; set; }
	public bool Yellow { get; set; }
	public bool Red { get; set; }
	public bool Rostered { get; set; }
}

#region Given Code DO NOT ALTER
private Exception GetInnerException(Exception ex)
{
	while (ex.InnerException != null)
		ex = ex.InnerException;
	return ex;
}

public List<PlayerGameStat> BadLoadHomeTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 148, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 158, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 167, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 173, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 188, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 190, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	return data;
}

public List<PlayerGameStat> BadLoadVisitingTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 133, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 135, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 143, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 153, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 162, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 170, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	return data;
}

public List<PlayerGameStat> BadStatsHomeTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 148, Goals = -1, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 1583, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 167, Goals = -2, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 1733, Goals = 0, Assists = -1, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 188, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 190, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	return data;
}

public List<PlayerGameStat> BadStatsVisitingTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 1333, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 135, Goals = -1, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 1433, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 153, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 162, Goals = 0, Assists = -1, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 170, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	return data;
}

public List<PlayerGameStat> GoodHomeTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 148, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 158, Goals = 0, Assists = 0, Yellow = true, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 167, Goals = 1, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 173, Goals = 0, Assists = 1, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 188, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 190, Goals = 0, Assists = 0, Yellow = false, Red = true, Rostered = true });
	return data;
}

public List<PlayerGameStat> GoodVisitingTeam()
{
	List<PlayerGameStat> data = new List<PlayerGameStat>();
	data.Add(new PlayerGameStat()
	{ PlayerID = 133, Goals = 0, Assists = 0, Yellow = false, Red = true, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 135, Goals = 2, Assists = 1, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 143, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 153, Goals = 0, Assists = 1, Yellow = true, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 162, Goals = 1, Assists = 1, Yellow = false, Red = false, Rostered = true });
	data.Add(new PlayerGameStat()
	{ PlayerID = 170, Goals = 0, Assists = 0, Yellow = false, Red = false, Rostered = true });
	return data;
}

public void DisplayTeamPlayers(int gameid)
{
	Games results = Games.ToList()
					.Where(x => x.GameID == gameid)
					.FirstOrDefault();
	List<Players> hometeam = Players
						.Where(x => x.TeamID == results.HomeTeamID)
						.ToList();
	List<Players> visitingteam = Players
						.Where(x => x.TeamID == results.VisitingTeamID)
						.ToList();
	hometeam.Dump();
	visitingteam.Dump();
}

#endregion

public void Game_RecordGame(int gameid,
							List<PlayerGameStat> hometeam,
							List<PlayerGameStat> visitingteam)
{
	//local variables
	Players playerexists = null;
	Games gameexists = null;
	PlayerStats newplayerstats = null;


	//we need a container to hold x number of Exception messages
	List<Exception> errorlist = new List<Exception>();

	//YOUR CODE HERE

	//	parameter values must exist(ArgumentNullException).
	//The Games record for the incoming stats should already be on the database(ArgumentException).
	gameexists = Games
						.Where(x => x.GameID == gameid)
						.FirstOrDefault();
	if (gameid == 0) {
		errorlist.Add(new ArgumentNullException("game does not exist"));
	}
	foreach (var player in hometeam)
	{
		playerexists = Players
			.Where(x => x.PlayerID == player.PlayerID)
			.FirstOrDefault();
		if (playerexists.PlayerID == 0)
		{
			errorlist.Add(new ArgumentNullException("Player does not exist"));
		}
	}
	foreach (var player in visitingteam)
	{
		playerexists = Players
			.Where(x => x.PlayerID == player.PlayerID)
			.FirstOrDefault();
		if (playerexists.PlayerID == 0)
		{
			errorlist.Add(new ArgumentNullException("Player does not exist"));
		}
		//goals and assists are non - negative integer values,
		if (player.Assists < 0) {
			errorlist.Add(new Exception("assists must be a non negative number"));
		}
		if (player.Goals < 0)
		{
			errorlist.Add(new Exception("goals must be a non negative number"));
		}

		//player stats for the game must not already be on file,
		newplayerstats = PlayerStats
						.Where(x => x.PlayerID == player.PlayerID)
						.FirstOrDefault();

		if (newplayerstats == null)
		{
			newplayerstats = new PlayerStats();
			//newplayerstats.Game.GameID = gameexists.GameID;
		}
		else
		{
			errorlist.Add(new Exception("player stats already exists for this game"));
		}
	}

	//total number of goals by players on a team is equal to the team score recorded for the game.
	if (hometeam.Sum(h => h.Goals) != gameexists.HomeTeamScore)
	{
		errorlist.Add(new Exception("goals by players on a hometeam is not equal to the team score recorded for the game"));
	}
	if (visitingteam.Sum(v => v.Goals) != gameexists.VisitingTeamScore)
	{
		errorlist.Add(new Exception("goals by players on a visitingteam is not equal to the team score recorded for the game"));
	}

	//Processing


	foreach (var hplayer in hometeam)
	{

		// Map fields from the line item view model to the data model.
		newplayerstats.Assists = hplayer.Assists;
		newplayerstats.Goals = hplayer.Goals;
		newplayerstats.RedCard = hplayer.Red;
		newplayerstats.YellowCard = hplayer.Yellow;
		//update each player's record (field: GamesPlayed) if they participated (played) in the game independent of having any stats.
		//newplayerstats.Player.GamesPlayed = newplayerstats.Player.GamesPlayed + 1;
	}
	foreach (var vplayer in visitingteam)
	{

		// Map fields from the line item view model to the data model.
		newplayerstats.Assists = vplayer.Assists;
		newplayerstats.Goals = vplayer.Goals;
		newplayerstats.RedCard = vplayer.Red;
		newplayerstats.YellowCard = vplayer.Yellow;
		//update each player's record (field: GamesPlayed) if they participated (played) in the game independent of having any stats.
		//newplayerstats.Player.GamesPlayed = newplayerstats.Player.GamesPlayed + 1;
	}

	// If it's a new invoice, add it to the collection.
	if (newplayerstats.PlayerID == 0)
	{
		PlayerStats.Add(newplayerstats);
	}
	else
	{
		PlayerStats.Update(newplayerstats);
	}

	// Handle any captured errors.
	if (errorlist.Count > 0)
	{
		// Clear changes to maintain data integrity.
		ChangeTracker.Clear();
		string errorMsg = "Unable to update player stats";
		errorMsg += " Please check error message(s)";
		throw new AggregateException(errorMsg, errorlist);
	}
	else
	{
		// Persist changes to the database.
		SaveChanges();
	}
}