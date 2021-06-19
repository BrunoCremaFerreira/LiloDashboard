#!/bin/bash

. ./lib.sh
log "UPDATE SOLUTION NUGET PACKAGES" intro 1.0.2

#------------------|Dependencies Check|------------------

#Checking APT
log "Checking dependencies" title
checkDependency dotnet "Dot Net" 
if [ $? -eq 1 ]; then
    die
fi   

#-----------------------|Dependencies Check|----------------------------------
log "Update started..." title

#Checking all directories with have projects
for filename in `find ../src -name *.csproj`
do
    {
        directory=${filename%/*.csproj}
        cd "${directory}/"
        pwd

        for package in `dotnet list package | grep '>' | sed 's/^ *> //g;s/ \+/ /g' | cut -f 1 -d ' ' | sort -u`
        do
            log "Updating package:${NC}${YLL} ${package}${NC}${GRE}..." success
            dotnet add package "$package"
        done

    } &

done
wait

#------------------|End of Script|------------------
log "End of Script..." success