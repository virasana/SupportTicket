 #! /bin/bash
 apt-get -qy update && apt-get -qy install --no-upgrade --no-install-recommends \
        apt-transport-https \
        apt-utils \
        curl \
        software-properties-common

 curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -
 add-apt-repository "$(curl -s https://packages.microsoft.com/config/ubuntu/16.04/prod.list)"

 ACCEPT_EULA=Y apt-get -qy install --no-upgrade --no-install-recommends \
        msodbcsql \
        mssql-tools \
        unixodbc-dev

 echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bash_profile
 echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
 
 apt-get install -y locales \
    && echo "en_US.UTF-8 UTF-8" > /etc/locale.gen \
    && locale-gen
	
 # add it to your environment (uses a symbolic link, I think)
 # https://dba.stackexchange.com/questions/174277/getting-sqlcmd-sqlcmd-command-not-found-in-linux/174278
 ln -s /opt/mssql-tools/bin/* /usr/local/bin/