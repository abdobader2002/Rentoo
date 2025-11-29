# Rentoo

A cleanly-architected rental platform (Rentoo) — backend and web frontend projects separated using a layered/clean architecture.

> Short: Rentoo is a .NET-based rental application scaffold structured into `Web`, `Application`, `Domain`, and `Infrastructure` projects to support maintainable, testable, and scalable development.

---

## Repository layout

- `Rentoo.Web` — Web UI / API (frontend / web host).  
- `Rentoo.Application` — Application services, DTOs, use-cases.  
- `Rentoo.Domain` / `Rentoo.Domain.Shared` — Domain entities, value objects, domain logic.  
- `Rentoo.Infrastructure` — Data access, EF Core mappings, external services integrations.  
- `Rentoo.sln` — Solution file.  

> (Project folders discovered in this repository.) :contentReference[oaicite:1]{index=1}

---

## Key features

- Layered / Clean Architecture separation.
- RESTful endpoints (Web / API).
- Domain-driven design ideas (entities, value objects, shared kernel).
- Data access via `Infrastructure` (EF Core expected).
- Ready for Dockerization and CI/CD (repository structure supports it).

---

## Tech stack

- **Language:** C#  
- **Framework:** .NET (use the SDK matching the project; e.g. .NET 7/8/9 depending on your source)  
- **ORM:** Entity Framework Core (expected in `Rentoo.Infrastructure`)  
- **Frontend:** Razor / MVC / SPA (depending on `Rentoo.Web` contents)  
- **Tools:** Git, Visual Studio / VS Code, Docker (optional), GitHub Actions (optional)

---

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/) installed (check the solution's target framework).  
- SQL Server or another supported RDBMS (if EF Core is configured for SQL Server).  
- (Optional) Docker & Docker Compose for containerized setup.  
- Git.

---

## Quick start (local)

1. **Clone repository**
```bash
git clone https://github.com/abdobader2002/Rentoo.git
cd Rentoo
