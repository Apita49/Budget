# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files
COPY ["BudgetMan/BudgetMan.RestAPI.csproj", "BudgetMan/"]
COPY ["BudgetMan.Domain/BudgetMan.Domain.csproj", "BudgetMan.Domain/"]
COPY ["BudgetMan.Dao.Interface/BudgetMan.Dao.Interface.csproj", "BudgetMan.Dao.Interface/"]
COPY ["BudgetMan.Dao.MongoDb/BudgetMan.Dao.MongoDb.csproj", "BudgetMan.Dao.MongoDb/"]
COPY ["BudgetMan.Dao.MongoDb.Domain/BudgetMan.Dao.MongoDb.Domain.csproj", "BudgetMan.Dao.MongoDb.Domain/"]
COPY ["BudgetMan.Service/BudgetMan.Service.csproj", "BudgetMan.Service/"]

# Restore dependencies
RUN dotnet restore "BudgetMan/BudgetMan.RestAPI.csproj"

# Copy all source code
COPY . .

# Build
WORKDIR "/src/BudgetMan"
RUN dotnet build "BudgetMan.RestAPI.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "BudgetMan.RestAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5002 5003
ENV ASPNETCORE_URLS=http://+:5002
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "BudgetMan.RestAPI.dll"]
