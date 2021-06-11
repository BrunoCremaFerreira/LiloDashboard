#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|Start Containers - Lilo DashBoard|----------------+${NC}"

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

if [ $dependencyError -eq 1 ];
then
    echo ""
    echo "${RED}Script aborted.${NC}"
    exit
fi

#-----------------------|Starting  MySql Docker container|--------------------------------------------
{
    mysqlContainer="LiloMysql"
    echo "${YLL}Starting Database container...${NC}"
    if [ ! "$(docker ps -q -f name=${mysqlContainer})" ]; 
    then
        docker container start "${mysqlContainer}"
    else
        echo "${GRE}Docker container '${mysqlContainer}' already started... ${NC}"
    fi
} &

#-----------------------|Starting MySql Docker container|-------------------------------------------
{
    brokerContainer="LiloBroker"
    echo "${YLL}Starting Service Broker container...${NC}"
    if [ ! "$(docker ps -q -f name=${brokerContainer})" ];
    then
        docker container start "${brokerContainer}"
    else
        echo "${GRE}Docker container '${brokerContainer}' already started... ${NC}"
    fi
}

wait

#-----------------------|Docker ls|-----------------------------------------------------------------------
echo "${YLL}+----------------|Docker Containers|--------------------------------------------------+${NC}"
docker container ls -all

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"