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

_help()
{
    echo ""
    log "Help" title
    echo ""
    log "Syntax: $ ./kubectl.sh [option] [kubeconfig path (optional)]" success
    echo ""
    log "Option     Description" success
    log "-a         Apply" warning
    log "-d         Delete" warning
    log "-debug     Create a Ubuntu pod for debug" warning
    log "-debug-rm  Remove Ubuntu debug pod" warning
    log "-h         Help" warning
    echo ""
}

#--------------------|Apply Methods|--------------------
_apply_flies_from_directory()
{   
    for file in "$1/*.yaml"; do
        kubectl apply -f "$file"
    done
}

_apply_database()
{
    log "Configuring MySql Database on Kubernetes" title
    _apply_flies_from_directory "msql"
}

_apply_rabbit_mq()
{
    log "Configuring RabbitMq on Kubernetes" title
    _apply_flies_from_directory "rabbit-mq"
}

_apply_api()
{
    log "Configuring LiloDash application on Kubernetes" title
    _apply_flies_from_directory "web-api"
}

#--------------------|Delete Methods|--------------------
_delete_flies_from_directory()
{   
    for file in "$1/*.yaml"; do
        kubectl delete -f "$file"
    done
}

_delete_database()
{
    log "Removing MySql Database from Kubernetes" title
    _delete_flies_from_directory "msql"
}

_delete_rabbit_mq()
{
    log "Removing RabbitMq from Kubernetes" title
    _delete_flies_from_directory "rabbit-mq"
}

_delete_api()
{
    log "Removing LiloDash application from Kubernetes" title
    _delete_flies_from_directory "web-api"
}

#--------------------|Main|--------------------
_main()
{
    log "KUBERNETES TOOLS SCRIPT" intro 1.0.0
    _dependency_check

    case "$1" in
        "-a")
            _set_and_validate_kubeconfig "$2"

            cd ../k8s/01-App
            _secret_create
            _apply_database
            _apply_rabbit_mq
            _apply_api
            ;;
        "-d")
            _set_and_validate_kubeconfig "$2"

            cd ../k8s/01-App
            _delete_database
            _delete_rabbit_mq
            _delete_api
            ;;
        "-debug")
            _debug_create_ubuntu_pod
            log "Waiting Pod startup..." warning
            sleep 15
            _debug_ubuntu_pod_install_tools
            log "Debug finished." success
            return 0
            ;;
        "-debug-rm")
            log "Removing debug-ubuntu..." warning
            kubectl delete pod debug-ubuntu
            return 0
            ;;
        *)
            _help
            return 0
            ;;
    esac

    log "Kubernetes Get All" title
    kubectl get all
    log "Kubernetes Get Persistent Volume" title
    kubectl get pv
    log "Kubernetes Pods (Watch)" title
    kubectl get pods --watch
}

_main "$1" "$2" 




