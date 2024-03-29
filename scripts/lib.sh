#!/bin/sh

#Text Decorations
RED='\033[1;31m'
YLL='\033[1;33m'
GRE='\033[1;32m'
NC='\033[0m'

# Script
printLogo()
{
    echo "${YLL}"
    cat << "EOF"

 _      _ _         _____            _
| |    (_) |       |  __ \          | |
| |     _| | ___   | |  | | __ _ ___| |__         ()_
| |    | | |/ _ \  | |  | |/ _` / __| '_ \    (___) '`;
| |____| | | (_) | | |__| | (_| \__ \ | | |   /,    /`
|______|_|_|\___/  |_____/ \__,_|___/_| |_|   \\"--\\
                                            
                                                               
EOF
echo "${NC}"
}

#
# Purpose: Display Message Log
#
log()
{
    local mode=$2
    local message="$1"
    case $mode in
        intro)
            
            printLogo
            echo "${YLL}    Script: ${NC}${GRE}$message${NC}"
            echo "${YLL}    Version: ${NC}${GRE}$3${NC}"
            echo "${YLL}+------------------------------------------------------------------------------+${NC}"
            ;;
        title)
            echo "${YLL}+----------------|$message|----------------+${NC}"
            ;;
        success)
            echo "${GRE}$message${NC}"
            break
            ;;
        information)
            echo "${YLL}$message${NC}"
            break
            ;;
        warning)
            echo "${YLL}$message${NC}"
            break
            ;;
        error)
            echo "${RED}$message${NC}"
            break
            ;;
        *)
            echo "$message"
            ;;
    esac
}

#
# Purpose: Display message and die with given exit code
# 
die(){
        local message="$1"
        local exitCode="$2"
        
        echo ""
        log "$message" error
        log "Script aborted." warning
        echo ""
        exit 1
}


#
# Purpose: Check command dependency
#
checkDependency()
{
    local cmd="$1"
    local cmdName="$2"
    
    if [ -x "$(command -v $cmd)" ]; then
        log "[X] $cmdName is installed..." success
        return 0
    else
        log "[ ] $cmdName is not installed..." error
        return 1
    fi
}

#
# Purpose: Check if logged user is root
#
checkIfIsRoot()
{
    #Root Login
    if [ $(id -u) -eq 0 ]
    then 
        log "[X] Running as Root..." success
        return 0
    else
        log "[ ] Not running as Root..." error
        return 1
    fi
}

#
# Purpose: Start Docker Container
#
startContainer()
{
    local containerName="$1"
    log "Starting $containerName container..." information
    if [ ! "$(sudo docker ps -q -f name=${containerName})" ]; 
    then
        sudo docker container start "${containerName}"
    else
        log "Docker container '${containerName}' already started..." success
    fi
}

#
# Purpose: Stop Docker Container
#
stopContainer()
{
    containerName="$1"
    log "Stopping ${containerName} container..." information
    if [ ! "$(sudo docker ps -q -f name=${containerName})" ]; 
    then
        log "Docker container '${containerName}' already stopped..." success
    else
        log "Stopping docker container '${containerName}'..." success
        sudo docker container stop "${containerName}"
    fi
}
