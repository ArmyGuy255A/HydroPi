import * as QRCode from "qrcodejs2";

//new QRCode  
//const qrCode = require('qrcodejs2');

//new cidQrCode   
new QRCode(document.getElementById("qrCode"),
    {
        text: "@Html.Raw(Model.AuthenticatorUri)",
        width: 150,
        height: 150
    });