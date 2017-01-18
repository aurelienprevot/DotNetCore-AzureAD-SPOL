$certroot = "c:\temp"
$certname = "CloudsNatives-2Cert"
$password = read-host "Enter certificate password" -AsSecureString
$startdate = Get-Date
$enddate = $startdate.AddYears(2)
.\makecert.exe -r -pe -n "CN=$certname" -b ($startdate.ToString("MM/dd/yyyy")) -e ($enddate.ToString("MM/dd/yyyy")) -ss my -len 2048
$cert = Get-ChildItem Cert:\CurrentUser\My | ? {$_.Subject -eq "CN=$certname"}
Export-Certificate -Type CERT -FilePath "$certroot\$certname.cer" -Cert $cert -Force
Export-PfxCertificate -FilePath "$certroot\$certname.pfx" -Cert $cert -Password $password -Force

Get-SPOAzureADManifestKeyCredentials -CertPath "C:\temp\CloudsNatives-2Cert.cer" | clip