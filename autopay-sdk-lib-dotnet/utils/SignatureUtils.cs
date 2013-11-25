using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace com.interswitchng.techquest.autopay.sdk.lib.utils
{
    public class SignatureUtils
    {

        public static String getSignature(String httpMethod, String url, String timestamp, String nonce, String clientId, String clientSecretKey, String transactionParameters, String signatureMethod)
	    {
	        String signatureCipher = getBaseSignatureCipher(httpMethod, url, timestamp, nonce, clientId, clientSecretKey);
			signatureCipher = signatureCipher + transactionParameters;
            byte[] signaturebytes = getHash(signatureCipher, signatureMethod);
            string signature = Convert.ToBase64String(signaturebytes).Trim();
			
            Console.WriteLine("signatureCipher: " + signatureCipher);
			Console.WriteLine("signature: " + signature);
            Console.WriteLine("signature method: " + signatureMethod);
			return signature;
	    }

        private static String getBaseSignatureCipher(String httpMethod, String url, String timestamp, String nonce, String clientId, String clientSecretKey)
        {
            url = url.Replace("http://", "https://");
            url = Uri.EscapeDataString(url);
            url = url.Replace("%20", "+");
            String baseStringToBeSigned = httpMethod + "&" + url + "&" + timestamp + "&" + nonce + "&" + clientId + "&" + clientSecretKey;
            return baseStringToBeSigned;
        }

        public static String generateNonce()
        {
            Random random = new Random();
            return Convert.ToString(random.Next(000000000, 999999999).ToString());
        }


        private static byte[] getHash(String signatureCipher, String signatureMethod)
        {
            if("SHA1".Equals(signatureMethod))
            {
                SHA1 digest = SHA1.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(signatureCipher);
                byte[] hash = digest.ComputeHash(inputBytes);
                return hash;
            }

            if ("SHA256".Equals(signatureMethod))
            {
                SHA256 digest = SHA256.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(signatureCipher);
                byte[] hash = digest.ComputeHash(inputBytes);
                return hash;
            }

            // Of course, you can add more Digest if you want to support more here.


            // if none of the digest above are available, SHA1 is used as default digest.
            SHA1 defaultDigest = SHA1.Create();
            byte[] defaultInputBytes = System.Text.Encoding.ASCII.GetBytes(signatureCipher);
            byte[] defaultHash = defaultDigest.ComputeHash(defaultInputBytes);
            return defaultHash;
        }

        

    }
}
