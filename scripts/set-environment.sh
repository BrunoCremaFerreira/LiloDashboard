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

#Check Docker
if [ -x "$(command -v docker)" ]; then
    echo "${GRE}[X] Docker is installed...${NC}"
else
    echo "${RED}[ ] Docker is not installed...${NC}"
    echo "${RED}Script aborted.${NC}"
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
    echo "${RED}Script aborted.${NC}"
    exit
fi

#-----------------------|Configuring MySql Docker container|--------------------------------------------
mysqlContainer="LiloMysql"
echo "${YLL}Checking Database container...${NC}"
if [ ! "$(docker ps -q -f name=${mysqlContainer})" ]; 
then
    if [ "$(docker ps -aq -f status=exited -f name=${mysqlContainer})" ]; then
        # cleanup
        docker rm "${mysqlContainer}"
    fi
    # run MySql container
    docker pull mysql
    docker run --name "${mysqlContainer}" -e MYSQL_ROOT_PASSWORD=Masterkey10@ -d mysql:latest
else
    echo "${GRE}Docker container '${mysqlContainer}' already exists... ${NC}"
fi

#-----------------------|Configuring MySql Docker container|-------------------------------------------
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
docker container ls -all

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"