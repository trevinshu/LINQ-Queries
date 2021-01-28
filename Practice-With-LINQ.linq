<Query Kind="Statements">
  <Connection>
    <ID>15cd551d-58e7-4c74-8e7b-8a37086cd3ce</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List all customers in alphabetic order by last name, first name who live in the USA.

var country = "USA";
//Query Syntax
var results = from x in Customers where x.Country.Contains(country) orderby x.FirstName, x.LastName
select new 
			{
			 FirstName = x.FirstName,
			 LastName = x.LastName,
			 FullName = x.LastName + ", " + x.FirstName
			};
//We need to display the content of the results. 
//In LinqPad use the application method .Dump()
//Use .Contains() if you don't need an exact match. Otherwise use Ex. x.Country == country 

results.Dump();

//Method Syntax
results = Customers 
.Where(x => x.Country.Contains(country))
.OrderBy(x => x.LastName)
.ThenBy(x => x.FirstName)
.Select(x => new 
{
 FirstName = x.FirstName,
 LastName = x.LastName,
 FullName = x.LastName + ", " + x.FirstName
});

results.Dump();

//NEW PROBLEM

//Create an alphabetic list of albums by ReleaseLabel
//Albums missing labels will be listed as "Unknown"

//Method Syntax
var results3 = Albums 
		.OrderBy(x => x.ReleaseLabel)
		.Select(x => new 
					{
					Title = x.Title,
					Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
					});
results3.Dump();

//Query Syntax
var results4 = from x in Albums orderby x.ReleaseLabel 
				select new
				{
				Title = x.Title,
				Label = x.ReleaseLabel == null ? "Unknown" : x.ReleaseLabel
				};
results4.Dump();

//NEW PROBLEM
//Create an alphabetic list of albums by decades 70s, 80s, 90s & "others"
//List title & decade


//Query Syntax
var results5 = from x in Albums 
					select new 
					{
					Title = x.Title,
					Year = x.ReleaseYear,
					Decade = x.ReleaseYear >= 1970 && x.ReleaseYear < 1980 ? "70's" :
							 x.ReleaseYear >= 1980 && x.ReleaseYear < 1990 ? "80's" :
						     x.ReleaseYear >= 1990 && x.ReleaseYear < 2000 ? "90's" : "Others"
					};
results5.Dump();

//Method Syntax
var results6 = Albums
			.Select(x => new 
							{
							Title = x.Title,
							Year = x.ReleaseYear,
							Decade = x.ReleaseYear >= 1970 && x.ReleaseYear < 1980 ? "70's" :
									 x.ReleaseYear >= 1980 && x.ReleaseYear < 1990 ? "80's" :
									 x.ReleaseYear >= 1990 && x.ReleaseYear < 2000 ? "90's" : "Others"
							});
results6.Dump();


