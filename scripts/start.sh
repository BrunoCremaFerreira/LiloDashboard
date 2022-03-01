#!/bin/bash

. ./lib.sh
log "START CONTAINERS" intro 1.0.2

#------------------|Dependencies Check|------------------

log "Checking dependencies" title

#Check Docker
checkDependency docker Docker
if [ $? -eq 1 ]; then
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
sudo docker container ls -a

#------------------|End of Script|------------------
log "End of Script..." success