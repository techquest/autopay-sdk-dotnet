using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.http;
using com.interswitchng.techquest.autopay.sdk.payment.upload.utils;
using com.interswitchng.techquest.autopay.sdk.lib.dto;
using com.interswitchng.techquest.autopay.sdk.payment.upload.dto;

namespace com.interswitchng.techquest.autopay.sdk.payment.upload.services
{
    class CsvPaymentUpload : PaymentUpload
    {

        /*
            UploadPaymentRequest uploadPaymentRequest = new UploadPaymentRequest();
            PaymentRequest[] paymentRequests = new PaymentRequest[1];
            PaymentRequest paymentRequest = new PaymentRequest();
            paymentRequest.accountNumber = "000000123";
            paymentRequest.accountType = "Current";
            paymentRequest.amount = "50000";
            paymentRequest.bankCBNCode = "033";
            paymentRequest.beneficiaryCode = "SEUN";
            paymentRequest.beneficiaryName = "Omotayo Seun";
            paymentRequest.currencyCode = "NGN";
            paymentRequest.narration = "Testing Payment Upload";
            paymentRequest.paymentRef = "SEUN-50000";
            paymentRequest.paymentType = "Bulk";
            paymentRequests[0] = paymentRequest;
            uploadPaymentRequest.payments = paymentRequests;
            uploadPaymentRequest.isBulkRemittance = "true";
            uploadPaymentRequest.isConsolidated = "true";
            uploadPaymentRequest.isOffline = "true";
            uploadPaymentRequest.mac = "EAFF872374832BBBCFFDFFEAAABC877676";
            uploadPaymentRequest.sourceAccount = "12222008123";
            uploadPaymentRequest.terminalId = "3IWP0001";
            uploadPaymentRequest.batchName = "BATCH-001";
            */

        public RestResponse uploadPayments(String csvFile)
	    {
            UploadPaymentRequest uploadPaymentRequest = CsvPaymentUtil.extractUploadPaymentRequestFromCSVFile(csvFile);
            RestResponse restResponse = uploadPayments(uploadPaymentRequest);
            return restResponse;
        }



    }
}
