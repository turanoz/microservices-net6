FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY Services/FakePayment/FakePayment.Api/*.csproj Services/FakePayment/FakePayment.Api/
RUN dotnet restore Services/FakePayment/FakePayment.Api/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/FakePayment.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FakePayment.Api.dll" ]