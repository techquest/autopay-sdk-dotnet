using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.payment.upload.dto
{
    class PaymentRequest
    {
        public String paymentRef { get; set; }
        public String paymentType { get; set; }
        public String beneficiaryCode { get; set; }
        public String narration { get; set; }
        public String amount { get; set; }
        public String currencyCode { get; set; }
        public String beneficiaryName { get; set; }
        public String accountNumber { get; set; }
        public String accountType { get; set; }
        public String bankCBNCode { get; set; }
    }
}
