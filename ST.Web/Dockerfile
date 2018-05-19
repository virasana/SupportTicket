FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY SupportTicket.sln ./
COPY ST.Web/ST.Web.csproj ST.Web/
COPY ST.AppServicesLib/ST.AppServicesLib.csproj ST.AppServicesLib/
COPY ST.SharedInterfacesLib/ST.SharedInterfacesLib.csproj ST.SharedInterfacesLib/
COPY ST.SharedEntitiesLib/ST.SharedEntitiesLib.csproj ST.SharedEntitiesLib/
COPY ST.SQlServerRepoLib/ST.SQLServerRepoLib.csproj ST.SQlServerRepoLib/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/ST.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ST.Web.dll"]
