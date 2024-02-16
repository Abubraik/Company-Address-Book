# Company Address Book
## Database Diagram
![image](https://github.com/Abubraik/Company-Address-Book/assets/69948865/4a8531b8-265b-472d-86c3-8caf5f81db58)

## Prerequisites
- NET Core 8.x SDK
- SQL Server (or any other database you're using)
- Visual Studio, VS Code, or suitable IDE

## Steps

1. **Clone the repository**
   
   ```
   git clone [https://github.com/Abubraik/Company-Address-Book.git]
   ```
3. **Restore dependencies**
   
   Navigate to the project directory and run:
   ```
   dotnet restore
   ```
4. ***Update the database connection string***
   
   Edit the appsettings.json file with the correct connection string.
5. ***Apply migrations**

   Ensure your database is up to date with the latest migrations:
   ```
   dotnet ef database update
   ```

6. ***Run the application***

   ```
   dotnet run
   ```
   or through your IDE
   

