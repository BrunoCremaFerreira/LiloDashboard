#!/bin/sh

. ./lib.sh
log "RESTORE LOCAL KUBERNETES CLUSTER" intro 1.0.0

#------------------|Dependencies Check|------------------

log "Checking dependencies" title

#Check Docker
checkDependency kind Kind
if [ $? -eq 1 ]; then
    die
fi

------------|Deleting and creating cluster--------------

log "Deleting Cluster" title
kind delete cluster --name lilo-cluster

log "Creating Cluster" title
kind create cluster --name lilo-cluster

#------------------|End of Script|----------------------
log "End of Script..." success
