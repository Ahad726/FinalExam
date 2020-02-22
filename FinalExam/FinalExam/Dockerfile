FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["FinalExam/*.csproj", "FinalExam/"]
COPY ["FinalExam.Core/*.csproj", "FinalExam.Core/"]
RUN dotnet restore "FinalExam/FinalExam.csproj"
COPY . .
WORKDIR "/src/FinalExam"
RUN dotnet build "FinalExam.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FinalExam.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FinalExam.dll"]