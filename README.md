# Todo Backend API

The repository defines a simple Todo Backend APIs by using .Net Core and Postgresql.

## Installation 
This project requires .NET 6.0 or newer.

## Getting Started 
1. Clone the repository to your local machine and navigate to the project directory.
    ```shell
    git clone https://github.com/qawsedr87/dotnet-todo-api.git
    cd dotnet-todo-api
    ```

2. Start docker container for postgresql 
    - The configuration for the application and its dependencies (PostgreSQL) can be found in the `./psql_db.yaml` file. You can start the contaners using the `docker-compose` up command.
    ```shell
    docker-compose -f ./psql_db.yaml up
    ```

    - Dependency 
    ```
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="7.0.0" />
    ```

    - Database Connection:  In the `appsettings.json` file, provide the necessary connection string details under the appropriate configuration section.
    ```json
    "ConnectionStrings": {
        "WebApiDatabase": "Host=<Host>; Port=<Port>; Database=<Database>; Username=<Username>; Password=<Password>"
    },
    ```
3. Database Migration in Entity Framework Core
    - Installation 
    ```
    dotnet tool install --global dotnet-ef
    ```

    - Apply Migrations: Once you're satisfied with the generated migration, apply it to your database using the following command:
    ```
    dotnet ef database update
    ```

    - For more details: [Migration EF Core](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

4. Run the application
    ```shell
    dotnet run
    ```

5. Check if the swagger works by visting https://localhost:7209/swagger

