#!/bin/bash

. ./lib.sh
log "START CONTAINERS" intro 1.0.2

#------------------|Dependencies Check|------------------

dependencyError=0
log "Checking dependencies" title

#Root Login
checkIfIsRoot
if [ $? -eq 1 ]; then
    dependencyError=1
fi   

#Check Docker
checkDependency docker Docker
if [ $? -eq 1 ]; then
    dependencyError=1
fi 

if [ $dependencyError -eq 1 ]; then
    die
fi

#------------------|Starting Database Container|------------------
{
    startContainer "LiloPostgres"
} &

#------------------|Starting MySql Docker container|--------------
{
    startContainer "LiloBroker"
}

wait

#-----------------------|Docker ls|-------------------------------
log "Docker Containers" title
docker container ls -a

#------------------|End of Script|------------------
log "End of Script..." success