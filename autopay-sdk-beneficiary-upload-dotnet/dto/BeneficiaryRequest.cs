using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload.dto
{
    class BeneficiaryRequest
    {
        public String beneficiaryCode { get; set; }
        public String maxPayableAmount { get; set; }
        public String currencyCode { get; set; }
        public String beneficiaryName { get; set; }
        public String accountNumber { get; set; }
        public String accountType { get; set; }
        public String bankCBNCode { get; set; }
        public String email { get; set; }
        public String mobile { get; set; }
        public String isCashCard { get; set; }
        public String category { get; set; }
    }
}
