# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia tudo para dentro da imagem
COPY . .

# Restaura e publica a aplicação a partir da subpasta
WORKDIR /src/BoxSellerWebApp
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/out ./

# Expõe a porta usada pela aplicação
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "BoxSellerWebApp.dll"]
