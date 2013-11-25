using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.http;
using com.interswitchng.techquest.autopay.sdk.beneficiary.upload.utils;
using com.interswitchng.techquest.autopay.sdk.lib.dto;
using com.interswitchng.techquest.autopay.sdk.beneficiary.upload.dto;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload.services
{
    abstract class BeneficiaryUpload
    {
        // Get Client ID from Interswitch developer console. 
        public static String CLIENT_ID;
        // Get Client Secret Key from Interswitch developer console.
        public static String CLIENT_SECRET_KEY;

        protected RestResponse uploadBeneficiarys(UploadBeneficiaryRequest uploadBeneficiaryRequest)
        {
            AutoPAYHttpClient<UploadBeneficiaryRequest> autoPAYHttpClient = new AutoPAYHttpClient<UploadBeneficiaryRequest>();
            IDictionary<String, String> headers = getBeneficiaryHeaders(ConstantUtils.BENEFICIARY_UPLOAD_RESOURCE_PATH, uploadBeneficiaryRequest);
            RestResponse restResponse = autoPAYHttpClient.post(ConstantUtils.BENEFICIARY_UPLOAD_RESOURCE_PATH, uploadBeneficiaryRequest, headers);
            return restResponse;
        }

        private IDictionary<String, String> getBeneficiaryHeaders(String url, UploadBeneficiaryRequest uploadBeneficiaryRequest)
        {
            BeneficiaryUploadSecurityUtils securityUtils = new BeneficiaryUploadSecurityUtils();
            String transactionParameters = securityUtils.getBeneficiaryUploadTransactionParameters(uploadBeneficiaryRequest);
            IDictionary<String, String> headers = securityUtils.getSecurityHeaders(CLIENT_ID, CLIENT_SECRET_KEY, com.interswitchng.techquest.autopay.sdk.lib.utils.ConstantUtils.HTTP_POST, url, transactionParameters);
            return headers;
        }
    }
}
