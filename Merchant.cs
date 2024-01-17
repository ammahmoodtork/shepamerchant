using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ShepaMerchant
{
    public class Merchant
    {
        public RequestTokenResponce requestToken(string pin, Int64 amount, string callback, string mobile, string email, string description)
        {
            return this.requestToken(pin, amount, callback, mobile, email, description, "", "", "");
        }
        public RequestTokenResponce requestToken(string pin, Int64 amount, string callback, string mobile, string email, string description, string orderId)
        {
            return this.requestToken(pin, amount, callback, mobile, email, description, orderId, "", "");
        }
        public RequestTokenResponce requestToken(string pin, Int64 amount, string callback, string mobile, string email, string description, string orderId, string cardNumber)
        {
            return this.requestToken(pin, amount, callback, mobile, email, description, orderId, cardNumber, "");
        }
        public RequestTokenResponce requestToken(string pin, Int64 amount, string callback, string mobile, string email, string description, string orderId, string cardNumber, string NationalNumber)
        {
            string URI = "https://merchant.shepa.com/api/v1/token";
            Newtonsoft.Json.Linq.JObject jObject = new Newtonsoft.Json.Linq.JObject();
            jObject.Add("api", pin);
            jObject.Add("amount", amount);
            jObject.Add("callback", callback);
            if (!string.IsNullOrEmpty(mobile))
                jObject.Add("mobile", mobile);
            if (!string.IsNullOrEmpty(email))
                jObject.Add("email", email);
            if (!string.IsNullOrEmpty(description))
                jObject.Add("description", description);
            if (!string.IsNullOrEmpty(cardNumber))
                jObject.Add("description", cardNumber);
            if (!string.IsNullOrEmpty(NationalNumber))
                jObject.Add("description", NationalNumber);
            if (!string.IsNullOrEmpty(orderId))
                jObject.Add("description", orderId);
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
           new System.Net.Security.RemoteCertificateValidationCallback(
                delegate
                { return true; }
            );
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2227.1 Safari/537.36");
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string HtmlResult = wc.UploadString(URI, Newtonsoft.Json.JsonConvert.SerializeObject(jObject));
                    var responce = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestTokenResponce>(HtmlResult);
                    return responce;
                }
            }
            catch (Exception ex)
            {
                return new RequestTokenResponce()
                {
                    success = false,
                    error = new string[] { "اتصال امکان پذیر نیست" }
                };
            }

        }

        public VerifyResponce verifyPayment(string pin, string token, Int64 amount)
        {
            return this.verifyPayment(pin, token, amount, new List<SharingAccount>());
        }
        public VerifyResponce verifyPayment(string pin, string token, Int64 amount, List<SharingAccount> sharingAccount)
        {
            string URI = "https://merchant.shepa.com/api/v1/verify";

            var obj = new
            {
                api = pin,
                token = token,
                amount = amount,
                shares = sharingAccount
            };
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
           new System.Net.Security.RemoteCertificateValidationCallback(
                delegate
                { return true; }
            );
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string HtmlResult = wc.UploadString(URI, Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                    var responce = Newtonsoft.Json.JsonConvert.DeserializeObject<VerifyResponce>(HtmlResult);
                    return responce;
                }
            }
            catch { }
            return new VerifyResponce()
            {
                success = false,
                error = new string[] { "اتصال امکان پذیر نیست" }
            };
        }
    }
}
