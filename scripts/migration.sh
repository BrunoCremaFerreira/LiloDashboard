#!/bin/sh

. ./lib.sh
log "LILO MIGRATION SCRIPT" intro 1.0.0

#------------------|Dependencies Check|------------------

log "Checking dependencies" title

#Check Docker
checkDependency dotnet Dotnet
if [ $? -eq 1 ]; then
    die
fi

#------|Setting Environment Variable|--------

export DB_CONNECTION_STRING="Server=10.5.0.5;Database=LiloDash;User Id=sa;Password=Masterkey10@;"

#------------|Apply Migrations|--------------

log "Applying Migration..." title
cd ../src/Infra.Data
dotnet ef database update

log "End of script." information
