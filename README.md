# dotnet.start

## Set the URLs for an ASP.NET Core app

#### By default, ASP.NET Core apps listen on the following URLs:

* http://localhost:5000
* https://localhost:5001

#### UseUrls()
Set the URLs to use statically in Program.cs.
#### Environment variables
Set the URLs using DOTNET_URLS or ASPNETCORE_URLS.
#### Command line arguments
Set the URLs with the --urls parameter when running from the command line.
#### Using launchSettings.json
Set the URLs using the applicationUrl property.
#### KestrelServerOptions.Listen()
Configure addresses for Kestrel server manually using Listen().