# build
FROM        microsoft/dotnet:2.1.300-sdk AS build

WORKDIR     /app

# restore
COPY        api/api.csproj ./api/
RUN         dotnet restore api/api.csproj

COPY        tests/tests.csproj ./tests/
RUN         dotnet restore api/api.csproj

# copy src
COPY        . .

# test
ENV         TEAMCITY_PROJECT_NAME=fake
RUN         dotnet test tests/tests.csproj

# publish
RUN         dotnet publish api/api.csproj -o /publish
WORKDIR     /publish

# runtime
FROM        microsoft/dotnet:2.1.3-aspnetcore-runtime
WORKDIR     /publish
COPY        --from=build /publish .

ENTRYPOINT [ "dotnet", "api.dll" ]

