using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload.dto
{
    [IgnoreFirst] //Remove this line if your CSV does not have the first row as the field/column description
    [IgnoreEmptyLines]
    [DelimitedRecord(",")] 
    class CsvUploadBeneficiaryRequest
    {
        public String terminalId;
        public String batchName;
        public String isBulkRemittance;
        public String sourceAccount;
        public String isOffline;
        public String isConsolidated;
        public String mac;
        public String beneficiaryCode;
        public String beneficiaryName;
        public String accountNumber;
        public String accountType;
        public String bankCBNCode;
        public String maxPayableAmount;
        public String email;
        public String mobile;
        public String isCashCard;
        public String currencyCode;
        public String category;
    }
}
