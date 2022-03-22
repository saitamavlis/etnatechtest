# ETNATechTest

Technical test for Etna.


## Architecture and Patterns

For solving this test I used the N-Tier architecture, Repository patter and unit of work.

## Technologies

I used .Net Core MVC, EntityFramework (using code first approach), Sql Server, and Bootstrap, as requested.

## Running The App

First of all for running the app you'll need to update the appsettings.json file with the connection string of your database.
"DefaultConnection": "Server=....;DataBase=EtnaShop;User=....; Password=....."
Then on the Package Mannager Console run the command to add migrations (add-migration 'MigrationName'), and after that you should update yuour data base with the command update-database.

## Package needed

This solution needs the following packages to run, please verify that they're installed, otherwise please install them on your solution:

Microsoft.EntityFramework.Core
Microsoft.EntityFramework.Core.SqlServer
Microsoft.EntityFramework.Core.Tools