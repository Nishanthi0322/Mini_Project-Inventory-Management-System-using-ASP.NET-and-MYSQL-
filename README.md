
InventoryManagementSystem (.NET 8) - scaffold created by ChatGPT

Steps to run:
1. Install .NET 8 SDK.
2. Ensure MySQL is running and reachable. Update appsettings.json connection string if needed.
3. From the project folder run:
   dotnet restore
   dotnet build
   dotnet run
4. The app will create the database schema automatically (EnsureCreated). For production use, use EF migrations.
