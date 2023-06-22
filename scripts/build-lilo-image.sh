#!/bin/sh

. ./lib.sh

_check_dependecies()
{
    log "Checking dependencies" title
    checkDependency podman Podman
    if [ $? -eq 1 ]; then
        die
    fi
}

_build_api_image()
{
    log "Building API Image..." title
    podman build ../src -t brunocremaferreira/lilodash:latest -f ../src/API/Dockerfile
}

_build_migration_image()
{
    log "Building Migration Image..." title
    podman build ../src -t brunocremaferreira/lilodash-migration:latest -f ../src/Infra.Data/Dockerfile
}

_main()
{
    log "LILO CONTAINER IMAGE BUILDER" intro 2.0.0
    _check_dependecies
    _build_api_image
    _build_migration_image
    log "End of script." information
}

_main


