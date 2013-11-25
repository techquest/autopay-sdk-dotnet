using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.utils;
using com.interswitchng.techquest.autopay.sdk.beneficiary.upload.dto;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload.utils
{
    class BeneficiaryUploadSecurityUtils : SecurityUtils
    {
        public String getBeneficiaryUploadTransactionParameters(UploadBeneficiaryRequest uploadBeneficiaryRequest)
        {
            String beneficiaryRequestTransactionParameters = "";
            List<String> parameterList = getTransactionParametersList(uploadBeneficiaryRequest);

            foreach(String str in parameterList)
			    if(!SecurityUtils.isNullorEmpty(str)) 
				    beneficiaryRequestTransactionParameters += "&" + str;

            return beneficiaryRequestTransactionParameters;
        }


         private List<String> getTransactionParametersList(UploadBeneficiaryRequest uploadBeneficiaryRequest)
	     {
		     BeneficiaryRequest []beneficiaryRequestArr = uploadBeneficiaryRequest.beneficiarys;
		     List<String> parameterList = new List<String>();
		 
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadBeneficiaryRequest.terminalId) ? "" : uploadBeneficiaryRequest.terminalId);
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadBeneficiaryRequest.batchName) ? "" : uploadBeneficiaryRequest.batchName);
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadBeneficiaryRequest.sourceAccount) ? "" : uploadBeneficiaryRequest.sourceAccount);
		     parameterList.Add(getAccountNumbersTransactionParameter(beneficiaryRequestArr));
		     parameterList.Add(getBeneficiaryNamesTransactionParameter(beneficiaryRequestArr));
		     parameterList.Add(getBeneficiaryCodesTransactionParameter(beneficiaryRequestArr));
		     parameterList.Add(getMaxPayableAmountsTransactionParameter(beneficiaryRequestArr));		 
		     return parameterList;
	     }

        private String getAccountNumbersTransactionParameter(BeneficiaryRequest[] beneficiaryRequestArr)
	    {
		     String node = "";
		     foreach(BeneficiaryRequest beneficiaryRequest in beneficiaryRequestArr)
			     node += SecurityUtils.isNullorEmpty(beneficiaryRequest.accountNumber) ? "" : beneficiaryRequest.accountNumber;
		     return node;
	    }


        private String getBeneficiaryNamesTransactionParameter(BeneficiaryRequest[] beneficiaryRequestArr)
	     {
		     String node = "";
		     foreach(BeneficiaryRequest beneficiaryRequest in beneficiaryRequestArr)
                 node += SecurityUtils.isNullorEmpty(beneficiaryRequest.beneficiaryName) ? "" : beneficiaryRequest.beneficiaryName;
		     return node;
	     }

         private String getBeneficiaryCodesTransactionParameter(BeneficiaryRequest[] beneficiaryRequestArr)
	     {
		     String node = "";
		     foreach(BeneficiaryRequest beneficiaryRequest in beneficiaryRequestArr)
                 node += SecurityUtils.isNullorEmpty(beneficiaryRequest.beneficiaryCode) ? "" : beneficiaryRequest.beneficiaryCode;
		     return node;
	     }

         private String getMaxPayableAmountsTransactionParameter(BeneficiaryRequest[] beneficiaryRequestArr)
	     {
		     String node = "";
		     foreach(BeneficiaryRequest beneficiaryRequest in beneficiaryRequestArr)
                 node += SecurityUtils.isNullorEmpty(beneficiaryRequest.maxPayableAmount) ? "" : beneficiaryRequest.maxPayableAmount;
		     return node;
	     }


    }
}
