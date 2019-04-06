# AspNet Core Web Api Template

The purpose of this template is to save time starting a DotNet Core WebApi with all the initial settings required.  

## Patterns
* DDD  
* Repository  
* Unit of Work  


## Dependency Injection
At the moment I'm using the built-in container from AspNet Core.  
If you need a specific feature that the built-in container doensn't support you can choose a 3rd party container.  
Features not found in the built-in container:  
* Property injection  
* Injection based on name  
* Child containers  
* Custom lifetime management  
* Func<T> support for lazy initialization  

See the Dependency Injection readme.md file for a list of some of the containers that support adapters.  
https://github.com/aspnet/Extensions/tree/master/src/DependencyInjection  


## Database
I'm configuring SQL Server as an example, but you can quickly change it to use the database of your choice.  
You need to change it in Startup.cs and in *.Infrastructure project.  
Don't forget to uninstall references to Microsoft.EntityFrameworkCore.SqlServer and install the new ones.  


## Renaming .csproj .sln namespaces etc
*Important*:  
Before running the PowerShell script, you should either move it out of the project folder  
or make some modifications to run it from within the project folder.  
After clone the repository run the PowerShell script "Renaming.ps1".  
It'll rename the folders, solution, projects, namespaces and so one to the new name you choose.


## Versions (you can update this verions if you need)
AspNet Core / DotNet Core 2.2  
Microsoft.EntityFrameworkCore.SqlServer 2.2.3  
AutoMapper.Extensions.Microsoft.DependencyInjection 6.0.0  
Microsoft.Extensions.Logging.Log4Net.AspNetCore 2.2.10  
Swashbuckle.AspNetCore 4.0.1  
nunit 3.11.0  
NUnit3TestAdapter 3.12.0  
Microsoft.NET.Test.Sdk 15.9.0  