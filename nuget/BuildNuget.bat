set PKG_VER=2017.1.1
nuget.exe pack -Prop Configuration=Release -Version %PKG_VER% "../Library/Library.nuspec"  -o  ../../NugetPackages
