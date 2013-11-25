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
    class CsvBeneficiaryUpload : BeneficiaryUpload
    {

        public RestResponse uploadBeneficiarys(String csvFile)
	    {
            UploadBeneficiaryRequest uploadBeneficiaryRequest = CsvBeneficiaryUtil.extractUploadBeneficiaryRequestFromCSVFile(csvFile);
            RestResponse restResponse = uploadBeneficiarys(uploadBeneficiaryRequest);
            return restResponse;
        }



    }
}
