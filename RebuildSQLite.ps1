rm hydropi.db -Force
dotnet ef database update --context IdentityDbContext
dotnet ef database update --context ApplicationDbContext