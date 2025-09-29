## Initial setup
```powershell
cd infrastructure
cp .env-template .env
# change password
docker compose -f .\flask-finder-compose.yaml up -d
# run the migrations
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
3. Add spirits

## References

[Minimal-API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-9.0)  
[Example](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)