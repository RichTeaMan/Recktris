FROM microsoft/dotnet:2.1-sdk

RUN apt-get update
RUN apt-get install -y nodejs
RUN mkdir Recktris
RUN wget https://github.com/RichTeaMan/Recktris/archive/master.tar.gz -O Recktris.tar.gz
RUN tar -xzf Recktris.tar.gz --strip-components=1 -C Recktris
RUN dotnet restore /Recktris/Recktris/Recktris.csproj
RUN dotnet publish /Recktris/Recktris/Recktris.csproj --configuration Release
WORKDIR /Recktris/Recktris/bin/Release/netcoreapp2.1/publish
ENTRYPOINT dotnet Recktris.dll
