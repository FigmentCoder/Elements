Proof of concept Mobile Application using Xamarin Forms

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.17
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.17
dotnet new tool-manifest
dotnet tool install --local dotnet-ef --version 5.0.17

Entity Framework commands
 dotnet ef --startup-project ../Elements.Persistence.Seed migrations add Initial -c ElementsContext
 dotnet ef --startup-project ../Elements.Persistence.Seed migrations remove
 dotnet ef --startup-project ../Elements.Persistence.Seed database update

Windows
Set Startup Project Elements.Persistence.Seed
Set Default Project Persistence\Elements.Persistence
Add-Migration "ExampleMigration"
Update-Database -TargetMigration: "ExampleMigration"
