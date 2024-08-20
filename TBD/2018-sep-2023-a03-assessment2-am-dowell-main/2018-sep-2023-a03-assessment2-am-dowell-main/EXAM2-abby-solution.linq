<Query Kind="Statements">
  <Connection>
    <ID>0db6cfa6-3309-4c4b-9d8f-23c3f1c71c01</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>FSIS_2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// EXAM 2 - Abigail Dowell

//Q1

Guardians
.Where(x => x.Players.Count > 1)
.Select(x => new {
	Name = x.FirstName + " " + x.LastName,
	Children = x.Players.Select(x => new {
		Name = x.FirstName,
		Age = x.Age,
		Gender = x.Gender,
		Team = x.Team.TeamName
		}).OrderBy(x => x.Age)
}).OrderByDescending(x => x.Children.Count())
.Dump();

//Q2

Players
.GroupBy(x => x.Gender)
.Select(x => new {
	Gender = x.Key == "F" ? "Female" : "Male",
	Count = x.Key.Count()
}).Dump();

//Q3

Teams
.Select(x => new {
	Team = x.TeamName,
	Coach = x.Coach,
	Players = x.Players.Select(x => new {
		LastName= x.LastName,
		FirstName = x.FirstName,
		Gender = x.Gender == "F" ? "Female" : "Male",
		Age = x.Age
	}).OrderBy(x => x.LastName)
	.ThenBy(x => x.FirstName)
}).OrderBy(x => x.Team)
.Dump();

//q4

Teams
.Select(x => new {
	TeamName = x.TeamName,
	Wins = x.Wins
})
.GroupBy(x => x.Wins)
.OrderByDescending(x => x.Key)
.FirstOrDefault()
.Select(x => x)
.Dump();

//q5

PlayerStats
.GroupBy(x => x.Player)
.Select(x => new {
	name = x.Key.FirstName + " " + x.Key.LastName,
	teamname = x.Key.Team.TeamName,
	goals = x.Key.PlayerStats.Sum(x => x.Goals),
	assists = x.Key.PlayerStats.Sum(x => x.Assists),
	redcards = x.Key.PlayerStats.Sum(x => x.RedCard == true ? 1 : 0 ),
	yellowcards = x.Key.PlayerStats.Sum(x => x.YellowCard == true ? 1 : 0 )
})
.OrderBy(x => x.name)
.Dump();