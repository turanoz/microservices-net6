FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/

COPY Services/Order/Order.Application/*.csproj Services/Order/Order.Application/

COPY Services/Order/Order.Domain/*.csproj Services/Order/Order.Domain/

COPY Services/Order/Order.Domain.Core/*.csproj Services/Order/Order.Domain.Core/

COPY Services/Order/Order.Infrastructure/*.csproj Services/Order/Order.Infrastructure/


COPY Services/Order/Order.Api/*.csproj Services/Order/Order.Api/
RUN dotnet restore Services/Order/Order.Api/*.csproj
COPY . .
RUN dotnet publish Services/Order/Order.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Order.Api.dll" ]
