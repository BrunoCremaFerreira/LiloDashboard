#!/bin/bash

. ./lib.sh
log "STOP CONTAINERS" intro 1.0.2

#------------------|Dependencies Check|------------------

log "Checking dependencies" title

#Check Docker
checkDependency docker Docker
if [ $? -eq 1 ]; then
    die
fi

#-----------------------|Stopping Database Docker container|--------------------------------------------
{
    stopContainer "LiloDatabase"
} &

#-----------------------|Stopping Broker Docker container|-------------------------------------------
{
    stopContainer "LiloBroker"
} &

#-----------------------|Stopping Jenkins Docker container|-------------------------------------------
{
    stopContainer "LiloJenkins"
}

wait

#-----------------------|Docker ls|-------------------------------
log "Docker Containers" title
sudo docker container ls -a

#------------------|End of Script|------------------
log "End of Script..." success
