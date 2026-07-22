# Student Management System

Student Management System is a full-stack application developed using ASP.NET Core 8 Web API and Angular 16. It allows authenticated users to manage student records with JWT Authentication and provides a simple user interface for performing CRUD operations.

---

## Features

### Backend

- JWT Authentication
- Student CRUD Operations
- SQL Server Database
- Entity Framework Core
- Repository Pattern
- Service Layer
- Global Exception Handling Middleware
- Serilog Logging
- Swagger API Documentation

### Frontend

- Angular 16
- Login Authentication
- JWT Token Handling
- HTTP Interceptor
- Route Guard
- Student CRUD Pages
- Bootstrap UI
- Toastr Notifications
- Reactive Forms Validation

---

## Technology Stack

### Backend

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Serilog
- Swagger (OpenAPI)

### Frontend

- Angular 16
- TypeScript
- Bootstrap 5
- Reactive Forms
- ngx-toastr

---

## Project Structure

```
StudentManagementSystem
│
├── Backend
│   ├── Controllers
│   ├── Services
│   ├── Repositories
│   ├── DTOs
│   ├── Entities
│   ├── Middleware
│   ├── Helpers
│   ├── Data
│   └── Program.cs
│
└── Frontend
    ├── Components
    ├── Services
    ├── Guards
    ├── Interceptors
    └── app-routing.module.ts
```

---

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/navedans/AssignmentTask_StudentManagementSystem.git
```

---

### 2. Backend Setup

Open the Web API project using **Visual Studio 2022**.

Update the SQL Server connection string in **appsettings.json**.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server Connection String"
}
```

Apply migration

Package Manager Console

```powershell
Update-Database
```

or

```bash
dotnet ef database update
```

Run the API

```bash
dotnet run
```

Swagger

```
https://localhost:<port>/swagger
```

---

### 3. Frontend Setup

Open the Angular project.

Install packages

```bash
npm install
```

Run the application

```bash
ng serve
```

Open

```
http://localhost:4200
```

---

## Authentication

Login Endpoint

```
POST /api/auth/login
```

Sample Request

```json
{
  "userName": "Admin",
  "password": "Admin@2k26"
}
```

After successful login, copy the generated JWT token.

In Swagger click **Authorize** and enter

```
Bearer <your_token>
```

---

## Student API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/students?page=1&size=10 | Get Students |
| POST | /api/students | Add Student |
| PUT | /api/students/{id} | Update Student |
| DELETE | /api/students/{id} | Delete Student |

---

## Logging

Application logging is implemented using Serilog.

Log files are generated inside the **Logs** folder.

---

## Exception Handling

Global Exception Middleware is used to handle unhandled exceptions and return a consistent API response.

---

## Docker Support

Docker configuration files (`Dockerfile` and `.dockerignore`) are included for the Web API.

Build Docker Image

```bash
docker build -t student-management-system-api .
```

Run Docker Container

```bash
docker run -d -p 8080:8080 --name student-api student-management-system-api
```

---

## Default Login Credentials

**Username**

```
Admin
```

**Password**

```
Admin@2k26
```

---

## Author

**Naved**