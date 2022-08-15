REM you'll have to find the "latest" version of where msbuild.exe resides on your machine.. here are some popular versions/locations
REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v2.0.50727
REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v3.5
REM set msBuildDir=C:\Program Files (x86)\MSBuild\12.0\Bin
set msBuildDir=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin

"libs\nuget\nuget.exe" restore TestModellerCSharp.sln

call "%msBuildDir%\msbuild.exe"  TestModellerCSharp.sln /p:Configuration=Debug  /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
set msBuildDir=

"libs\NUnit.org\nunit-console\nunit3-console.exe" "bin\Debug\TestModellerCSharp.exe" --test="Tests.%1"