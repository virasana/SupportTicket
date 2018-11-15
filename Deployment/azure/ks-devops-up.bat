@REM echo "%~1"
@REM Run this one first, if you don't have a running containerdocker
		@REM docker run -it -v D:\DATA\GIT\SupportTicket\Deployment\azure\:/devops virasana/devops:latest
		@REM -v enables volume mapping between windows and linux - work in notepad++ on Windows, and 
		@REM see the changes effected in Linux.

@REM if you already have a container (i.e. you have run the docker run -it command, above)		
	@REM docker start "%~1"
	@REM docker exec -it "%~1" /bin/bash 

