## Initial setup

```powershell
cd infrastructure
cp .env-template .env
# change password
docker compose -f .\flask-finder-compose.yaml up -d
# run the migrations
```

1. Restore the solution
2. Right click on FlaskFinder and choolse Manage User Secrets.
Add an entry (but don't forget to modify the password)

```json
{
    "ConnectionStrings:Postgres": "Host=localhost;Port=5432;Username=flaskfinder;Password=secret;Database=flaskfinder"
}
```

3. When you run the program the top lines should look like:

```powershell
info: WebApi[0] Can connect to database: True
info: Microsoft.Hosting.Lifetime[14] Now listening on: http://localhost:5046
info: Microsoft.Hosting.Lifetime[0] Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0] Hosting environment: Development
```

## Run API on nixOS
No migrations or fancy stuff like that. But can be launched with

```sh
nix-shell -p dotnet-sdk_9
dotnet run --project WebApi/WebApi.csproj
```

## Coming

1. .NET-project instructions
2. Automatic apply of migrations
3. Run on actual web hosting
4. Add spirits

## References

[Minimal-API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-9.0)  
[Example](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)  
[Database](https://medium.com/@vosarat1995/integrating-postgresql-with-net-9-using-ef-core-a-step-by-step-guide-a773768777f2)  