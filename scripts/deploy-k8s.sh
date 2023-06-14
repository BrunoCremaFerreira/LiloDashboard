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

_secret_create()
{
    log "Setting secrets" title
    log "Setting database password secret"
    kubectl create secret generic lilo-db-secret --from-literal=SA_PASSWORD=Masterkey10@
}

_apply_database()
{
    log "Configuring MySql Database on Kubernetes" title

    log "Applying deployment.yaml..." title
    kubectl apply -f msql/deployment.yaml

    log "Applying service.yaml..." title
    kubectl apply -f msql/service.yaml
}

_apply_rabbit_mq()
{
    log "Configuring RabbitMq on Kubernetes" title

    log "Applying deployment.yaml..." title
    kubectl apply -f rabbit-mq/deployment.yaml

    log "Applying service.yaml..." title
    kubectl apply -f rabbit-mq/service.yaml
}

_apply_api()
{
    log "Configuring LiloDash application on Kubernetes" title

    log "Applying config-map.yaml..." title
    kubectl apply -f web-api/config-map.yaml

    log "Applying deployment.yaml..." title
    kubectl apply -f web-api/deployment.yaml

    log "Applying service.yaml..." title
    kubectl apply -f web-api/service.yaml

    log "Applying service-load-balancer.yaml..." title
    kubectl apply -f web-api/service-load-balancer.yaml
}

_debug_ubuntu_pod_install_tools()
{
    log "debug-ubuntu pod: Installing tools" title

    kubectl exec -it debug-ubuntu -- apt-get update
    kubectl exec -it debug-ubuntu -- apt-get install -y iputils-ping
    kubectl exec -it debug-ubuntu -- apt-get install -y nmap
    
    log "debug-ubuntu pod: Bash" title
    kubectl exec -it debug-ubuntu -- bash
}

_debug_create_ubuntu_pod()
{
    log "Debug - Ubuntu Pod" title
    log "Creating Ubuntu pod for debug..." warning

    cat <<EOF | kubectl apply -f -
apiVersion: v1
kind: Pod
metadata:
  name: debug-ubuntu
  labels:
    app: ubuntu
spec:
  containers:
  - image: ubuntu
    command:
      - "sleep"
      - "604800"
    imagePullPolicy: IfNotPresent
    name: ubuntu
  restartPolicy: Always
EOF
}

_main()
{
    log "KUBERNETES DEPLOY" intro 1.0.0

    _dependency_check

    # Debug pod
    if [ "$1" = "-d" ]; then
        _debug_create_ubuntu_pod
        log "Waiting Pod startup..." warning
        sleep 15
        _debug_ubuntu_pod_install_tools
        log "Debug finished." success
        return 0
    fi

    # Removing debug pod
    if [ "$1" = "-D" ]; then
        log "Removing debug-ubuntu..." warning
        kubectl delete pod debug-ubuntu
        return 0
    fi

    _set_and_validate_kubeconfig "$1"
        
    cd ../k8s/01-App
    _secret_create
    _apply_database
    _apply_rabbit_mq
    _apply_api

    log "Kubernetes Get All" title
    kubectl get all
}

_main "$1"




