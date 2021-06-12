#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|Environment script for first setup - Lilo DashBoard|----------------+${NC}"

#-----------------------|Dependencies Check|------------------------------------------------------------
echo "${YLL}Checking Dependencies...${NC}"

dependencyError=0
#Root Login
if [ $(id -u) -eq 0 ]
then 
    echo "${GRE}[X] Running as Root...${NC}"
else
    echo "${RED}[ ] Not running as Root...${NC}"
    dependencyError=1
fi

#Check Docker
if [ -x "$(command -v docker)" ]; then
    echo "${GRE}[X] Docker is installed...${NC}"
else
    echo "${RED}[ ] Docker is not installed...${NC}"
    dependencyError=1
fi

#Check DotNet
if [ -x "$(command -v dotnet)" ]; then
    echo "${GRE}[X] DotNet is installed...${NC}"
else
    echo "${RED}[ ] DotNet is not installed...${NC}"
    dependencyError=1
fi

if [ $dependencyError -eq 1 ];
then
    echo ""
    echo "${RED}Script aborted.${NC}"
    exit
fi

#-----------------------|Configuring Database Docker container|--------------------------------------------
databaseContainer="LiloPostgres"
echo "${YLL}Checking Database container...${NC}"
if [ ! "$(docker ps -q -f name=${databaseContainer})" ]; 
then
    if [ "$(docker ps -aq -f status=exited -f name=${databaseContainer})" ]; then
        # cleanup
        docker rm "${databaseContainer}"
    fi
    # run Postgres container
    docker pull postgres
    docker run --name "${databaseContainer}" -e POSTGRES_PASSWORD=Masterkey10@ -d postgres
else
    echo "${GRE}Docker container '${databaseContainer}' already exists... ${NC}"
fi

#-----------------------|Configuring Broker Docker container|-------------------------------------------
brokerContainer="LiloBroker"
echo "${YLL}Checking Service Broker container...${NC}"
if [ ! "$(docker ps -q -f name=${brokerContainer})" ]; 
then
    if [ "$(docker ps -aq -f status=exited -f name=${brokerContainer})" ]; then
        # cleanup
        docker rm "${brokerContainer}"
    fi
    # run RabbitMq container
    docker pull rabbitmq
    docker run -d --hostname lilo-broker --name "${brokerContainer}" -p 15672:15672 -p 5672:5672 rabbitmq:management
else
    echo "${GRE}Docker container '${brokerContainer}' already exists... ${NC}"
fi

#-----------------------|Docker ls|-----------------------------------------------------------------------
echo "${YLL}+----------------|Docker Containers|--------------------------------------------------+${NC}"
docker container ls -a

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"