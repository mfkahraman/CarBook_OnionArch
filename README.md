# 🚗 Project Overview

CarBook is a full-stack car rental system built as a learning and practice project for modern .NET development.
The application uses Onion Architecture to keep the project clean, organized, and easy to maintain. Each layer has a clear responsibility: domain logic, application rules, infrastructure services, and UI.

The project follows the CQRS pattern with MediatR, splitting commands and queries to make the code easier to understand and extend.
User management and security are handled with Identity + JWT, allowing authentication, role control, and protected API access.

The backend WebAPI layer includes 94 endpoints, and all of them are consumed by the WebUI. This creates a real end-to-end structure where the UI communicates with the API through DTOs and HttpClientFactory.
During development, I expanded the original course project and rebuilt many parts using my own experience.

## 🔹 Key Improvements & Custom Features

- SignalR real-time messaging for user support
- ImageService added for image handling
- Unit of Work implementation for better database flow
- Extension-based service registration for cleaner startup configuration
- New API endpoints added beyond the original scope
- Several best practices applied (async/await, status code checks, DTO boundaries, clean validation patterns)
- UI improvements with Razor Pages + MVC structure
- Modern notifications using SweetAlert

Overall, the project now works as a complete API + WebUI system designed with real-world patterns, scalable structure, and clean architectural principles.

## 🧠 What I Learned

- How Onion Architecture separates responsibilities and keeps the project maintainable
- How CQRS and MediatR simplify business logic and improve extendability
- Implementing JWT authentication and role-based authorization with Identity
- Using Repository + Unit of Work to manage data operations safely
- Building and consuming APIs with Swagger, HttpClientFactory, and DTO-based communication
- Applying FluentValidation and AutoMapper for cleaner input control and mapping
- Adding real-time features with SignalR
- Managing images, TempData flow, and service registration through extension methods
- Creating a structured UI using Razor Pages, partial views, and reusable components
- Improving UX with SweetAlert, pagination, and organized data handling
- Calling all 94 backend endpoints from the WebUI to create a complete end-to-end application

## ⚙️ Technical Highlights

### 🧩 Core Stack

- ASP.NET Core Web API
- Razor Pages + MVC Controllers
- IHttpClientFactory (REST)
- Full async/await usage

### 🏛️ Architecture

- Onion Architecture
- Layering: Core / Application / Domain / Infrastructure / WebAPI / WebUI
- DTO-based communication
- Service registrations via Extensions

### 🧠 Key Features & Design Patterns

- CQRS + MediatR
- Repository Pattern
- Unit of Work Pattern
- AutoMapper
- FluentValidation
- JWT + Microsoft Identity
- SignalR real-time messaging
- SweetAlert notifications

### 🖥️ WebUI Workflow

- Car listing with server-side pagination
- Availability search
- Reservation creation & pricing logic
- TempData-based data passing
- Error fallback pages




https://github.com/user-attachments/assets/5be9b7d4-5d91-41cf-b69e-8f24f62bfb1a

https://github.com/user-attachments/assets/643fb75d-a2e9-48f0-993e-db0863c2dc9c

https://github.com/user-attachments/assets/d3e4c10b-1c4e-4211-9cca-8223127cd92f

https://github.com/user-attachments/assets/9db03c92-97f4-462d-996b-11f45aebe955

https://github.com/user-attachments/assets/39c6fba1-e04f-473a-b7e3-18e63a4474f3


<img width="1272" height="876" alt="1" src="https://github.com/user-attachments/assets/18687d64-9625-406e-bc8d-6f74261a48d3" />
<img width="1458" height="778" alt="2" src="https://github.com/user-attachments/assets/849a7bca-c9c9-49c6-8fb6-10b433fa7025" />
<img width="1051" height="890" alt="3" src="https://github.com/user-attachments/assets/79d3cde7-87a7-49fc-bcbe-57a1216203f0" />
<img width="864" height="895" alt="4" src="https://github.com/user-attachments/assets/9f6e6347-0373-4f04-bd6a-639641712976" />
<img width="928" height="903" alt="5" src="https://github.com/user-attachments/assets/f66d1333-8bdb-4028-8c67-54e3f7908e1e" />
<img width="1094" height="907" alt="6" src="https://github.com/user-attachments/assets/23a3e2b7-78c4-4ff0-8d75-5fc0384b1463" />
<img width="564" height="828" alt="7" src="https://github.com/user-attachments/assets/ff278e9b-dd98-4625-9443-d80d41353ca5" />
<img width="1375" height="920" alt="8" src="https://github.com/user-attachments/assets/acd62c2a-f964-4589-ab5d-b3bce0ce859c" />
<img width="1011" height="807" alt="9" src="https://github.com/user-attachments/assets/7587a569-0e34-4d72-8462-50dfb86ebcf4" />
<img width="999" height="837" alt="10" src="https://github.com/user-attachments/assets/ca1f3b0b-325c-41a3-b8af-df3763f6a0d9" />
<img width="1890" height="907" alt="12" src="https://github.com/user-attachments/assets/9900edf4-b788-4d63-ac79-6a55a2b559d7" />
<img width="1896" height="629" alt="13" src="https://github.com/user-attachments/assets/1902a6c2-10ed-4368-86b5-d78234e4bebf" />
<img width="1893" height="920" alt="11" src="https://github.com/user-attachments/assets/a5fcca53-5531-4586-8361-8816fac65889" />
<img width="1717" height="869" alt="15" src="https://github.com/user-attachments/assets/5f07fa2b-a164-4510-a49d-9047ae24a681" />
<img width="1722" height="866" alt="16" src="https://github.com/user-attachments/assets/d4d5c321-0ca7-4363-a483-ae2ac4df53e5" />
<img width="1896" height="801" alt="14" src="https://github.com/user-attachments/assets/3cfb6898-123c-4e64-9499-34d50c7e488d" />
<img width="1878" height="827" alt="17" src="https://github.com/user-attachments/assets/ec9fcb82-ba7f-4f28-949f-5fe721f8db3f" />
<img width="1899" height="810" alt="18" src="https://github.com/user-attachments/assets/1a65dd88-e755-4add-96f8-e4ffc59c2a4b" />
<img width="1856" height="777" alt="19" src="https://github.com/user-attachments/assets/cabc7660-826a-44fb-954e-fa6796f8f3e0" />
<img width="1059" height="912" alt="20" src="https://github.com/user-attachments/assets/109284bd-2401-497c-aa16-e5f5fada8b35" />
<img width="1062" height="911" alt="21" src="https://github.com/user-attachments/assets/cf524b97-11a9-4cdb-a239-88a01873340e" />
<img width="965" height="911" alt="22" src="https://github.com/user-attachments/assets/579c9cae-5af9-4085-a7ed-4eb64b28e4a6" />
