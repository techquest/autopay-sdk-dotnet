using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.payment.upload.dto
{
    class UploadPaymentRequest
    {
        public String terminalId { get; set; }
        public String batchName { get; set; }
        public String isBulkRemittance { get; set; }
        public String sourceAccount { get; set; }
        public String isOffline { get; set; }
        public String isConsolidated { get; set; }
        public String mac { get; set; }
        public PaymentRequest []payments { get; set; }
    }
}
