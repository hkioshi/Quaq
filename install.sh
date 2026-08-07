#!/bin/bash

set -e

# Espera o Quaq ser encerrado.
sleep 2

echo "Publicando o projeto..."

dotnet publish -c Release -r linux-x64 --self-contained true

echo "Copiando arquivos..."

sudo mkdir -p /opt/quaq
sudo cp -r ./bin/Release/net10.0/linux-x64/publish/* /opt/quaq/

echo "Atualizando o comando..."

sudo rm -f /usr/local/bin/quaq
sudo ln -s /opt/quaq/Quaq /usr/local/bin/quaq

echo "Quaq atualizado com sucesso!"