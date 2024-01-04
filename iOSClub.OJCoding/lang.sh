sudo apt update
# python
sudo apt install python
# dotnet
wget https://packages.microsoft.com/config/ubuntu/$repo_version/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt install dotnet-sdk-8.0
# c/c++
sudo apt install build-essential gdb
# java
sudo apt install openjdk-17-jdk