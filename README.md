## 🚗 Project Overview

CarBook is a full-stack car rental platform designed as a learning project to implement modern .NET architecture principles in a real-world scenario.  
The application follows a **clean, layered structure based on Onion Architecture**, ensuring clear separation between the domain, application logic, infrastructure, and UI layers.

The system uses **CQRS with MediatR** to isolate queries and commands, making the business logic more maintainable and test-friendly. A dedicated **ASP.NET Core Web API** serves as the backend layer, exposing endpoints documented with **Swagger/OpenAPI** and consumed securely through **JWT-based authentication** with role-based authorization.

On the frontend, the project uses **ASP.NET Core MVC with Razor Views**, partial components, and an admin area. The user experience is enhanced through modern UI libraries, reusable UI patterns, and **real-time communication powered by SignalR**.

Overall, CarBook brings together architecture, security, data management, and modern UI concepts into a complete, hands-on software learning experience.

---

## 🧠 What I Learned

- Principles of **clean architecture** and how Onion Architecture separates domain logic from infrastructure.
- How **CQRS and MediatR** simplify command/query responsibilities and improve code maintainability.
- Implementing **Repository + Unit of Work** patterns for controlled data access and persistence.
- Designing secure applications using **JWT authentication**, role-based authorization, and Identity.
- Building and consuming **Web APIs** using Swagger, HttpClientFactory, and DTO-based communication.
- Applying **EF Core migrations**, soft-delete design, model validation, and mapping using FluentValidation and AutoMapper.
- Integrating **real-time messaging** with SignalR and managing cross-origin communication via CORS policies.
- Structuring a production-like MVC UI using Razor Pages, areas, partials, and reusable components.

---

## ⚙️ Technologies & Tools

### **Platform & Architecture**
- .NET 8  
- ASP.NET Core MVC (Razor Views)
- Onion Architecture  
- Repository + Unit of Work  
- CQRS with MediatR  

### **Backend**
- ASP.NET Core Web API  
- Swagger / OpenAPI  
- HttpClientFactory  
- SignalR Hub (real-time messaging)

### **Authentication & Security**
- ASP.NET Core Identity (IdentityDbContext)
- JWT Bearer Authentication  
- Role-based authorization

### **Data & ORM**
- Entity Framework Core (SQL Server)
- EF Core Migrations
- Soft-delete pattern

### **Mapping & Validation**
- AutoMapper  
- FluentValidation  

### **Frontend UI**
- Razor Pages + Areas (Admin panel)
- Bootstrap UI, custom SCSS theme
- Paging: X.PagedList  
- JavaScript ecosystem:
  - jQuery, Moment.js, Select2, DataTables, Quill
  - DateRangePicker, Bootstrap Datepicker, Touchspin, Switchery
  - Chart.js, Morris.js, Google Charts, jVectorMap, GMaps.js
  - AOS, Owl Carousel, Magnific Popup, Waves.js  

### **Real-Time Client**
- SignalR JavaScript Client (8.x)

### **General Practices**
- DTO-based communication between layers  
- Strongly-typed configuration using Options Pattern  
