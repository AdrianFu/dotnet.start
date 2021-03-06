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

## Generate cert and configure local machine for HTTPS (PowerShell):

dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p crypticpassword

dotnet dev-certs https --trust

dotnet user-secrets -p aspnetapp\aspnetapp.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"


## Install and Use dotnet new templates (e.g. IdentityService4)

dotnet new -i IdentityServer4.Templates
dotnet new --install IdentityServer4.Templates::4.0.1

## Generate DBContext from existing database

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=mPayments;Persist Security Info=True;User ID=sa;Password=G532_@diem" Microsoft.EntityFrameworkCore.SqlServer -t MPayMessageQueue -t MPayNppRap -o PaymentContext -c "PaymentContext" -f --no-onconfiguring --no-pluralize
