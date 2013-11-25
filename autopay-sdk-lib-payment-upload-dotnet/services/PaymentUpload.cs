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
    abstract class PaymentUpload
    {
        // Get Client ID from Interswitch developer console. 
        public static String CLIENT_ID;
        // Get Client Secret Key from Interswitch developer console.
        public static String CLIENT_SECRET_KEY;

        protected RestResponse uploadPayments(UploadPaymentRequest uploadPaymentRequest)
        {
            AutoPAYHttpClient<UploadPaymentRequest> autoPAYHttpClient = new AutoPAYHttpClient<UploadPaymentRequest>();
            IDictionary<String, String> headers = getPaymentHeaders(ConstantUtils.PAYMENT_UPLOAD_RESOURCE_PATH, uploadPaymentRequest);
            RestResponse restResponse = autoPAYHttpClient.post(ConstantUtils.PAYMENT_UPLOAD_RESOURCE_PATH, uploadPaymentRequest, headers);
            return restResponse;
        }

        private IDictionary<String, String> getPaymentHeaders(String url, UploadPaymentRequest uploadPaymentRequest)
        {
            PaymentUploadSecurityUtils securityUtils = new PaymentUploadSecurityUtils();
            String transactionParameters = securityUtils.getPaymentUploadTransactionParameters(uploadPaymentRequest);
            IDictionary<String, String> headers = securityUtils.getSecurityHeaders(CLIENT_ID, CLIENT_SECRET_KEY, com.interswitchng.techquest.autopay.sdk.lib.utils.ConstantUtils.HTTP_POST, url, transactionParameters);
            return headers;
        }
    }
}
