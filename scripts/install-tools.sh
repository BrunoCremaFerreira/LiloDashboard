#!/bin/sh

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

#-----------------|Installing ReportGenerator|------------
# Git: https://github.com/danielpalme/ReportGenerator

checkDependency reportgenerator "Report Generator"
if [ $? -eq 1 ]; then
    log "Installing..." success
    dotnet tool install -g dotnet-reportgenerator-globaltool
    dotnet tool install dotnet-reportgenerator-globaltool --tool-path tools
    dotnet new tool-manifest
    dotnet tool install dotnet-reportgenerator-globaltool
    rm -R tools
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

#-----------------|Installing Kube Lens|------------

checkDependency dotnet-ef "lens-desktop"
if [ $? -eq 1 ]; then
    log "Installing..." success
    curl -fsSL https://downloads.k8slens.dev/keys/gpg | gpg --dearmor | sudo tee /usr/share/keyrings/lens-archive-keyring.gpg > /dev/null
    echo "deb [arch=amd64 signed-by=/usr/share/keyrings/lens-archive-keyring.gpg] https://downloads.k8slens.dev/apt/debian stable main" | sudo tee /etc/apt/sources.list.d/lens.list > /dev/null
    sudo apt update
    sudo apt install lens
    lens-desktop
fi

#------------------|Installing Docker  |------------------

#
# Purpose: Install Docker on Ubuntu based systems
#
dockerInstallUbuntu()
{
    #Configuring
    sudo apt-get install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    lsb-release
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

    echo \
    "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu \
    $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

    #Installing
    sudo apt-get update
    sudo apt-get install -y docker-ce docker-ce-cli containerd.io
}

#
# Purpose: Install Docker on ChromeOs Systems
#
dockerInstallChromeBook()
{
    sudo apt-get update
    sudo apt-get install -y \
        apt-transport-https \
        ca-certificates \
        curl \
        gnupg2 \
        software-properties-common

    curl -fsSL https://download.docker.com/linux/debian/gpg | sudo apt-key add -

    sudo apt-key -y fingerprint 0EBFCD88

    sudo add-apt-repository -y \
        "deb [arch=amd64] https://download.docker.com/linux/debian \
        $(lsb_release -cs) \
        stable"

    sudo apt-get update

    sudo apt-get install -y docker-ce docker-ce-cli containerd.io
}


checkDependency docker "Docker"
if [ $? -eq 1 ]; then
    log "Installing..." success

    unameStr=$(uname -a)
    
    case "$unameStr" in

    *"penguin"*)
        log "ChromeOs Version" success
        dockerInstallChromeBook
        ;;
    
    *)
        log "Ubuntu Based Version" success
        dockerInstallUbuntu
        ;;
    esac

    #Testing
    sudo docker run hello-world
    sudo docker ps -a
    #sudo docker container rm hello-world

fi
#------------------|End of Script|------------------
log "End of Script..." success
