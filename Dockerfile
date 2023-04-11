FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/nightly/sdk:8.0-preview as build-env
ARG TARGETARCH
ARG BUILDPLATFORM

RUN curl -fsSL https://deb.nodesource.com/setup_19.x | bash - && apt-get install -y nodejs

WORKDIR /App

COPY . ./

RUN echo "I am running on ${BUILDPLATFORM}"
RUN echo "building for ${TARGETARCH}"
RUN export TARGETARCH="${TARGETARCH}"

RUN dotnet restore -a $TARGETARCH
RUN dotnet publish -c Release -a $TARGETARCH -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
EXPOSE 8276
ENV ASPNETCORE_URLS "http://+:8267"
ENV CONFIG_DIR "/config/espresense"
COPY --from=build-env /App/out .
LABEL \
    io.hass.version="VERSION"
ENTRYPOINT ["dotnet", "ESPresense.Companion.dll"]