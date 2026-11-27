# E-Student desktop

A Windows Forms version of [E-Student](https://github.com/ahmed-amine-jerbi/E-Student-Platform), the
classroom platform I built in PHP for my end-of-year project at ESEN. It runs on the same MySQL
database, so an account made on the website signs in here too, and the other way round.

What it does:

- **Sign up and log in.** Passwords are hashed with BCrypt, the same format the PHP site uses.
- **Admin:** lists every user and changes their role.
- **Teacher:** posts homework with a deadline for a filière, level and group.
- **Student:** sees the homework posted for their group, with the teacher's name and the deadline.

Every query uses parameters, so user input never becomes part of the SQL.

## Run it

You need Windows, the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) and a local
MySQL server (XAMPP or WAMP work).

1. Create the database from the PHP project's dump,
   [`src/bases/pfa_esen_2026.sql`](https://github.com/ahmed-amine-jerbi/E-Student-Platform/blob/master/src/bases/pfa_esen_2026.sql).
2. The app connects to `pfa_esen_2026` on `localhost` as `root` with no password, which is XAMPP's
   default. If your setup differs, change the connection string in `DatabaseHelper.cs`.
3. Build and start it:

   ```sh
   dotnet run --project ProjetNET.csproj
   ```

## Code

| File | What it holds |
|---|---|
| `FormLogin.cs`, `FormCreateAccount.cs` | Sign-in and sign-up |
| `FormDashboardAdmin.cs`, `FormDashboardEnseignant.cs`, `FormDashboardEtudiant.cs` | One window per role |
| `DatabaseHelper.cs` | The MySQL connection |
| `Session.cs` | The signed-in user |
| `docs/rapport-sgbd-oracle.pdf` | The database part of the project (in French): class diagram, relational model and the Oracle SQL and PL/SQL scripts |

Built with C#, .NET 10, Windows Forms, MySqlConnector and BCrypt.Net.
