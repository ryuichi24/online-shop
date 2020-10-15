FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

ENV ASPNETCORE_URLS=http://+:80
ENV PATH $PATH:/root/.dotnet/tools

RUN dotnet tool install -g dotnet-ef --version 3.1.8
RUN chmod +x ./entrypoint.sh

CMD /bin/bash ./entrypoint.sh