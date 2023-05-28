FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview as build-env
ARG TARGETPLATFORM
ARG BUILDPLATFORM

RUN curl -fsSL https://deb.nodesource.com/setup_19.x | bash - && apt-get install -y nodejs

WORKDIR /App

COPY . ./
RUN dotnet restore -a $TARGETPLATFORM

RUN echo "I am running on ${BUILDPLATFORM}"
RUN echo "building for ${TARGETPLATFORM}"
RUN export TARGETPLATFORM="${TARGETPLATFORM}"

RUN dotnet publish -c Release -a $TARGETPLATFORM -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
EXPOSE 8276
ENV ASPNETCORE_URLS "http://+:8267"
ENV CONFIG_DIR "/config/espresense"
COPY --from=build-env /App/out .
LABEL \
    io.hass.version="VERSION"
ENTRYPOINT ["dotnet", "ESPresense.Companion.dll"]