SET LOCALPATH=%~dp0\..
docker run -v %LOCALPATH%:/devops -it virasana/devopsbox /bin/bash