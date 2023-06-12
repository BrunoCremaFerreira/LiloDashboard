#!/bin/sh

. ./lib.sh

readonly DOTNET_SDK_VERSION="6.0"

_validate_os()
{
    log "Checking OS distribution" title

    local unameStr=$(uname -a)
    case "$unameStr" in

    *"Neon"*)
        log "KDE Neon" success
        ;;
    *"Debian"*)
        log "Debian based system" success
        ;;
    *"Ubuntu"*)
        log "Ubuntu based system" success
        ;;
    *)
        die "OS Not Supported."
        ;;
    esac
}

_install_kubectl()
{
    checkDependency kubectl "Kubectl"
    if [ $? -eq 1 ]; then
        log "Installing..." success
        sudo apt-get update
        sudo apt-get install -y ca-certificates curl
        sudo apt-get install -y apt-transport-https
        curl -fsSL https://packages.cloud.google.com/apt/doc/apt-key.gpg | sudo gpg --dearmor -o /etc/apt/keyrings/kubernetes-archive-keyring.gpg
        echo "deb [signed-by=/etc/apt/keyrings/kubernetes-archive-keyring.gpg] https://apt.kubernetes.io/ kubernetes-xenial main" | sudo tee /etc/apt/sources.list.d/kubernetes.list
        sudo apt-get update
        sudo apt-get install -y kubectl
    fi
}

_install_kube_lens()
{
    checkDependency lens-desktop "lens-desktop"
    if [ $? -eq 1 ]; then
        log "Installing..." success
        curl -fsSL https://downloads.k8slens.dev/keys/gpg | gpg --dearmor | sudo tee /usr/share/keyrings/lens-archive-keyring.gpg > /dev/null
        echo "deb [arch=amd64 signed-by=/usr/share/keyrings/lens-archive-keyring.gpg] https://downloads.k8slens.dev/apt/debian stable main" | sudo tee /etc/apt/sources.list.d/lens.list > /dev/null
        sudo apt update
        sudo apt install lens
        log "Use de command lens-desktop to acces the tool" success
    fi
}

_install_vs_code()
{
    checkDependency code "Vs Code"
    if [ $? -eq 1 ]; then
        log "Installing..." success
        local home_path="$HOME"
        wget "https://code.visualstudio.com/sha/download?build=stable&os=linux-deb-x64" -O "$home_path/tmp-vscode.deb"
        sudo dpkg -i "$home_path/tmp-vscode.deb"
        rm -f "$home_path/tmp-vscode.deb"
    fi
}

_install_vs_code_extensions()
{
    log "Visual Code Extensions" title
    code --install-extension "ms-dotnettools.csharp"
    code --install-extension "alefragnani.project-manager"
    code --install-extension "vscode-icons-team.vscode-icons"
    code --install-extension "jchannon.csharpextensions"
    code --install-extension "coenraads.bracket-pair-colorizer"
    code --install-extension "christian-kohler.path-intellisense"
    code --install-extension "jmrog.vscode-nuget-package-manager"
    code --install-extension "alefragnani.bookmarks"
    code --install-extension "eamodio.gitlens"
    code --install-extension "donjayamanne.githistory"
    code --install-extension "felipecaputo.git-project-manager"
    code --install-extension "github.vscode-pull-request-github"
    code --install-extension "spywhere.guides"
    code --install-extension "abusaidm.html-snippets"
    code --install-extension "ms-azuretools.vscode-docker"
    code --install-extension "fernandoescolar.vscode-solution-explorer"
    code --install-extension "ms-vscode-remote.remote-containers"
}

_install_dotnet_sdk()
{
    checkDependency dotnet "Dot Net SDK"
    local result_value=$?
    if [ $result_value -eq 0 ]; then
        log "Value: $1" success
        if [ "$1" = "-f" ]; then
            log "Removing..." warning
            sudo apt remove dotnet* -y
            sudo apt remove aspnetcore* -y
            sudo apt remove netstandard* -y
        fi
    fi
    if [ $result_value -eq 1 ] || [ "$1" = "-f" ]; then
        log "Installing..." success
        
        log "Creating /etc/apt/preferences.d/dotnet.pref ..." warning
        echo "Package: *
Pin: origin \"packages.microsoft.com\"
Pin-Priority: 1001" >> "$HOME/dotnet.pref"
        sudo cp -f -v "$HOME/dotnet.pref" "/etc/apt/preferences.d/dotnet.pref"
        rm "$HOME/dotnet.pref"
        
        log "Updating packages..." warning
        sudo apt update
        
        log "Installing DotNet package..." warning
        sudo apt install "dotnet-sdk-$DOTNET_SDK_VERSION" -y
    fi
}

_install_dotnet_ef()
{
    checkDependency dotnet-ef "Dot Net Entity Framework Tool"
    if [ $? -eq 1 ]; then
        log "Installing..." success
        dotnet tool install --global dotnet-ef
    else
        log "Updating..." success
        dotnet tool update --global dotnet-ef
    fi
}

_install_podman()
{
    checkDependency podman "Podman"
    if [ $? -eq 1 ]; then
        log "Installing..." success

        sudo apt-get update
        sudo apt-get install -y podman
    fi
}

_install_podman_compose()
{
    checkDependency podman-compose "Podman Compose"
    if [ $? -eq 1 ]; then
        log "Installing..." success

        sudo apt install python3-pip -y
        pip3 install podman-compose
    fi
}

_main()
{
    log "DOT NET DEVELOPMENT ENVIRONMENT" intro "$DOTNET_SDK_VERSION"

    _validate_os

    #Checking APT
    log "Checking base dependencies" title
    checkDependency apt APT
    if [ $? -eq 1 ]; then
        die
    fi

    _install_kubectl
    _install_kube_lens
    _install_vs_code
    _install_vs_code_extensions
    _install_dotnet_sdk "$1"
    _install_dotnet_ef
    _install_podman
    _install_podman_compose
    
    log "End of Script..." success
}

_main "$1"
