# Dogs

## Pre-requisites
* [Docker](https://www.docker.com/)
#### or
* [.Net Core 7](https://www.microsoft.com/net/core)
* [mssql-2022](https://www.microsoft.com/ru-ru/sql-server/sql-server-2022)

## Description
api allows you to view a list of dogs, as well as add your own to the database

## Resources

* **[API Swagger](http://localhost:8001)**

## Docker

Ensure .env file exist with next variables:

```
ASPNETCORE_ENVIRONMENT=
DB_CONNECTION=
DB_PASSWORD=
```

### Commands

 Start project:

```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
```
