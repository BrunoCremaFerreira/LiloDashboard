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

if [ ! -f "$1" ]; then
    die "The '$1' kubernetes configuration file was not found."
fi

log  "Setting environment variable with Kubernete cluster yaml config path '$1'"
export KUBECONFIG="$1"

cd ../k8s/01-App
log "Configuring MySql Database on Kubernetes" title
log "Applying deployment.yaml..." title
kubectl apply -f msql/deployment.yaml
log "Applying service.yaml..." title
kubectl apply -f msql/service.yaml

log "Configuring RabbitMq on Kubernetes" title
log "Applying deployment.yaml..." title
kubectl apply -f rabbit-mq/deployment.yaml
log "Applying service.yaml..." title
kubectl apply -f rabbit-mq/service.yaml

log "Configuring LiloDash application on Kubernetes" title
log "Applying config-map.yaml..." title
kubectl apply -f web-api/config-map.yaml
log "Applying deployment.yaml..." title
kubectl apply -f web-api/deployment.yaml
log "Applying service.yaml..." title
kubectl apply -f web-api/service.yaml
log "Applying service-load-balancer.yaml..." title
kubectl apply -f web-api/service-load-balancer.yaml

log "Kubernetes Get All" title
kubectl get all






