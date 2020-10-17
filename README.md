# Online Shop

## How to run this application
```
git clone https://github.com/ryuichi24/online-shop.git
cd online-shop
docker-compose up -d
```
After all containers get ready, access:
- [http://localhost:8000 (Home page)](http://localhost:8000)
- [http://localhost:8000/admin (Admin page)](http://localhost:8000/admin)
- [http://localhost:8000/swagger (Api documentation)](http://localhost:8000/swagger)

## Demo credentials
Demo accounts both for a normal user and admin user were created. You can login with each credential below:

- Normal user
    - email => ryuichi@example.com
    - password => 1234567
- Admin user
    - email => admin@example.com
    - password => admin
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
