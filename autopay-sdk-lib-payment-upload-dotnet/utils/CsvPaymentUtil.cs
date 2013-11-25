using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.payment.upload.dto;
using FileHelpers;

namespace com.interswitchng.techquest.autopay.sdk.payment.upload.utils
{
    class CsvPaymentUtil
    {

        public static UploadPaymentRequest extractUploadPaymentRequestFromCSVFile(String csvFile)
	    {
            List<CsvUploadPaymentRequest> csvUploadPaymentRequestList = extractCSVUploadPaymentRequestFromCSV(csvFile);
		    UploadPaymentRequest uploadPaymentRequest = new UploadPaymentRequest();
		    if(csvUploadPaymentRequestList == null || csvUploadPaymentRequestList.Count < 1)
			    return null;

            CsvUploadPaymentRequest csvUploadPaymentRequest = csvUploadPaymentRequestList.ElementAt(0);
            uploadPaymentRequest.batchName = csvUploadPaymentRequest.batchName;
            uploadPaymentRequest.isBulkRemittance = csvUploadPaymentRequest.isBulkRemittance;
            uploadPaymentRequest.isConsolidated = csvUploadPaymentRequest.isConsolidated;
            uploadPaymentRequest.isOffline = csvUploadPaymentRequest.isOffline;
            uploadPaymentRequest.mac = csvUploadPaymentRequest.mac;
            uploadPaymentRequest.sourceAccount = csvUploadPaymentRequest.sourceAccount;
            uploadPaymentRequest.terminalId = csvUploadPaymentRequest.terminalId;
            PaymentRequest[] paymentRequestArr = extractPaymentRequestsFromCSVUploadPaymentRequest(csvUploadPaymentRequestList);
            uploadPaymentRequest.payments = paymentRequestArr;

            return uploadPaymentRequest;
        }
        
        public static List<CsvUploadPaymentRequest> extractCSVUploadPaymentRequestFromCSV(String csvFile) 
	    {   
            csvFile = "Resources/" + csvFile;
            FileHelperEngine<CsvUploadPaymentRequest> engine = new FileHelperEngine<CsvUploadPaymentRequest>();
            CsvUploadPaymentRequest[] csvUploadPaymentRequestArr = engine.ReadFile(@csvFile);
            List<CsvUploadPaymentRequest> csvUploadPaymentRequestList = csvUploadPaymentRequestArr.Cast<CsvUploadPaymentRequest>().ToList();
            return csvUploadPaymentRequestList;
	    }


        private static PaymentRequest[] extractPaymentRequestsFromCSVUploadPaymentRequest(List<CsvUploadPaymentRequest> csvUploadPaymentRequestList)
	    {
		    if(csvUploadPaymentRequestList == null || csvUploadPaymentRequestList.Count < 1)
			    return null;
		
		    int index = 0;
		    PaymentRequest []paymentRequestArr = new PaymentRequest[csvUploadPaymentRequestList.Count];
		    foreach(CsvUploadPaymentRequest csvUploadPaymentRequest in csvUploadPaymentRequestList)
		    {
			    PaymentRequest paymentRequest = new PaymentRequest();
                paymentRequest.accountNumber = csvUploadPaymentRequest.accountNumber;
                paymentRequest.accountType = csvUploadPaymentRequest.accountType;
                paymentRequest.amount = csvUploadPaymentRequest.amount;
                paymentRequest.bankCBNCode = csvUploadPaymentRequest.bankCBNCode;
                paymentRequest.beneficiaryCode = csvUploadPaymentRequest.beneficiaryCode;
                paymentRequest.beneficiaryName = csvUploadPaymentRequest.beneficiaryName;
                paymentRequest.currencyCode = csvUploadPaymentRequest.currencyCode;
                paymentRequest.narration = csvUploadPaymentRequest.narration;
                paymentRequest.paymentRef = csvUploadPaymentRequest.paymentRef;
                paymentRequest.paymentType = csvUploadPaymentRequest.paymentType;
			    paymentRequestArr[index++] = paymentRequest;
		    }
		
		    return paymentRequestArr;
	    }

    }
}
