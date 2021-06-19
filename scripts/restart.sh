#!/bin/bash

. ./lib.sh
log "CONTAINERS RESTART" intro 1.0.0

#------------------|Restart Docker|------------------

#Stop
{ 
    sh stop.sh nointro
} || {
    die "Error in stop procedure."
}

#Start
{ 
    sh start.sh nointro
} || {
    echo "Error in start procedure."
}