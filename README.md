# KneatSoftware

This is a repository to make the challange of Kneat software

The application consists of an console application done in .NET Core 3.1 that makes a request to an public web API called *[swapi api](https://swapi.co/)*
The request is going to return for us all the starships avaible on their API. 

The program works based on the total o MGLT(Megalights) that you can pass and 
the program will do the calculations to discover how many stops the StarShips need to do to reach its goal.

## How to use

Make sure you have installed on your machine the *.NET Core 3.1*. If you don´t have that, you can simply download here 
[.NET CORE 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

You can clone the project on your machine, an run on VisualStudio(2019 preferable), or VisualStudio Code. 
The program, as mention above, will receive a total of MGLT and will do the calculation of how many stops the StarShips need to do to reach it´s goal.
Basically you just need to run the project, and insert the total of MGLT and the program will do the rest.

The response of the program will be a collection of all the starships with the total of stops

## How It Works

From the response of the web API we are receiving a JSON that has all the starships. On that response, we have a few fields like: Name, Model, Manufacturer,Cost_in_credits Length, etc...

To make the calcs we need basically two fields that comes from that response: MGLT (The Maximum number of Megalights this starship can travel in a standard hour), and
Consumables (The maximum length of time that this starship can provide consumables for its entire crew without having to resupply). The consumables is returning like:
2 years for example.

So, with that in mind, what I do it´s basically catchy the consumables * the total of hours that the consumables has. For example: Millennium Falcon has an consumable of
2 months, so I do 2 * 730.001 (this value is the total amount of hours per month). After I do that calculation, I make another one that is the amount of MGLT of the starship * that value that I have.

Inside of an loop I check if the MGLT * Total of hours is less or equal to the MGLT passed on the console application. Foreach of that, I increase a counter of the total of stops done to resupply

## Tips

If you type something that is not a number, that program will stop automatically and will not continue running.

There are a few starships that is not returning the fields MGLT or Consumables. So, when it´s not returned those values, I´m simply returning the name of the starship
and 0 as total of stops. Without those values, I can make the calculation.

### Plugins Used

* XUNIT - To create the tests of the application
* NewtonSoft.JSON - It´s used to deserialize objects comming from the API of SWAPI
* .NET Core 3.1 - It´s not a plugin but it´s good to mention here
