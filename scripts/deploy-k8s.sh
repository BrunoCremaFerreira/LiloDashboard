#!/bin/sh

. ./lib.sh

log "KUBERNETES DEPLOY" intro 1.0.0

#------------------|Dependencies Check|------------------

#Checking APT
log "Checking dependencies" title
checkDependency kubectl Kubectl
if [ $? -eq 1 ]; then
    die
fi 

log "Setting KUBECONFIG" title
log  "Setting environment variable with Kubernete cluster yaml config path '$1'"
export KUBECONFIG="$1"

log "" title



