FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SupportTicket21.sln ./
COPY "ST.Web/ST.Web.csproj" "ST.Web/"
COPY "ST.AppServicesLib/ST.AppServicesLib.csproj" "ST.AppServicesLib/"
COPY "ST.SharedInterfacesLib/ST.SharedInterfacesLib.csproj" "ST.SharedInterfacesLib/"
COPY "ST.SharedEntitiesLib/ST.SharedEntitiesLib.csproj" "ST.SharedEntitiesLib/"
COPY "ST.SQLServerRepoLib/ST.SQLServerRepoLib.csproj" "ST.SQLServerRepoLib/"
COPY "ST.SharedHelpersLib/ST.SharedHelpersLib.csproj" "ST.SharedHelpersLib/"
RUN dotnet restore "ST.Web/ST.Web.csproj"

COPY . .
WORKDIR "/src/ST.Web"
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ST.Web.dll"]