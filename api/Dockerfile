FROM        microsoft/dotnet:2.1.300-sdk as build-env

WORKDIR     /api
COPY        /api.csproj .
RUN         dotnet restore

COPY        . .
RUN         dotnet publish -o /publish

FROM        microsoft/dotnet:2.1.3-aspnetcore-runtime
WORKDIR     /publish
COPY        --from=build-env /publish .

ENTRYPOINT  ["dotnet", "api.dll"]