FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY Services/Basket/Basket.Api/*.csproj Services/Basket/Basket.Api/
RUN dotnet restore Services/Basket/Basket.Api/*.csproj
COPY . .
RUN dotnet publish Services/Basket/Basket.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Basket.Api.dll" ]