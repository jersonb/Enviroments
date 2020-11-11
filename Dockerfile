FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Enviroment.Domain/*.csproj ./Enviroment.Domain/
COPY Enviroments.Lib/*.csproj ./Enviroments.Lib/
COPY Enviroments.Test/*.csproj ./Enviroments.Test/
COPY Enviroments.Api/*.csproj ./Enviroments.Api/

RUN dotnet restore
RUN dotnet test

# copy everything else and build app
COPY Enviroment.Domain/. ./Enviroment.Domain/
COPY Enviroments.Lib/. ./Enviroments.Lib/
COPY Enviroments.Test/. ./Enviroments.Test/
COPY Enviroments.Api/. ./Enviroments.Api/


WORKDIR /app/Enviroments.Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Enviroments.Api/out ./
ENTRYPOINT ["dotnet", "Enviroments.Api.dll"]