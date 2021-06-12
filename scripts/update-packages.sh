#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|Nuget packages solution update - Lilo DashBoard|----------------+${NC}"

#-----------------------|Dependencies Check|------------------------------------------------------------
echo "${YLL}Checking Dependencies...${NC}"

dependencyError=0

#Check DotNet
if [ -x "$(command -v dotnet)" ]; then
    echo "${GRE}[X] DotNet is installed...${NC}"
else
    echo "${RED}[ ] DotNet is not installed...${NC}"
    echo "${RED}Script aborted.${NC}"
    exit
fi

echo "${YLL}Update started...${NC}"
#Checking all directories with have projects
for filename in `find ../src -name *.csproj`
do
    {
        directory=${filename%/*.csproj}
        cd "${directory}/"
        pwd

        #package=`dotnet list package | sed 1,3d | sed -e "s/>//g"`
        #package=${package%" *.*.* "}
        #echo $package;
        for package in `dotnet list package | grep '>' | sed 's/^ *> //g;s/ \+/ /g' | cut -f 1 -d ' ' | sort -u`
        do
            echo "${GRE}Updating package:${NC}${YLL} ${package}${NC}${GRE}...${NC}"
            dotnet add package "$package"
        done

    } &

done
wait

#-----------------------|End|---------------------------------------------------------------------------
echo ""
echo "${GRE}Script Finalized.${NC}"
echo "${YLL}+-------------------------------------------------------------------------------------+${NC}"