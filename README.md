CarBook – Onion Architecture with CQRS & MediatR

CarBook is a car rental booking application built to practice maintainable architectures and clean patterns on .NET 8. It follows Onion Architecture with a clear separation of concerns and applies CQRS with MediatR for request handling.
The UI is implemented with ASP.NET Core Razor Pages. Page models handle requests via OnGet*/OnPost* handlers; reusable UI is organized with partials and Tag Helpers. Where needed, AJAX is used to avoid full page reloads and improve UX.
🧠 What I Learned
•	CQRS separates write operations (Commands) from read operations (Queries).
•	Each Command/Query is handled by a dedicated Handler, keeping logic focused and testable.
•	MediatR acts as a mediator between UI and application logic, reducing coupling and improving flexibility.
•	Onion Architecture enforces domain-centric design and isolates infrastructure concerns.
⚙️ Tech Stack & Features
•	.NET 8
•	ASP.NET Core Razor Pages
•	Onion Architecture (Domain, Application, Infrastructure, WebUI)
•	CQRS (Command & Query Handlers)
•	MediatR
•	AutoMapper
•	FluentValidation
•	Entity Framework Core (Code‑First)
•	Dependency Injection, Logging, Configuration
•	AJAX-enhanced interactions for a smoother UX
📁 Typical Solution Layout
•	Domain: Entities, value objects, core contracts
•	Application: CQRS (Commands/Queries), DTOs, Validators, Abstractions
•	Infrastructure: EF Core, repositories, external services
•	WebUI: Razor Pages, PageModels, partials, static assets
