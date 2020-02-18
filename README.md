# PrototypeBackend
Web Api based backend for StarWars app

## Technology Stack
This project is created using ASP .NET MVC Web API to provide backend for the application.

## Completed Steps
- Created project PrototypeBackend using ASP .NET web api
- Created a second project called PrototypeDataAccess which contains ADO.NET Entity Data Model that retrieves the data from the SQL SERVER and added its reference to main project.
- Created a controller called FilmController.cs inside PrototypeBackend Controllers which is our main controller for fetching data.
- Created 4 get actions for 4 different required tasks in the assignment.
- Published the code on GitHub and also deployed the api on AWS. Response data can be seen using following URLs

1. http://starwars.us-west-2.elasticbeanstalk.com/api/film/LongestOpeningCrawl
2. http://starwars.us-west-2.elasticbeanstalk.com/api/film/MostAppearencesCharacter
3. http://starwars.us-west-2.elasticbeanstalk.com/api/film/MostAppearencessSpecies
4. http://starwars.us-west-2.elasticbeanstalk.com/api/film/MostPlanetVehicles

