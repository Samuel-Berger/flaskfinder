## Initial setup
```powershell
cd infrastructure
cp .env-template .env
# change password
docker compose -f .\flask-finder-compose.yaml up -d
# run the migrations
```

## Coming

1. .NET-project instructions
2. Automatic apply of migrations
3. Add spirits