FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine

ENV APP_DIR /src/app

RUN mkdir -p ${APP_DIR}

RUN addgroup -S projects && adduser -S projects -G projects

WORKDIR ${APP_DIR}

COPY . .

RUN chown -R projects:projects ${APP_DIR}

USER projects

RUN dotnet build ${APP_DIR}/Roster.Client/Roster.Client.csproj

RUN dotnet build ${APP_DIR}/Roster.Client.Tests.Mod02/Roster.Client.Tests.Mod02.csproj

RUN dotnet build ${APP_DIR}/Roster.Client.Tests.Mod04/Roster.Client.Tests.Mod04.csproj

ENTRYPOINT ["/bin/sh"]
