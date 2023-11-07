# Movie_API_Test
This is a simple Movie Management Web API

## Prerequisites

Before you begin, ensure you have the following installed:

- .NET 7
- SQL Server LocalDB

## API Endpoints


The application runs on `https://localhost:7161` and provides the following endpoints:

- `GET /api/Movie?MovieId={id}`: Fetches a movie.
- `GET /api/Movie/Movies?PageNumber=1&PageSize=1`: Fetches a list of movies, the PageNumber and PageSize query parameters are optional
- `POST /api/Movie`: Creates a movie.
- `PUT /api/Movie`: Updates a movie.

You can also access the swagger documentation with this URL `https://localhost:7161/swagger/index.html`

## Running the Application
To run the application, follow these steps:

1. Clone the repository.
2. Run the Migration to create your Database, by navigating to the `soft_alliance\src\Soft_Alliance.APP` folder and typing `dotnet ef database update` on your terminal or use `Update-Database`
   in visual studio
3. Open the project in Visual Studio and press `Ctrl + F5` to run the code without debugging. This will open the Swagger UI in your browser.
4. Alternatively, you can run the application from the terminal using the `dotnet run` command. The application's port will be displayed in the terminal.
