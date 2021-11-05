dir .\nupkg
set /P version=Enter version: 
dotnet pack -p:PackageVersion=%version%
dotnet tool update --global --add-source .\nupkg\ git-pr
dotnet tool update --global --add-source .\nupkg\ git-start
dotnet tool update --global --add-source .\nupkg\ git-watch
dotnet tool update --global --add-source .\nupkg\ open-console