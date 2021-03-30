# HydroPi

# Generate Developer HTTPS Secret
```
dotnet dev-certs https --clean
dotnet dev-certs https -ep hydropi.pfx -p "hydro"
dotnet dev-certs https --trust
```

### Run Docker Compose
```
docker-compose -f "docker-compose.debug.yml" up
```

### Stop Docker Compose
```
docker-compose -f "docker-compose.debug.yml" down
```

## Setup Dev Environment
Download and install (https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner)This
npm install
dotnet restore
