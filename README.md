# 🏛️ Municipality Management System

A secure web-based citizen management system built with ASP.NET Core MVC and SQL Server. 
Designed to digitise and streamline municipal operations including citizen registration, 
staff management, service request tracking, and complaint reporting — replacing manual 
paper-based processes with a reliable, database-driven application.

---

## What It Does

- **Citizen Management** — Register, update, and delete citizen records including full name, 
  address, phone number, email, and date of birth. Registration date is automatically recorded.
- **Staff Management** — Add, update, and remove staff members with duplicate email validation 
  to maintain data integrity. Tracks position, department, contact details, and hire date.
- **Service Requests** — Log and track citizen service requests with status tracking 
  (Pending → Completed) linked directly to citizen records.
- **Reports & Complaints** — Citizens can submit complaints and reports. Staff can update 
  report statuses and delete resolved cases. Submission date is automatically recorded.

---

## Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 9.0 | Web framework and Razor Pages |
| C# | Backend logic and page models |
| Entity Framework Core 9.0 | ORM for database access |
| SQL Server | Relational database |
| Razor Pages (.cshtml) | Frontend views |
| Bootstrap 5 | UI styling and responsive layout |
| HTML / CSS / JavaScript | Frontend structure and interactivity |

---

## Project Structure

```
MunicipalityManagementSystem2/
│
├── Data/
│   └── ApplicationDbContext.cs     ← EF Core database context
│
├── Models/
│   ├── Citizen.cs                  ← Citizen entity model
│   ├── service.cs                  ← ServiceRequest entity model
│   ├── Reports.cs                  ← Report entity model
│   └── StaffController.cs          ← Staff entity model
│
├── Migrations/                     ← EF Core database migrations
│
├── pages/
│   ├── Index.cshtml                ← Citizen management page
│   ├── Index.cshtml.cs             ← Citizen page model (CRUD logic)
│   ├── StaffController.cshtml      ← Staff management page
│   ├── StaffController.cshtml.cs   ← Staff page model (CRUD logic)
│   ├── Reports.cshtml              ← Reports and complaints page
│   ├── Reports.cshtml.cs           ← Reports page model (CRUD logic)
│   └── Shared/
│       └── _Layout.cshtml          ← Shared layout and navigation
│
├── wwwroot/
│   ├── css/site.css                ← Custom styles
│   └── js/site.js                  ← Custom scripts
│
├── Program.cs                      ← App startup and service registration
├── appsettings.json                ← Database connection configuration
└── MunicipalityManagementSystem2.csproj
```

---

## Key Technical Features

**Entity Framework Core with Code-First Migrations**  
The database schema is defined entirely in C# model classes. EF Core migrations 
track every schema change — from the initial table creation through to adding 
reports and fixing service request tables — giving a full audit trail of how 
the database evolved.

**Data Validation and Integrity**  
- Duplicate email detection on staff registration prevents two staff members 
  sharing the same email address
- Required field validation on service requests and staff records
- Navigation properties link citizens to their service requests and reports 
  enforcing referential integrity at the model level

**Async/Await Throughout**  
All database operations use async methods (`ToListAsync`, `SaveChangesAsync`, 
`FindAsync`) ensuring the application remains responsive under load and does 
not block threads while waiting for database responses.

**Automatic Date Recording**  
Registration dates for citizens and submission dates for reports are set 
automatically in code — removing the possibility of human error in date entry.

**TempData Feedback Messages**  
Success and error messages are passed between page redirects using TempData, 
giving users clear feedback after every create, update, or delete action.

---

## Database Schema

**Citizens**
- CitizenId, FullName, Address, PhoneNumber, Email, DateOfBirth, RegistrationDate

**Staff**
- StaffID, FullName, Position, Department, Email, PhoneNumber, HireDate

**ServiceRequests**
- RequestID, CitizenID (FK), ServiceType, RequestDate, Status

**Reports**
- ReportID, CitizenID (FK), ReportType, Details, SubmissionDate, Status

---

## How to Run

### Prerequisites
- Visual Studio 2022 or later
- .NET 9.0 SDK
- SQL Server (local or remote instance)

### Setup Steps

**1. Clone the repository**
```bash
git clone https://github.com/YOURUSERNAME/MunicipalityManagementSystem.git
```

**2. Configure the database connection**  
Open `appsettings.json` and update the connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MunicipalityDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**3. Apply database migrations**  
Open the Package Manager Console in Visual Studio and run:
```
Update-Database
```
This creates all tables automatically using EF Core migrations.

**4. Run the application**  
Press `F5` in Visual Studio or run:
```bash
dotnet run
```

**5. Open in browser**
```
https://localhost:7xxx
```

---

## Skills Demonstrated

- ASP.NET Core Razor Pages architecture
- Entity Framework Core — code-first design, migrations, DbContext
- C# object-oriented programming — models, constructors, data annotations
- SQL Server database design and management
- Full CRUD operations across multiple related entities
- Asynchronous programming with async/await
- Form validation and duplicate detection
- Responsive UI with Bootstrap 5
- Foreign key relationships and navigation properties

---

## Future Improvements

- Add user authentication and role-based access control (RBAC) so citizens 
  and staff see different views
- Add search and filter functionality to the citizen and staff lists
- Export reports to PDF or Excel
- Add a dashboard page showing summary statistics — total citizens, 
  open service requests, pending reports
- Deploy to Azure App Service with Azure SQL Database

---

*Built with ASP.NET Core 9.0 and Entity Framework Core · .NET 9 · SQL Server*
