# DotNetCore-AzureAD-SPOL
.Net Core console application that create a list intem in SharePoint Online with Azure AD App Only Access

1. Create an application in the Azure AD linked to your Office 365 Tenant
2. Create the certificate with Windows (you can use powershell/certificat-creation.ps1 - you will need pnp cmdlets), or on Mac :
https://blogs.msdn.microsoft.com/arsen/2015/09/18/certificate-based-auth-with-azure-service-principals-from-linux-command-line/
[code]openssl pkcs12 -inkey bob_key.pem -in bob_cert.cert -export -out bob_pfx.pfx[/code]
3. Change project.json, in the "includeFiles" property
4. In program.cs, change the value of tenantID, resource, clientID, webURI, listTitle
5. In class/ServicePrincipal.cs, add the name of the certificate and his password
6. [code]dotnet run[/code]
7. Enjoy !
