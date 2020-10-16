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
- [Fetch foreign key table data](https://entityframework.net/knowledge-base/52352970/fetch-foreign-key-table-data)
- [Request header field content-type is not allowed by Access-Control-Allow-Headers in preflight response](https://forums.asp.net/t/2168883.aspx?Request+header+field+content+type+is+not+allowed+by+Access+Control+Allow+Headers+in+preflight+response+)
- [22 - Nested Routes in Vuejs and Some Cool Design Technique](https://www.youtube.com/watch?v=cSOVG_utfn8)
- [How to omit methods from Swagger documentation on WebAPI using Swashbuckle](https://stackoverflow.com/questions/29701573/how-to-omit-methods-from-swagger-documentation-on-webapi-using-swashbuckle)
- [How to configure Swashbuckle to ignore property on model](https://stackoverflow.com/questions/41005730/how-to-configure-swashbuckle-to-ignore-property-on-model)
- [.Net Core 3.0 possible object cycle was detected which is not supported](https://entityframeworkcore.com/knowledge-base/59199593/-net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported)
- [Include->ThenInclude for a collection](https://github.com/dotnet/efcore/issues/6560)
- [dotnet ef not found in .NET Core 3](https://stackoverflow.com/questions/57066856/dotnet-ef-not-found-in-net-core-3)

docker exec -it 03c86 /bin/ash