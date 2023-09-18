#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/04-Presentation/beqom.Presentation.API/beqom.Presentation.API.csproj", "src/04-Presentation/beqom.Presentation.API/"]
COPY ["src/02-Domain/beqom.Domain.Repository/beqom.Domain.Repository.csproj", "src/02-Domain/beqom.Domain.Repository/"]
COPY ["src/01-Core/beqom.Core.Extension/beqom.Core.Extension.csproj", "src/01-Core/beqom.Core.Extension/"]
COPY ["src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/beqom.Domain.Contract.csproj", "src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/"]
COPY ["src/01-Core/beqom.Core.Contract/beqom.Core.Contract.csproj", "src/01-Core/beqom.Core.Contract/"]
COPY ["src/02-Domain/beqom.Domain.Aggregate/beqom.Domain.Aggregate.csproj", "src/02-Domain/beqom.Domain.Aggregate/"]
COPY ["src/03-Application/beqom.Application.CommandQuery/beqom.Application.CommandQuery.csproj", "src/03-Application/beqom.Application.CommandQuery/"]
COPY ["src/03-Application/beqom.Application.Contract/beqom.Application.Contract.csproj", "src/03-Application/beqom.Application.Contract/"]
RUN dotnet restore "src/04-Presentation/beqom.Presentation.API/beqom.Presentation.API.csproj"
COPY . .
WORKDIR "/src/src/04-Presentation/beqom.Presentation.API"
RUN dotnet build "beqom.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "beqom.Presentation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "beqom.Presentation.API.dll"]