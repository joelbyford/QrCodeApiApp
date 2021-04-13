[![Deploy on Push to Main](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-push.yml/badge.svg)](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-push.yml) [![Test on Pull Request to Main](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-pr.yml/badge.svg)](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-pr.yml)

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fjoelbyford%2FQrCodeApiApp%2Fmain%2FDeployTemplates%2FAzureLinuxWebAppArm.json)

# QrCodeApiApp
A simple QRCode Encoder API in .NET 5 using ZXing and published as an Azure API App.  


## Examples and Usage

### GET Usage 
Once running as a website, simply call
```
GET http://yoursite.com/api/encode?text=SomeTextToEncode&size=200
```

### POST Usage
Additionally you may send text as `text/plain` to make it easier to send blocks of text without URL encoding them.  Example of that call is here:
```
POST http://localhost:5000/api/encode?size=500
Content-Type: text/plain

Some text or URL to encode goes here
``` 
## Basic Authentication (Added on 1/22/2021)
Added the ability to use Basic Authentication with the API.  In order to leverage this functionality, please use the `appsettings.json` file to enable basic authentication, provide your "realm" (typically your API's url), and point to the json file where your users are listed (defaults to the provided `authorizedUsers.json`):

```
"AppSettings" : {
    "BasicAuth" : {
      "Enabled" : false,                     # change this to true
      "Realm" : "example-realm.com",         # change this to your API's Domain
      "UsersJson" : "authorizedUsers.json"   # change this (if necessary) to the json file with authorized users
    }
  }

```

The Authorized Users are simply stored in a json file in the following format:

```
{    
    "testUser" : "testPassword",
    "devUser" : "devPassword"
}
```
## Lineage and Credit
This leverages much of the work others have performed ahead of me.  Special thanks to GitHub Contributors Including:

https://github.com/saksitsu/-NetCore-QRCodeGenrate.git

https://github.com/micjahn/ZXing.Net
