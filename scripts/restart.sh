#!/bin/bash

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

echo "${YLL}+----------------|${NC}${GRE}Restart Containers - Lilo DashBoard${NC}${YLL}|----------------+${NC}"

#Stop
{ 
    sh stop.sh
} || {
    echo "${RED}Error in stop procedure.${NC}"
    exit
}

#Start
{ 
    sh start.sh
} || {
    echo "${RED}Error in start procedure.${NC}"
    exit
}