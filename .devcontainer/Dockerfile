FROM mcr.microsoft.com/devcontainers/base:ubuntu-24.04

ENV DEBIAN_FRONTEND=noninteractive

# Install .NET 10 SDK and Mono tooling for .NET Framework 4.8 builds.
RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl gpg \
    && curl -fsSL https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb -o /tmp/packages-microsoft-prod.deb \
    && dpkg -i /tmp/packages-microsoft-prod.deb \
    && rm /tmp/packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y --no-install-recommends dotnet-sdk-10.0 mono-complete nuget \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# Ensure Mono tools are discoverable in non-login shells.
ENV PATH="/usr/lib/mono/msbuild/Current/bin:${PATH}"
