#run from ../ with docker build -f SensorsAPI/Dockerfile -t sensorsapi .
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

#Copy everything else and build
COPY . ./
RUN dotnet publish SensorsAPI -c Release -o out

#Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime

WORKDIR /app

COPY --from=build /app/SensorsAPI/out .

ENTRYPOINT ["dotnet","SensorsAPI.dll"]

