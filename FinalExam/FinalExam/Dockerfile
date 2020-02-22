FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["BookSharingSystem/*.csproj", "BookSharingSystem/"]
COPY ["BookSharingSystem.Core/*.csproj", "BookSharingSystem.Core/"]
COPY ["BookSharingSystem.Data/*.csproj", "BookSharingSystem.Data/"]
RUN dotnet restore "BookSharingSystem/BookSharingSystem.csproj"
COPY . .
WORKDIR "/src/BookSharingSystem"
RUN dotnet build "BookSharingSystem.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookSharingSystem.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookSharingSystem.dll"]