#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|Tools Setup - Lilo DashBoard|----------------+${NC}"

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

#Check APT
if [ -x "$(command -v apt)" ]; then
    echo "${GRE}[X] APT is installed...${NC}"
else
    echo "${RED}[ ] APT is not installed...${NC}"
    dependencyError=1
fi

if [ $dependencyError -eq 1 ];
then
    echo ""
    echo "${RED}Script aborted.${NC}"
    exit
fi

#-----------------------|Installing Dotnet|--------------------------------------------
#Check DotNet V 5.7 - Ubuntu V 21.04+
if [ -x "$(command -v dotnet)" ]; then
    echo "${GRE}[X] DotNet 5 is installed...${NC}"
else
    echo "${RED}[ ] DotNet 5 is not installed...${NC}"
    echo "${GRE}Installing...${NC}"
    wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    apt-get update
    apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y dotnet-sdk-5.0
fi

#-----------------------|Installing Vs Code|--------------------------------------------
#Check Vs Code
if [ -x "$(command -v code)" ]; then
    echo "${GRE}[X] Vs Code is installed...${NC}"
else
    echo "${RED}[ ] Vs Code is not installed...${NC}"
    echo "${GRE}Installing...${NC}"
    wget https://az764295.vo.msecnd.net/stable/b4c1bd0a9b03c749ea011b06c6d2676c8091a70c/code_1.57.0-1623259737_amd64.deb
    sudo dpkg -i code_1.57.0-1623259737_amd64.deb
fi

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"