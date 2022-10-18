 [![Test on Pull Request to Main](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-pr.yml/badge.svg)](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-pr.yml)  [![Deploy on Push to Main](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-push.yml/badge.svg)](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/main-push.yml) [![Weekly CodeQL Security Scan](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/joelbyford/QrCodeApiApp/actions/workflows/codeql-analysis.yml)

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fjoelbyford%2FQrCodeApiApp%2Fmain%2FDeployTemplates%2FAzureLinuxWebAppArm.json)

# QrCodeApiApp
A simple QRCode Encoder API in .NET 6 using ZXing and published as an Azure API App.  

## OS Limitations
**Windows Only** - Currently this controller uses features from System.Drawing.Common which only work on Windows platforms therefore the service must be run as a Windows App Service at this time.   Please submit an issue if needed on other platforms and will prioritize the change when requested.  Thanks for your understanding.


## Examples and Usage
For examples running on localhost (e.g. local development), please see [manualTesting.http](QrCodeApiApp/test/manualTesting.http)

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
## Basic Authentication
Added the ability to optionally use [Basic Authentication](https://github.com/joelbyford/BasicAuth) to secure the API with one or more User/Password combinations using classic RFC 2617 HTTP authentication.  In order to leverage this functionality, please use the `appsettings.json` file to enable basic authentication, provide your "realm" (typically your API's url), and point to the json file where your users are listed (defaults to the provided `authorizedUsers.json`):

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

**PLEASE DO NOT check userID's or passwords into your forked repo!**

## Lineage and Credit
This leverages much of the work others have performed ahead of me.  Special thanks to GitHub Contributors Including:

https://github.com/saksitsu/-NetCore-QRCodeGenrate.git

https://github.com/micjahn/ZXing.Net
