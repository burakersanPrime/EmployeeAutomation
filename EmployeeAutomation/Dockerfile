#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EmployeeAutomation/EmployeeAutomation.csproj", "EmployeeAutomation/"]
COPY ["Domain/em.Domain.csproj", "Domain/"]
COPY ["em.Application/em.Application.csproj", "em.Application/"]
COPY ["Persistence/em.Persistence.csproj", "Persistence/"]
RUN dotnet restore "EmployeeAutomation/EmployeeAutomation.csproj"
COPY . .
WORKDIR "/src/EmployeeAutomation"
RUN dotnet build "EmployeeAutomation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeAutomation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeAutomation.dll"]