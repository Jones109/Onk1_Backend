FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ADD ./ /app
ENV ASPNETCORE_URLS=http://*:${PORT}
WORKDIR /app
ENTRYPOINT [ "dotnet", "RestApi.dll"]