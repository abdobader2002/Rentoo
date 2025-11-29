# Rentoo

A cleanly-architected **MVC-based rental management platform** built using a layered Clean Architecture.  
Rentoo separates concerns into Web, Application, Domain, and Infrastructure layers to support **maintainable, testable, and scalable development**.

> Short: Rentoo is an ASP.NET Core **MVC** rental application structured into `Web`, `Application`, `Domain`, and `Infrastructure` projects to ensure clean separation, modularity, and long-term extensibility.

---

## Repository layout

- `Rentoo.Web` — MVC Web UI (Controllers, Views, ViewModels, static assets).  
- `Rentoo.Application` — Business logic, Application services, DTOs, use-cases.  
- `Rentoo.Domain` — Core domain layer (Entities, Value Objects, Enums, domain rules).  
- `Rentoo.Infrastructure` — EF Core DbContext, database mappings, repository implementations.  
- `Rentoo.sln` — Solution file.

---

## Key features

- Clean Architecture separation (Web / Application / Domain / Infrastructure).  
- ASP.NET Core **MVC** web application.  
- EF Core database layer using Repository Pattern.  
- Strong domain modeling (entities, value objects, enums).  
- Fully maintainable and easy to extend.  
- Pre-structured for  APIs, or microservices later.  
- Ready for Docker and CI/CD enhancements.

---

## Tech stack

- **Language:** C#  
- **Framework:** ASP.NET Core MVC  
- **Architecture:** Clean Architecture + Repository Pattern  
- **ORM:** Entity Framework Core  
- **Database:** SQL Server  
- **Frontend:** Razor Views, Bootstrap  
- **Tools:** Visual Studio / VS Code, GitHub, Git, Docker (optional), GitHub Actions (optional)

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/) installed (match the project's target framework).  
- SQL Server (local or remote).  
- Git.  

---

## Quick Start (Local)

### 1. **Clone repository**
```bash
git clone https://github.com/abdobader2002/Rentoo.git
cd Rentoo
