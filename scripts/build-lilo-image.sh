#!/bin/sh

. ./lib.sh
log "LILO CONTAINER IMAGE BUILDER" intro 1.0.0

#------------------|Dependencies Check|------------------

log "Checking dependencies" title

#Check Docker
checkDependency docker Docker
if [ $? -eq 1 ]; then
    die
fi

------------|Building Image|--------------

log "Building..." title
docker build ../src -t brunocremaferreira/lilodash:dev -f ../src/API/Dockerfile

log "End of script." information



