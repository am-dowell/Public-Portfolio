<Query Kind="Program">
  <Connection>
    <ID>c713f776-4f0d-4868-9fff-00b999a4dc88</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
    <DisplayName>WorkScheduleEntity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//  YOUR NAME HERE: Abigail Dowell
	
	/*
	KNOWN ERRORS:
	
	- Save does not add individual skills, not sure why.
	- Not sure where SkillID 12 is coming from as I did define it in the Driver
	
	ASK JAMES ABOUT THIS, followed AddEditInvoiceUsingMain example.
	Very tricky to add items to a list, that threw me for a loop for DAYSSS
	*/
	

	#region Driver  //  3 Marks
	try
	{
		//  The driver must, at minimum perform three different task. 
		//  Task 1
		//  -   Add a new employee and register their skills (minimun of two skills). 

		//	before action (Add)
		EmployeeRegistrationView beforeAdd = new EmployeeRegistrationView();
		beforeAdd.EmployeeID = 1;
		beforeAdd.FirstName = "Abby";
		beforeAdd.LastName = "Dowell";
		beforeAdd.HomePhone = RandomPhoneNumber();
		
		EmployeeSkillView skill = new EmployeeSkillView();
		skill.HourlyWage = 15.00m;
		skill.Level = 1;
		skill.YearsOfExperience = 2;
		skill.EmployeeID = beforeAdd.EmployeeID;
		skill.SkillID = 1;
		skill.EmployeeSkillID = 1;
		beforeAdd.EmployeeSkills.Add(skill);

		EmployeeSkillView skill2 = new EmployeeSkillView();
		skill2.HourlyWage = 15.00m;
		skill2.Level = 1;
		skill2.YearsOfExperience = 1;
		skill2.EmployeeID = beforeAdd.EmployeeID;
		skill2.SkillID = 2;
		skill2.EmployeeSkillID = 2;
		beforeAdd.EmployeeSkills.Add(skill2);

		//skill = new EmployeeSkillView();
		//skill.HourlyWage = 15.00m;
		//skill.Level = 1;
		//skill.YearsOfExperience = 1;
		//skill.EmployeeID = beforeAdd.EmployeeID;
		//skill.SkillID = 1;
		//skill.EmployeeSkillID = 1;
		//beforeAdd.EmployeeSkills.Add(skill);

		//	showing results
		beforeAdd.Dump("Before Add");

		//	execute
		EmployeeRegistrationView afterAdd = AddEditEmployeeRegistration(beforeAdd);

		//	after action (Add)
		//	showing results
		afterAdd.Dump("After Add");

		//  Task 2 update an employee and their skill list. 
		//  -   Updating their first or last name
		//  -   Updating one existing skill
		//  -   adding a minimum of one new skill

		EmployeeRegistrationView beforeEdit = new EmployeeRegistrationView();
		beforeEdit.EmployeeID = 1;
		beforeEdit.FirstName = "Abigail";
		beforeEdit.LastName = "Dowell";
		beforeEdit.HomePhone = RandomPhoneNumber();
		//beforeEdit.EmployeeSkills[1].HourlyWage = 17.00m;

		skill.HourlyWage = 15.00m;
		skill.Level = 1;
		skill.YearsOfExperience = 1;
		skill.EmployeeID = beforeAdd.EmployeeID;
		skill.SkillID = 1;
		skill.EmployeeSkillID = 1;
		beforeEdit.EmployeeSkills.Add(skill);

		//	showing results
		beforeEdit.Dump("Before Edit");

		//	execute
		EmployeeRegistrationView afterEdit = AddEditEmployeeRegistration(beforeEdit);

		//	after action (Edit)
		//	showing results
		afterEdit.Dump("After Edit");

		//  Task 3 attempts to register new skills with invalid data that will trigger all the business in this exercise
		//  Refer to business rules for all test cases

		//	before action (Add)
//fails because missing last name
		EmployeeRegistrationView badAddBefore = new EmployeeRegistrationView();
		badAddBefore.EmployeeID = 1;
		badAddBefore.FirstName = "Abby";
		badAddBefore.LastName = "";
		badAddBefore.HomePhone = RandomPhoneNumber();

//fails because invalid hourly wage
		EmployeeSkillView badSkill = new EmployeeSkillView();
		badSkill.HourlyWage = 0.00m;
		badSkill.Level = 1;
		badSkill.YearsOfExperience = 1;
		badSkill.EmployeeID = beforeAdd.EmployeeID;
		badSkill.SkillID = 1;
		badSkill.EmployeeSkillID = 1;
		badAddBefore.EmployeeSkills.Add(badSkill);
//fails because years of experience (>50)
		badSkill = new EmployeeSkillView();
		badSkill.HourlyWage = 15.00m;
		badSkill.Level = 3;
		badSkill.YearsOfExperience = 70;
		badSkill.EmployeeID = beforeAdd.EmployeeID;
		badSkill.SkillID = 2;
		badSkill.EmployeeSkillID = 2;
		badAddBefore.EmployeeSkills.Add(badSkill);

		//	showing results
		badAddBefore.Dump("Before BAD Add");

		//	execute
		afterAdd = AddEditEmployeeRegistration(badAddBefore);

		//	after action (Add)
		//	showing results
		afterAdd.Dump("After BAD Add");
	}
	#endregion

	#region catch all exceptions 
	catch (AggregateException ex)
	{
		foreach (var error in ex.InnerExceptions)
		{
			error.Message.Dump();
		}
	}
	catch (ArgumentNullException ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	catch (Exception ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	#endregion
}
private Exception GetInnerException(Exception ex)
{
	while (ex.InnerException != null)
		ex = ex.InnerException;
	return ex;
}



#region Methods

#region AddEditEmployeeRegistration Method   //  6 Marks
public EmployeeRegistrationView AddEditEmployeeRegistration(EmployeeRegistrationView employeeRegistration)
{
	// --- Business Logic and Parameter Exception Section --- 
#region Business Logic and Parameter Exception  //  2 Marks
	// - First name, last name, and phone number are mandatory fields.
	// - For a new employee, at least one new valid skill must be added.
	// - You may update the skill of an existing employee.However, all employee information is required.
	// - No new skills are required if you are updating employee personal information(First / Last Name) for an existing employee.
	// - Active should be set to true.
	

	List<Exception> errorList = new List<Exception>();


	if (string.IsNullOrWhiteSpace(employeeRegistration.FirstName))
	{
		errorList.Add(new Exception("First name is required"));
	}
	if (string.IsNullOrWhiteSpace(employeeRegistration.LastName))
	{
		errorList.Add(new Exception("Last name is required"));
	}
	if (string.IsNullOrWhiteSpace(employeeRegistration.HomePhone))
	{
		errorList.Add(new Exception("Phone number is required"));
	}
	// Check if this is a new employee

	if (employeeRegistration.EmployeeSkills.Count == 0)
	{
		errorList.Add(new ArgumentException("For a new employee, at least one new valid skill must be added."));
	}

	//	Individuals can possess multiple skills.Each skill selection must adhere to the following:
	//		- A valid "Level" is required.
	//		-"Years of Experience"(YOE) is optional but must meet specific criteria:
	//		- YOE must be a positive, non - zero integer or null.
	//		- If YOE is provided, it must fall within the range of 1 to 50(inclusive).
	//	"Hourly Wage" is required and must meet these conditions:
	//		-Hourly Wage should be a positive, non-zero decimal.
	//		-Hourly Wage must be within the range of $15.00 to $100.00(inclusive).

	employeeRegistration.Active = true;

	foreach (var skill in employeeRegistration.EmployeeSkills)
	{
		if (skill.Level < 1 || skill.Level > 5)
		{
			errorList.Add(new ArgumentException("A valid 'Level' is required for skills (1-5)."));
		}

		if (skill.YearsOfExperience.HasValue)
		{
			if (skill.YearsOfExperience < 1 || skill.YearsOfExperience > 50)
			{
				errorList.Add(new ArgumentException("Years of Experience must be between 1 to 50, or null."));
			}
		}

		if (skill.HourlyWage <= 0 || skill.HourlyWage < 15.00m || skill.HourlyWage > 100.00m)
		{
			errorList.Add(new ArgumentException("Hourly Wage must be a positive decimal between $15.00 to $100.00."));
		}
	}



	#endregion

	// --- Main Method Logic Section --- 
	#region Method Code //  3 Marks
	//stole invoice example thanks james :)

	Employees employee = Employees
							.Where(x => x.EmployeeID == employeeRegistration.EmployeeID)
							.FirstOrDefault();

	// If the employee doesn't exist, initialize it.
	if (employee == null)
	{
		employee = new Employees();
	}

	employee.EmployeeID = employeeRegistration.EmployeeID;
	employee.FirstName = employeeRegistration.FirstName;
	employee.LastName = employeeRegistration.LastName;
	employee.HomePhone = employeeRegistration.HomePhone;
	employee.Active = true;

	// Actual logic to add or edit data in the database goes here. 

	// Process each line item in the provided view model.
	foreach (var employeeSkill in employeeRegistration.EmployeeSkills)
	{
		EmployeeSkills skill = EmployeeSkills
									.Where(x => x.EmployeeSkillID == employeeSkill.EmployeeSkillID)
									.FirstOrDefault();

		// If the line item doesn't exist, initialize it.
		if (employeeSkill == null)
		{
			skill = new EmployeeSkills();
		}

		// Map fields from the line item view model to the data model.
		skill.HourlyWage = employeeSkill.HourlyWage;
		skill.Level = employeeSkill.Level;
		skill.YearsOfExperience = employeeSkill.YearsOfExperience;

		// Handle new or existing line items.
		if (skill.EmployeeSkillID == 0)
		{
			employee.EmployeeSkills.Add(skill); // Add new line items.
		}
		else
		{
			EmployeeSkills.Update(skill); // Update existing line items.
		}
	}
	#region Check for errors and saving of data //  1 Marks

	// --- Error handling and saving
	if (errorList.Count() > 0)
	{
		throw new AggregateException("Unable to proceed!  Check concerns", errorList);
	}
	else
	{
		//SaveChanges();
		if (employee.EmployeeID == 0)
		{
			Random rand = new Random();
			employee.EmployeeID = rand.Next(1, 100); //returns random number between 1-99
		}
		
		SaveChanges();
	}

	return GetEmployeeRegistration(employee.EmployeeID);

	#endregion
	return null;
}
#endregion

#endregion

#region GetEmployeeRegistration Method    //  1 Marks
//  your code here

public EmployeeRegistrationView GetEmployeeRegistration(int employeeID)
{
	#region Business Logic and Parameter Exception
	//	employee must exist in the database
	if (employeeID == 0)
	{
		throw new ArgumentNullException("Please provide a employee id");
	}
	//	if the employee does not exist, no reason to continue in the process 
	EmployeeRegistrationView employee = Employees
									.Where(x => x.EmployeeID == employeeID)
									.Select(x => new EmployeeRegistrationView
									{
										EmployeeID = x.EmployeeID,
										FirstName = x.FirstName,
										LastName = x.LastName,
										HomePhone = x.HomePhone,
										Active = x.Active,
										EmployeeSkills = EmployeeSkills
											.Where(es => es.EmployeeID == x.EmployeeID)
											.Select(es => new EmployeeSkillView
											{
												EmployeeID = es.EmployeeID,
												EmployeeSkillID = es.EmployeeSkillID,
												HourlyWage = (decimal) es.HourlyWage,
												Level = es.Level,
												SkillID = es.SkillID,
												YearsOfExperience = es.YearsOfExperience
											}).ToList()
									}).FirstOrDefault();
	#endregion
	return employee;
}


#endregion

#endregion

/// <summary> 
/// Contains class definitions that are referenced in the current LINQ file. 
/// </summary> 
/// <remarks> 
/// It's crucial to highlight that in standard development practices, code and class definitions  
/// should not be mixed in the same file. Proper separation of concerns dictates that classes  
/// should have their own dedicated files, promoting modularity and maintainability. 
/// </remarks> 
#region Class/View Model   

public class EmployeeRegistrationView
{
	public int EmployeeID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string HomePhone { get; set; }
	public bool Active { get; set; }
	public List<EmployeeSkillView> EmployeeSkills { get; set; } = new();
}

public class EmployeeSkillView
{
	public int EmployeeSkillID { get; set; }
	public int EmployeeID { get; set; }
	public int SkillID { get; set; }
	public int Level { get; set; }
	public int? YearsOfExperience { get; set; }
	public decimal HourlyWage { get; set; }
}

#endregion

#region Supporting Methods
/// <summary>
/// Generates a random phone number.
/// The generated phone number ensures the first digit is not 0 or 1.
/// </summary>
/// <returns>A random phone number.</returns>
public static string RandomPhoneNumber()
{
	var random = new Random();
	string phoneNumber = string.Empty;

	// Ensure the first digit isn't 0 or 1.
	int firstDigit = random.Next(2, 10); // Generates a random digit between 2 and 9.
	phoneNumber = $"{firstDigit}";

	// Generate the rest of the digits.
	for (int i = 1; i < 10; i++)
	{
		int currentDigit = random.Next(10);
		phoneNumber = $"{phoneNumber}{currentDigit}";

		// Add periods after every third digit (except for the last period).
		if (i % 3 == 2 && i != 8)
		{
			phoneNumber = $"{phoneNumber}.";
		}
	}

	return phoneNumber;
}

/// <summary>
/// Generates a random name of a given length.
/// The generated name follows a pattern of alternating consonants and vowels.
/// </summary>
/// <param name="len">The desired length of the generated name.</param>
/// <returns>A random name of the specified length.</returns>
public static string GenerateName(int len)
{
	// Create a new Random instance.
	Random r = new Random();

	// Define consonants and vowels to use in the name generation.
	string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
	string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

	string Name = "";

	// Start the name with an uppercase consonant and a vowel.
	Name += consonants[r.Next(consonants.Length)].ToUpper();
	Name += vowels[r.Next(vowels.Length)];

	// Counter for tracking the number of characters added.
	int b = 2;

	// Add alternating consonants and vowels until we reach the desired length.
	while (b < len)
	{
		Name += consonants[r.Next(consonants.Length)];
		b++;
		Name += vowels[r.Next(vowels.Length)];
		b++;
	}

	return Name;
}
#endregion