# Online Shop

## Dependencies
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
```
## Commands
```
dotnet watch run
dotnet ef migrations add <migration name>
dotnet ef database update
dotnet ef migrations remove
```
## Sources
- [Introducing FOREIGN KEY constraint may cause cycles or multiple cascade paths - why?](https://stackoverflow.com/questions/17127351/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths)
- [Scrypt GitHub Repository](https://github.com/viniciuschiele/scrypt)
- [How to read Claims from Jason Web Token in ASP.NET Core 2.1 Web API - C#](https://www.youtube.com/watch?v=n_w07VeIg_k)
- [Setting up Swagger (ASP.NET Core) using the Authorization headers (Bearer)](https://stackoverflow.com/questions/43447688/setting-up-swagger-asp-net-core-using-the-authorization-headers-bearer)