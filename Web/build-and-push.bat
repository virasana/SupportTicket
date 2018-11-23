SET THE_VERSION=virasana/stweb:1.0.0.0 @REM %1

echo Building %THE_VERSION% ...
docker build . -f .\ST.Web\Dockerfile -t final 
docker tag final %THE_VERSION%
@REM echo Pushing %THE_VERSION% ...
@REM docker push %THE_VERSION%
