using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.lib.utils
{
    public class SecurityUtils
    {

        public IDictionary<String, String> getSecurityHeaders(String clientId, String clientSecretKey, String httpMethod, String url, String transactionParameters)
        {
            IDictionary<String, String> headers = new Dictionary<String, String>();

            headers.Add(ConstantUtils.CONTENT_TYPE_HEADER, ConstantUtils.CONTENT_TYPE_APPLICATION_JSON);
            
            byte[] encodedByte = System.Text.ASCIIEncoding.ASCII.GetBytes(clientId);
            string base64EncodedClientId = Convert.ToBase64String(encodedByte).Trim();
            headers.Add(ConstantUtils.AUTHORIZATION_HEADER, ConstantUtils.INTERSWITCH_AUTHORIZATION + " " + base64EncodedClientId);

            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            String timestamp = Convert.ToString(secondsSinceEpoch);
            headers.Add(ConstantUtils.TIMESTAMP_HEADER, timestamp);
            String nonce = SignatureUtils.generateNonce();
            headers.Add(ConstantUtils.NONCE_HEADER, nonce);

            String signatureMethod = ConstantUtils.DEFAULT_SIGNATURE_METHOD;
            headers.Add(ConstantUtils.SIGNATURE_METHOD_HEADER, signatureMethod);
            String signature = SignatureUtils.getSignature(httpMethod, url, timestamp, nonce, clientId, clientSecretKey, transactionParameters, signatureMethod);
            headers.Add(ConstantUtils.SIGNATURE_HEADER, signature);

            return headers;
        }


        public static bool isNullorEmpty(String str)
        {
            return str == null || "".Equals(str);
        }


    }
}
