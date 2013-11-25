using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.lib.utils
{
    public class ConstantUtils
    {
        public static String SIGNATURE_HEADER = "Signature";
	    public static String SIGNATURE_METHOD_HEADER = "SignatureMethod";
	    public static String TIMESTAMP_HEADER = "Timestamp";
	    public static String NONCE_HEADER = "Nonce";
	    public static String CONTENT_TYPE_HEADER = "Content-Type";
	    public static String AUTHORIZATION_HEADER = "Authorization";
	    public static String INTERSWITCH_AUTHORIZATION = "InterswitchAuth";
	    public static String DEFAULT_SIGNATURE_METHOD = "SHA1";
	    public static String HTTP_POST = "POST";
	    public static String HTTP_GET = "GET";
	    public static String CONTENT_TYPE_APPLICATION_JSON = "application/json";

        public static String RESOURCE_SERVER_PATH = "https://stagenet.interswitchng.com/api/v1/autopay";
    }
}
