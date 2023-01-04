FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY Services/Catalog/Catalog.Api/*.csproj Services/Catalog/Catalog.Api/
RUN dotnet restore Services/Catalog/Catalog.Api/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/Catalog.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Catalog.Api.dll" ]