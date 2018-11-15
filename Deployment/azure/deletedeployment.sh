#!/bin/bash
echo "Deleting services and deployments"
kubectl delete -f sql-deployment.yaml
kubectl delete -f web-deployment.yaml
kubectl delete -f services.yaml
#az aks scale --name kscluster --resource-group RGKSK8S --node-count 1

