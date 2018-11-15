#!/bin/bash
#apt-get install lsb-release

#AZ_REPO=$(lsb_release -cs)
#echo "deb [arch=amd64] https://packages.microsoft.com/repos/azure-cli/ $AZ_REPO main" | \
    #tee /etc/apt/sources.list.d/azure-cli.list
	
#curl -L https://packages.microsoft.com/keys/microsoft.asc | apt-key add -

#apt-get install apt-transport-https
#apt-get update &&  apt-get install azure-cli

#az aks install-cli

# sql command line tools
#curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -

#curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list | tee /etc/apt/sources.list.d/msprod.list

#apt-get update 
#apt-get -y install mssql-tools unixodbc-dev

az account list

az account set -s "Microsoft Partner Network"

az account show

az group create --name RGKSK8S --location "East US"

az group show --name RGKSK8S

# TODO - Change the name and region below
az aks create --resource-group RGKSK8S --name kscluster --node-count 1 --generate-ssh-keys

az aks get-credentials --resource-group RGKSK8S --name kscluster


# Create a secret for the sql server
#kubectl create secret generic mssql --from-literal=SA_PASSWORD="K00s123^^^K00s123" \
 #                                   --from-literal=CONN_STRING="Data Source=sqlservice;Initial Catalog=SupportTicket;User Id=SA;password=K00s123^^^K00s123"
 # Better way
 # kubectl apply -f secrets.yaml

# Create persistent volume claim
kubectl apply -f ./pvc.yaml

kubectl describe pvc "mssql-data"

# describe persistent volume
kubectl describe pv

kubectl apply -f ./sqldeployment.yaml
kubectl apply -f ./web-deployment.yaml
kubectl apply -f ./services.yaml
kubectl get pod
#kubectl get services

# install sqlcmd
#./installsqlcmd.sh

#sqlcmd -S 40.76.27.176 -U sa -P "K00s123^^^K00s123"

# attach to the container
#kubectl exec mssql-deployment-6bd4657875-drb2t -i -t /bin/bash

# scale the cluster
# az aks scale --name kscluster --resource-group RGKSK8S --node-count 3

# kubectl apply -f azure-vote.yaml

# Delete the cluster
# az group delete --name myResourceGroup --yes --no-wait
