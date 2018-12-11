docker run -it -v D:\DATA\GIT\SupportTicket\streact\:/usr/src/app -p 3000:3000 --rm  -e CHOKIDAR_USEPOLLING=true streact

@REM docker run -e CHOKIDAR_USEPOLLING=true -p 3000:3000 -v D:\DATA\GIT\reacttestingdemo:/usr/src/app -it --entrypoint /bin/bash virasana/streact:dev