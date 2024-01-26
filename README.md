# Introduction 
Azure ClickOnce Sign Tool

# Usage

AzureSignToolClickOnce.exe ^\
 -path=bin\Release\app.publish\^\
 -azure-key-vault-url=https://1234-vault.vault.azure.net/^\
 -azure-key-vault-client-id=1234^\
 -azure-key-vault-client-secret=1234^\
 -azure-key-vault-tenant-id=1234^\
 -azure-key-vault-certificate=MyGlobalSignCert^\
 -timestamp-sha2=http://timestamp.globalsign.com/?signature=sha2^\
 -timestamp-rfc3161=http://rfc3161timestamp.globalsign.com/advanced^\
 -description=MyApp^

# Usage short version

AzureSignToolClickOnce.exe ^\
 -p=bin\Release\app.publish\^\
 -kvu=https://1234-vault.vault.azure.net/^\
 -kvi=1234^\
 -kvs=1234^\
 -kvt=1234^\
 -kvc=MyGlobalSignCert^\
 -tr=http://timestamp.globalsign.com/?signature=sha2^\
 -td=http://rfc3161timestamp.globalsign.com/advanced^\
 -d=MyApp^

More info on:
https://www.davici.nl/blog/clickonce-signing-from-azure-devops-via-azure-key-vault
