using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.lib.dto
{
    public class RestResponse
    {
        public String signature { get; set; }
        public String signatureMethod { get; set; }
        public String timestamp { get; set; }
        public String nonce { get; set; }
        public bool successful { get; set; }
    }
}
