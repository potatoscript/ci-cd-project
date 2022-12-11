# Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BennyAPI/*.csproj ./BennyAPI/
RUN dotnet restore

# copy everything else and build app
COPY BennyAPI/. ./BennyAPI/
WORKDIR /app/BennyAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
WORKDIR /app
COPY --from=build /app/BennyAPI/out .
EXPOSE 80
CMD ["dotnet", "BennyAPI.dll"]