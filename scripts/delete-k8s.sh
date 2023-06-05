#!/bin/sh

. ./lib.sh

log "KUBERNETES DELETE" intro 1.0.0

#------------------|Dependencies Check|------------------

#Checking APT
log "Checking dependencies" title
checkDependency kubectl Kubectl
if [ $? -eq 1 ]; then
    die
fi 

log "Setting KUBECONFIG" title

if [ ! "$1" ]; then
    die "Please inform the kubeconfig file. Example: $ ./deploy-k8s.sh \"/home/user/k8s-config.yaml\""
fi

if [ ! -f "$1" ]; then
    die "The kubeconfig file '$1' was not found!"
fi

log  "Setting environment variable with Kubernete cluster yaml config path '$1'"
export KUBECONFIG="$1"

cd ../k8s/01-App
log "Removing MySql Database on Kubernetes" title
log "Removing content created by deployment.yaml..." title
kubectl delete -f msql/deployment.yaml
log "Removing content created by  service.yaml..." title
kubectl delete -f msql/service.yaml

log "Removing RabbitMq from Kubernetes cluster" title
log "Removing content created by  deployment.yaml..." title
kubectl delete -f rabbit-mq/deployment.yaml
log "Removing content created by  service.yaml..." title
kubectl delete -f rabbit-mq/service.yaml

log "Removing LiloDash application on Kubernetes" title
log "Removing config-map.yaml..." title
kubectl delete -f web-api/config-map.yaml
log "Removing content created by  deployment.yaml..." title
kubectl delete -f web-api/deployment.yaml
log "Removing content created by  service.yaml..." title
kubectl delete -f web-api/service.yaml
log "Removing service-load-balancer.yaml..." title
kubectl delete -f web-api/service-load-balancer.yaml

log "Kubernetes Get All" title
kubectl get all






