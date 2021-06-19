#!/bin/bash

. ./lib.sh
log "STOP CONTAINERS" intro 1.0.0

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

#-----------------------|Stopping Database Docker container|--------------------------------------------
{
    stopContainer "LiloPostgres"
} &

#-----------------------|Stopping Broker Docker container|-------------------------------------------
{
    stopContainer "LiloBroker"
}

wait

#-----------------------|Docker ls|-------------------------------
log "Docker Containers" title
docker container ls -a

#------------------|End of Script|------------------
log "End of Script..." success