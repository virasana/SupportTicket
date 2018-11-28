SET THE_VERSION=virasana/streact:1.0.0.%1
echo Building %THE_VERSION% ...
docker build . -f ./Dockerfile -t virasana/streact:1.0.0.%1
@REM echo Pushing $THE_VERSION ...
@REM docker push $THE_VERSION
echo "done!"

