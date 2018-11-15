#!/bin/bash

# creates a pod with a service using wardivaene nodehelloworld image from udemy kubernetes course

if [ ! -d "./kubernetes-course" ]; then
	echo "*** CLONING kubernetes-course ***"
	git clone https://github.com/wardviaene/kubernetes-course
fi

echo "*** CREATE POD FROM yaml ***"
kubectl create -f ./kubernetes-course/first-app/helloworld.yml

#echo "*** COULD OPTIONALLY EXPOSE A PORT HERE ***"
#kubectl expose...

#echo "*** CREATE POD FROM yaml ***"
#kubectl create -f ./kubernetes-course/first-app/helloworld.yml

echo "*** CREATE SERVICE FROM yaml ***"
kubectl create -f ./kubernetes-course/first-app/helloworld-service.yml

echo "*** CREATE REPLICATION CONTROLLER ***"
kubectl create -f replication-controller/helloworld-repl-controller.yml


