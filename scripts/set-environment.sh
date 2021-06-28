#!/bin/bash

. ./lib.sh
log "SET ENVIRONMENT" intro 1.0.2

#------------------|Dependencies Check|------------------

dependencyError=0
log "Checking dependencies" title

#Check Docker
checkDependency docker Docker
if [ $? -eq 1 ]; then
    dependencyError=1
fi

#Check DotNet
checkDependency dotnet "DotNet"
if [ $? -eq 1 ]; then
    dependencyError=1
fi

if [ $dependencyError -eq 1 ]; then
    die
fi

#-----------------------|Configuring Database Docker container|--------------------------------------------
databaseContainer="LiloPostgres"
log "Checking Database container..." information
if [ ! "$(sudo docker ps -q -f name=${databaseContainer})" ]; 
then
    if [ "$(sudo docker ps -aq -f status=exited -f name=${databaseContainer})" ]; then
        # cleanup
        sudo docker rm "${databaseContainer}"
    fi
    # run Postgres container
    sudo docker pull postgres
    sudo docker run --name "${databaseContainer}" -e POSTGRES_PASSWORD=Masterkey10@ -d postgres
else
    log "Docker container '${databaseContainer}' already exists..." information
fi

#-----------------------|Configuring Broker Docker container|-------------------------------------------
brokerContainer="LiloBroker"
log "Checking Service Broker container..." information
if [ ! "$(sudo docker ps -q -f name=${brokerContainer})" ]; 
then
    if [ "$(sudo docker ps -aq -f status=exited -f name=${brokerContainer})" ]; then
        # cleanup
        sudo docker rm "${brokerContainer}"
    fi
    # run RabbitMq container
    sudo docker pull rabbitmq
    sudo docker run -d --hostname lilo-broker --name "${brokerContainer}" -p 15672:15672 -p 5672:5672 rabbitmq:management
else
    log "Docker container '${brokerContainer}' already exists..." success
fi

#-----------------------|Configuring Jenkins Container|-------------------------------------------
jenkinsContainer="LiloJenkins"
log "Checking Jenkins container..." information
if [ ! "$(sudo docker ps -q -f name=${jenkinsContainer})" ]; 
then
    if [ "$(sudo docker ps -aq -f status=exited -f name=${jenkinsContainer})" ]; then
        # cleanup
        sudo docker rm "${jenkinsContainer}"
    fi
    # run Jenkins container
    sudo docker run -d -v jenkins_home:/var/jenkins_home -p 8080:9800 -p 50000:50000 jenkins/jenkins:lts-jdk11
else
    log "Docker container '${jenkinsContainer}' already exists..." success
fi

#-----------------------|Docker ls|-------------------------------
log "Docker Containers" title
sudo docker container ls -a

#------------------|End of Script|------------------
log "End of Script..." success