#!/bin/bash

. ./lib.sh
log "DOT NET DEVELOPMENT ENVIRONMENT" intro 1.0.2

#------------------|Dependencies Check|------------------

#Checking APT
log "Checking dependencies" title
checkDependency apt APT
if [ $? -eq 1 ]; then
    die
fi   
#------------------|APT Update        |------------------

#Running Apt Update
log "Updating Source List" title
sudo apt-get update


log "Installer" title
#------------------|Installing .Net 5  |------------------

checkDependency dotnet ".NET Core 5"
if [ $? -eq 1 ]; then
    log "Installing..." success
    wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    sudo apt-get update
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-5.0
    rm -f packages-microsoft-prod.deb
fi

#-----------------|Installing Entity Framework|------------

checkDependency dotnet-ef "Entity Framework"
if [ $? -eq 1 ]; then
    log "Installing..." success
    dotnet tool install --global dotnet-ef
fi

#------------------|VS Code            |------------------

checkDependency code "Visual Studio Code"
if [ $? -eq 1 ]; then
    log "Installing..." success
    wget https://az764295.vo.msecnd.net/stable/b4c1bd0a9b03c749ea011b06c6d2676c8091a70c/code_1.57.0-1623259737_amd64.deb
    sudo dpkg -i code_1.57.0-1623259737_amd64.deb
    rm -f code_1.57.0-1623259737_amd64.deb
fi

#------------------|VS Code - Extensions|------------------
log "Visual Code Extensions" title
installVsExtension()
{
    local extensionName="$1"
    log "Installing: $extensionName ..." success
    code --install-extension $extensionName
}

installVsExtension "ms-dotnettools.csharp"
installVsExtension "alefragnani.project-manager"
installVsExtension "vscode-icons-team.vscode-icons"
installVsExtension "jchannon.csharpextensions"
installVsExtension "coenraads.bracket-pair-colorizer"
installVsExtension "christian-kohler.path-intellisense"
installVsExtension "jmrog.vscode-nuget-package-manager"
installVsExtension "alefragnani.bookmarks"
installVsExtension "eamodio.gitlens"
installVsExtension "donjayamanne.githistory"
installVsExtension "felipecaputo.git-project-manager"
installVsExtension "github.vscode-pull-request-github"
installVsExtension "spywhere.guides"
installVsExtension "abusaidm.html-snippets"
installVsExtension "ms-azuretools.vscode-docker"
installVsExtension "fernandoescolar.vscode-solution-explorer"

#------------------|End of Script|------------------
log "End of Script..." success