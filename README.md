[![Build Status](https://joelbyford.visualstudio.com/QrCodeApiApp/_apis/build/status/niematron.QrCodeApiApp?branchName=master)](https://joelbyford.visualstudio.com/QrCodeApiApp/_build/latest?definitionId=6&branchName=master)

# QrCodeApiApp
A simple QRCode Encoder API in .NET Core using ZXing and published as an Azure API App.  "Leveraging" much of the work others have performed ahead of me.  Special thanks to GitHub Contributors Including:

https://github.com/saksitsu/-NetCore-QRCodeGenrate.git

https://github.com/micjahn/ZXing.Net

Usage (once it's running):  yoursite.com/api/encode/text=SomeTextToEncode&size=200
