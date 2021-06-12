#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|Tools Setup - Lilo DashBoard|----------------+${NC}"

#-----------------------|Dependencies Check|------------------------------------------------------------
echo "${YLL}Checking Dependencies...${NC}"

#Check APT
if [ -x "$(command -v apt)" ]; then
    echo "${GRE}[X] APT is installed...${NC}"
else
    echo "${RED}[ ] APT is not installed...${NC}"
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
    sudo apt-get update
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-5.0
    rm packages-microsoft-prod.deb
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
    rm code_1.57.0-1623259737_amd64.deb
fi

#-----------------------|Installing Entity Framework|--------------------------------------------
#Check EF
if [ -x "$(command -v dotnet-ef)" ]; then
    echo "${GRE}[X] EF is installed...${NC}"
else
    echo "${RED}[ ] EF is not installed...${NC}"
    echo "${GRE}Installing...${NC}"
    dotnet tool install --global dotnet-ef
fi

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"