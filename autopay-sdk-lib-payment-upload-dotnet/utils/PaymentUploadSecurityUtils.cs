using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.utils;
using com.interswitchng.techquest.autopay.sdk.payment.upload.dto;

namespace com.interswitchng.techquest.autopay.sdk.payment.upload.utils
{
    class PaymentUploadSecurityUtils : SecurityUtils
    {
        public String getPaymentUploadTransactionParameters(UploadPaymentRequest uploadPaymentRequest)
        {
            String paymentRequestTransactionParameters = "";
            List<String> parameterList = getTransactionParametersList(uploadPaymentRequest);

            foreach(String str in parameterList)
			    if(!SecurityUtils.isNullorEmpty(str)) 
				    paymentRequestTransactionParameters += "&" + str;

            return paymentRequestTransactionParameters;
        }


         private List<String> getTransactionParametersList(UploadPaymentRequest uploadPaymentRequest)
	     {
		     PaymentRequest []paymentRequestArr = uploadPaymentRequest.payments;
		     List<String> parameterList = new List<String>();
		 
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadPaymentRequest.terminalId) ? "" : uploadPaymentRequest.terminalId);
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadPaymentRequest.batchName) ? "" : uploadPaymentRequest.batchName);
		     parameterList.Add(SecurityUtils.isNullorEmpty(uploadPaymentRequest.sourceAccount) ? "" : uploadPaymentRequest.sourceAccount);
		     parameterList.Add(getAccountNumbersTransactionParameter(paymentRequestArr));
		     parameterList.Add(getPaymentRefsTransactionParameter(paymentRequestArr));
		     parameterList.Add(getBeneficiaryNamesTransactionParameter(paymentRequestArr));
		     parameterList.Add(getBeneficiaryCodesTransactionParameter(paymentRequestArr));
		     parameterList.Add(getAmountsTransactionParameter(paymentRequestArr));		 
		     return parameterList;
	     }

        private String getAccountNumbersTransactionParameter(PaymentRequest[] paymentRequestArr)
	    {
		     String node = "";
		     foreach(PaymentRequest paymentRequest in paymentRequestArr)
			     node += SecurityUtils.isNullorEmpty(paymentRequest.accountNumber) ? "" : paymentRequest.accountNumber;
		     return node;
	    }


        private String getPaymentRefsTransactionParameter(PaymentRequest[] paymentRequestArr)
	     {
		     String node = "";
		     foreach(PaymentRequest paymentRequest in paymentRequestArr)
                 node += SecurityUtils.isNullorEmpty(paymentRequest.paymentRef) ? "" : paymentRequest.paymentRef;
		     return node;
	     }


        private String getBeneficiaryNamesTransactionParameter(PaymentRequest[] paymentRequestArr)
	     {
		     String node = "";
		     foreach(PaymentRequest paymentRequest in paymentRequestArr)
                 node += SecurityUtils.isNullorEmpty(paymentRequest.beneficiaryName) ? "" : paymentRequest.beneficiaryName;
		     return node;
	     }

         private String getBeneficiaryCodesTransactionParameter(PaymentRequest[] paymentRequestArr)
	     {
		     String node = "";
		     foreach(PaymentRequest paymentRequest in paymentRequestArr)
                 node += SecurityUtils.isNullorEmpty(paymentRequest.beneficiaryCode) ? "" : paymentRequest.beneficiaryCode;
		     return node;
	     }

        private String getAmountsTransactionParameter(PaymentRequest[] paymentRequestArr)
	     {
		     String node = "";
		     foreach(PaymentRequest paymentRequest in paymentRequestArr)
                 node += SecurityUtils.isNullorEmpty(paymentRequest.amount) ? "" : paymentRequest.amount;
		     return node;
	     }


    }
}
