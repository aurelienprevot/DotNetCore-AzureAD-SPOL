# DotNetCore-AzureAD-SPOL
.Net Core console application that create a list intem in SharePoint Online with Azure AD App Only Access

1. Create an application in the Azure AD linked to your Office 365 Tenant

2. Create the certificate with Windows (you can use powershell/certificat-creation.ps1 - you will need pnp cmdlets), or on Mac :
https://blogs.msdn.microsoft.com/arsen/2015/09/18/certificate-based-auth-with-azure-service-principals-from-linux-command-line/ and ```openssl pkcs12 -inkey bob_key.pem -in bob_cert.cert -export -out bob_pfx.pfx``` to generate the pfx

3. Change project.json, in the "includeFiles" property

4. In program.cs, change the value of tenantID, resource, clientID, webURI, listTitle

5. In class/ServicePrincipal.cs, add the name of the certificate and his password

6. ```dotnet run```

7. Enjoy !


Thanks to :

https://blog.mastykarz.nl/azure-ad-app-only-access-token-using-certificate-dotnet-core/
http://www.erwinmcm.com/azure-active-directory-app-only-authentication-with-officedev-pnp-powershell/
https://blogs.msdn.microsoft.com/arsen/2015/09/18/certificate-based-auth-with-azure-service-principals-from-linux-command-line/
https://gist.github.com/vgrem/ee202adf8f730ecd24a1
