#!/bin/sh

. ./lib.sh

_dependency_check()
{
    log "Checking dependencies" title
    checkDependency kubectl Kubectl
    if [ $? -eq 1 ]; then
        die
    fi
}

_set_and_validate_kubeconfig()
{
    log "Setting/Validating KUBECONFIG" title

    if [ "$1" ]; then
        log  "Setting environment variable with Kubernete cluster yaml config path '$1'"
        export KUBECONFIG="$1"
    fi

    if [ ! "$KUBECONFIG" ]; then
        die "Please inform the kubeconfig file. Example: $ ./deploy-k8s.sh \"/home/user/k8s-config.yaml\""
    fi

    if [ ! -f "$KUBECONFIG" ]; then
        die "The kubeconfig file '$KUBECONFIG' was not found!"
    fi
}

_delete_api()
{
    log "Removing LiloDash application on Kubernetes" title
    log "Removing config-map.yaml..." title
    kubectl delete -f web-api/config-map.yaml
    log "Removing content created by  deployment.yaml..." title
    kubectl delete -f web-api/deployment.yaml
    log "Removing content created by  service.yaml..." title
    kubectl delete -f web-api/service.yaml
    log "Removing service-load-balancer.yaml..." title
    kubectl delete -f web-api/service-load-balancer.yaml
}

_delete_rabbit_mq()
{
    log "Removing RabbitMq from Kubernetes cluster" title
    log "Removing content created by  deployment.yaml..." title
    kubectl delete -f rabbit-mq/deployment.yaml
    log "Removing content created by  service.yaml..." title
    kubectl delete -f rabbit-mq/service.yaml
}

_delete_database()
{
    log "Removing MySql Database on Kubernetes" title
    log "Removing content created by deployment.yaml..." title
    kubectl delete -f msql/deployment.yaml
    log "Removing content created by  service.yaml..." title
    kubectl delete -f msql/service.yaml
}

_main()
{
    log "KUBERNETES DELETE" intro 1.0.0

    _dependency_check
    _set_and_validate_kubeconfig "$1"

    cd ../k8s/01-App
    _delete_api
    _delete_rabbit_mq
    _delete_database
    
    log "Kubernetes Get All" title
    kubectl get all
}

_main "$1"



