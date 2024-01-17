# Shepa Payment Gateway


# How To User

## 1.get merchant pin from shepa.com
after registration and request for payment gateway, api code will send to your email, use it hear
## 2.install package
## 3.request for paymant to get token code
Use code blow to get token
```sh
ShepaMerchant.Merchant merchant = new ShepaMerchant.Merchant();
var data = merchant.requestToken("Your_Api_Code", Amount, "Call_back_Url", "Client_Mobile(optional)", "Client_Email(optional)", "Description_for_payment(optional)");
```


## 4.verify your payment
Use this code to verify your payment
```sh
ShepaMerchant.Merchant merchant = new ShepaMerchant.Merchant();
var responce = merchant.verifyPayment("Your_Api_Code", "Token", Amount);
```


