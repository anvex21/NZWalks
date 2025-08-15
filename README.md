# NZWalks 

## Description
NZWalks is a fully-featured backend ASP.NET Core Web API designed to manage walks and regions across New Zealand.
It supports secure user authentication, region and walk CRUD operations, and includes image uploading functionality.

---

## Features
User Authentication & Authorization: 
- Uses ASP.NET Core Identity and JWT tokens for secure access to API endpoints.

Domain Functionality:
- RegionsController: Create, read, update, and delete region data.

- WalksController: Manage walking trails with support for filtering and pagination.

- ImageController: Handles image uploads associated with walks.

Architecture & Tools:
- Entity Framework Core for ORM and data migrations.

- Repository Pattern to abstract data access logic.

- AutoMapper for mapping between entities and DTOs.

- Swagger (Swashbuckle) for auto-generated API documentation.

---

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (Express or full)
- IDE: Visual Studio 2022, Rider or VS Code with C# extension

---

## Getting Started

1. **Clone the repo:**

   ```bash
   git clone https://github.com/anvex21/NZWalks.git
   cd eshop

2. **Update connection string**
  Edit appsettings.json to set your SQL Server connection string, e.g.:
  ```bash
  "ConnectionStrings": {
      "DefaultConnection": "Your-connection-string-here"
  }
  ```

3. **Apply migrations and update database**
  ```bash
  dotnet ef database update
  ```

4. Run the application using F5

5. Use Swagger UI to test endpoints.

