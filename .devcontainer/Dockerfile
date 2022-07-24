# [Choice] .NET version: 6.0, 3.1, 6.0-bullseye, 3.1-bullseye, 6.0-focal, 3.1-focal
ARG VARIANT="6.0"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}

# [Choice] Node.js version: none, lts/*, 18, 16, 14
ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

# wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh  -O run2.sh
ADD https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh /tmp
# install two sdks: 7.*-preview and latest stable 6
RUN chmod +x /tmp/dotnet-install.sh \
    && /tmp/dotnet-install.sh --version "7.0.100-preview.6.22352.1"  --install-dir "/usr/local/bin" --architecture "x64" --os "linux"\
    && /tmp/dotnet-install.sh --install-dir "/usr/local/bin" --architecture "x64" --os "linux" 
# RUN curl -s https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh | bash -s -Channel 7.0 -Quality preview  --install-dir "/usr/local/bin" --architecture "x64" --os "linux"
# ./run2.sh -Channel 7.0 -Quality preview  --install-dir "/usr/local/bin" --architecture "x64" --os "linux"
#-Channel 6.0.1xx -Quality preview 

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1