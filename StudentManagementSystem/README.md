# Student Management System API

A RESTful ASP.NET Core 8 Web API for managing student records using JWT Authentication, SQL Server, Entity Framework Core, Serilog Logging, and Global Exception Handling.

---

## Features

- JWT Authentication
- Student CRUD Operations
- SQL Server Database
- Repository Pattern
- Service Layer
- Global Exception Handling Middleware
- Serilog Logging
- Swagger API Documentation
- Layered Architecture

---

## Technology Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Serilog
- Swagger (OpenAPI)

---

## Project Structure

```
StudentManagementSystem
│
├── Controllers
├── Services
├── Repositories
├── DTOs
├── Entities
├── Middleware
├── Helpers
├── Data
├── Common
└── Program.cs
```

---

## Setup Instructions

### 1. Clone the repository

```bash
git clone <YOUR_GITHUB_REPOSITORY_URL>
```

---

### 2. Open the solution

Open the project using **Visual Studio 2022**.

---

### 3. Configure SQL Server

Update the connection string inside **appsettings.json**

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server Connection String"
}
```

---

### 4. Create Database

Run the following command:

Package Manager Console

```powershell
Update-Database
```

or

.NET CLI

```bash
dotnet ef database update
```

---

### 5. Run the Project

Press **F5**

or

```bash
dotnet run
```

Swagger UI will open automatically.

---

## Authentication

Login Endpoint

```
POST /api/auth/login
```

Request

```json
{
  "userName": "admin",
  "password": "Admin@123"
}
```

After login, copy the generated JWT Token.

Click **Authorize** in Swagger and enter

```
<your_token>
```

---

## Student API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/students | Get all students |
| POST | /api/students | Add new student |
| PUT | /api/students/{id} | Update student |
| DELETE | /api/students/{id} | Delete student |

---

## Logging

Serilog is configured for application logging.

Logs are generated inside the **Logs** folder.

---

## Global Exception Handling

A custom Exception Middleware is implemented to handle all unhandled exceptions and return consistent API responses.

---

## Default Login Credentials

Username

```
Admin
```

Password

```
Admin@2k26
```

---

## Author

**Naved**