SET /P TOKEN= Please enter the VSTS Personal Access Token (PAT):
docker run -v //var/run/docker.sock:/var/run/docker.sock -e VSTS_ACCOUNT=karunasoft -e VSTS_TOKEN=%TOKEN% -e VSTS_POOL=SupportTicket --rm -d -it microsoft/vsts-agent:latest /vsts/start.sh
