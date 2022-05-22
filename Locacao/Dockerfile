FROM mcr.microsoft.com/dotnet/core/sdk:5.0 AS build-env
WORKDIR /app
EXPOSE 80

COPY *.sln .
COPY "ComunicadoSinistro.csproj" "/."

RUN dotnet restore 

COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o publish 


FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/LibraryJobInsert.Worker/publish ./
ENTRYPOINT ["dotnet", "ComunicadoSinistro.dll"]