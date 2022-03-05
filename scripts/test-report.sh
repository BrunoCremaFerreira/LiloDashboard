#!/bin/sh

. ./lib.sh

createXMLReport()
{
    log "Generating XML Test Report..." title
    cd "../test/LiloDash.Tests"

    log "Removing last report..." information
    rm -v -R "TestResults"

    log "Running tests..." information
    dotnet test --collect:"XPlat Code Coverage" --settings CodeCoverage.runsettings
}

createHTMLReport()
{
    log "Creating HTML Coverage Report..." title
    cd "TestResults"

    local generatedDir=$(ls)
    cd "$generatedDir"

    log "PWD: $(pwd)" success

    log "Running..." information
    reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html 
}

openReport()
{
    cd "coveragereport"
    dolphin . &
}

main()
{
    clear
    log "COVERAGE TEST REPORT" intro 1.0.0
    createXMLReport
    createHTMLReport
    openReport
}

main
