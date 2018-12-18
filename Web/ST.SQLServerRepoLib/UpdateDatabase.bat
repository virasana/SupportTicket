@REM Get the password from environment variable
@REM We are migrating EF on Windows host, so need to set it up here too
@REM note 127.0.0.1, below --> points to design-time sql server database, which you can access from the host machine
@REM the db lives in the docker container

cd %~dp0
SET SUPPORT_TICKET_DEPLOY_DB_CONN_STRING=Data Source=127.0.0.1;Initial Catalog=SupportTicket;User Id=SA;password=D3vs123---D3vs123
dotnet ef database update --context SupportTicketDbContext --project .\ST.SqlServerRepoLib.csproj --startup-project ..\ST.Web\ST.Web.csproj  --verbose

