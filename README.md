# KneatSoftware

This is a repository to make the challange of Kneat software

The application consists of a console application done in .NET Core 3.1 that makes a request to an public web API called *[swapi api](https://swapi.co/)*
The request is going to return for us all the starships avaible on their API. 

The program works based on the total o MGLT(Megalights) that you can pass and 
the program will do the calculations to discover how many stops the StarShips need to do to reach its goal.

## How to use

Make sure you have installed on you machine the *.NET Core 3.1*. If you don´t have that, you can simply download here 
[.NET CORE 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
You can clone the project on your machine, an run on VisualStudio(2019 preferable), or VisualStudio Code. 
The programm, as mention above, will receive a total of MGLT
and will do the calculation of how many stops the StarShips need to do to reach its goal.
Basically you just need to run the project, and insert the total of MGLT and the program will do the rest.

The response of the programm will be a collection of all the starships with the total of stops

## Tips

If you type something that is not a number, that programm will stop automatically and will not continue running.
There are a few starships that is not returng the fields MGLT or Consumables. So, when it´s not returned thoses values, I´m simply returning the name of the starships
and 0 as total of stops. Without those values, I can make the calculation.

### Plugins Used

* XUNIT - To create the tests of the application
* NewtonSoft.JSON - It´s used to deserialize objects comming from the API of SWAPI
* .NET Core 3.1 - It´s not a plugin but it´s good to mention here
