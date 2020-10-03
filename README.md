# Online Shop

## Dependencies
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Swashbuckle.AspNetCore
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
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