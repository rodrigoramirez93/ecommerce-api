# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build-env
WORKDIR /app

COPY ./ ./
RUN dotnet restore ./ecommerce-api/Ecommerce.sln

RUN ls
RUN dotnet publish ./ecommerce-api/Ecommerce.sln -c Release -o ./out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
RUN ls
ENTRYPOINT ["dotnet", "Ecommerce.API.dll"]