# Camp Booking Backend

## Prerequisite

```
dotnet-10
mysql-server
dotnet ef tool [command line]
```

## Development Setup

### Clone this repo

Clone this repo into your machine.

```
git clone https://github.com/web3-wizard/camp-booking.git
cd camp-booking/Backend
cd CampBooking.WebApi
```

## Project restore

Restore dotnet project and build project.

```
dotnet restore
dotnet build
```

## Add database connection string
I am store my database connection string into dotnet user secrets. If you does not want to do that add the connection string into "CampBooking.WebApi/appsettings.json" file "DefaultConnection" section.

```
# skip this part if you does not want to add connection string into user secrets
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "server=localhost;port=3306;user=root;password=your-password;database=CampBooking;"
```

## Update migrations to database

Update the migrations to database.

```
dotnet ef database update
```

## Run the project

Run the project by running the bellow command and visit this url "https://localhost:7214/swagger/index.html"

```
dotnet watch
```

### TODOS

 - Upgrade packages to latest version
 - Add DB connection string and migrations
 - Add postman collections
 - Update Readme file with correct instruction for local setup 
 - Add docker file
 - Create v0 docker image and push into docker hub
 - Add logging with serilog and SEQ
 - Add Unit and End-to-end testing using in-memory db or test db
 - Update business logic in terms of design pattern and future scope