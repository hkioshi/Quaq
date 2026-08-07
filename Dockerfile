FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /app

COPY . .

RUN dotnet publish -c Release -o out

RUN apt update && apt install -y \
    espeak-ng \
    ffmpeg \
    mpv

FROM mcr.microsoft.com/dotnet/runtime:10.0

WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Quaq.dll"]