# Curiosity

A small full-stack app for browsing space missions, launches and agencies.
University project (PAW).

**Stack:** Angular 21 (frontend) + ASP.NET Core / .NET 10 (backend) + SQL Server LocalDB + EF Core.

---

## Features

- Browse all space missions with search and filter by agency
- Mission detail page (article view) with full body and image
- Upcoming launches feed
- Agencies (NASA, SpaceX, ESA, CNSA, ISRO)
- User accounts via ASP.NET Identity (register / login)
- Admin role can create new missions
- Logged-in users can favorite missions

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/) and npm
- SQL Server LocalDB (ships with Visual Studio; standalone installer also works)
- Angular CLI: \`npm i -g @angular/cli\`

---

## Setup

### 1. Backend

\`\`\`bash
cd backend/Curiosity.Api
dotnet restore
dotnet ef database update
dotnet run
\`\`\`

Default connection string is in \`appsettings.json\` and points to \`(localdb)\\mssqllocaldb\`, database \`CuriosityDb\`.

### 2. Frontend

\`\`\`bash
cd frontend
npm install
npm start
\`\`\`

App starts on \`http://localhost:4200/\`.

---

## Useful commands

| What                        | Where                    | Command                              |
| --------------------------- | ------------------------ | ------------------------------------ |
| Add EF migration            | \`backend/Curiosity.Api\`  | \`dotnet ef migrations add <Name>\`    |
| Apply migrations            | \`backend/Curiosity.Api\`  | \`dotnet ef database update\`          |
| Drop & recreate DB          | \`backend/Curiosity.Api\`  | \`dotnet ef database drop\` then update |
| Build frontend (prod)       | \`frontend\`               | \`npm run build\`                      |
| Run frontend tests          | \`frontend\`               | \`npm test\`                           |

---

## API quick reference

| Method | Route                  | Auth   |
| ------ | ---------------------- | ------ |
| GET    | \`/api/missions\`        | public |
| GET    | \`/api/missions/{id}\`   | public |
| POST   | \`/api/missions\`        | Admin  |
| GET    | \`/api/launches\`        | public |

Swagger UI is enabled in development at \`/swagger\`.

---

## License

MIT — see [LICENSE](LICENSE).
