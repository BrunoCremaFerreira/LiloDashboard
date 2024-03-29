#!/bin/sh

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
databaseContainer="LiloDatabase"
log "Checking Database container..." information
if [ ! "$(sudo docker ps -q -f name=${databaseContainer})" ]; 
then
    if [ "$(sudo docker ps -aq -f status=exited -f name=${databaseContainer})" ]; then
        # cleanup
        sudo docker rm "${databaseContainer}"
    fi

    # Runing Database container
    sudo docker run --name "${databaseContainer}" -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Masterkey10@' -e 'MSSQL_PID=Express' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu
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
    sudo docker run -d --name "$jenkinsContainer" -v jenkins_home:/var/jenkins_home -p 8080:9800 -p 50000:50000 jenkins/jenkins:lts-jdk11
else
    log "Docker container '${jenkinsContainer}' already exists..." success
fi

#-----------------------|Docker ls|-------------------------------
log "Docker Containers" title
sudo docker container ls -a

#-----------------------|Migrations|-------------------------------
log "Running Migrations" title
cd "../src/Infra.Data"
dotnet ef database update

#------------------|End of Script|------------------
log "End of Script..." success
