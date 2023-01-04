FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY Services/Discount/Discount.Api/*.csproj Services/Discount/Discount.Api/
RUN dotnet restore Services/Discount/Discount.Api/*.csproj
COPY . .
RUN dotnet publish Services/Discount/Discount.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourse.Services.Discount.dll" ]