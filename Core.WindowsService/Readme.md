# Background Info

**Create a Windows Service using BackgroundService**

**Tags**
* WorkerService
* WindowsServices

**More Info**

1. https://docs.microsoft.com/en-us/dotnet/core/extensions/windows-service

# Steps

1. dotnet new worker --name Core.WindowService
1. dotnet add package Microsoft.Extensions.Hosting.WindowsServices
1. dotnet add package Microsoft.Extensions.Http
1. edit code ...

# Publish

1. dotnet publish --output "C:\temp\"

# Create the Windows Service

1. To create the Windows Service, use the native Windows Service Control Manager's (sc.exe) create command.<br/> Run PowerShell as an Administrator.
1. sc.exe create ".NET Joke Service" binpath="C:\temp\Core.WindowsService.exe"
1. OR If you need to change the content root of the host configuration, you can pass it as a command-line argument when specifying the binpath:
<br>sc.exe create "Svc Name" binpath="C:\temp\Core.WindowsService.exe --contentRoot C:\Other\Path"
1. To query current service configuration.<br/> sc.exe qfailure ".NET Joke Service"
1. To config recovery.<br>sc.exe failure ".NET Joke Service" reset=0 actions=restart/60000/restart/60000/run/1000

**To debug the application, ensure that you're not attempting to debug the executable that is actively running within the Windows Services process.**

1. Start service.<br/>sc.exe start ".NET Joke Service"
1. Stop service.<br/>sc.exe stop ".NET Joke Service"
1. Delete service.<br/>sc.exe delete ".NET Joke Service"