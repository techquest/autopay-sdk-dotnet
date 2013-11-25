using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.beneficiary.upload.dto;
using FileHelpers;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload.utils
{
    class CsvBeneficiaryUtil
    {

        public static UploadBeneficiaryRequest extractUploadBeneficiaryRequestFromCSVFile(String csvFile)
	    {
            List<CsvUploadBeneficiaryRequest> csvUploadBeneficiaryRequestList = extractCSVUploadBeneficiaryRequestFromCSV(csvFile);
		    UploadBeneficiaryRequest uploadBeneficiaryRequest = new UploadBeneficiaryRequest();
		    if(csvUploadBeneficiaryRequestList == null || csvUploadBeneficiaryRequestList.Count < 1)
			    return null;

            CsvUploadBeneficiaryRequest csvUploadBeneficiaryRequest = csvUploadBeneficiaryRequestList.ElementAt(0);
            uploadBeneficiaryRequest.batchName = csvUploadBeneficiaryRequest.batchName;
            uploadBeneficiaryRequest.isBulkRemittance = csvUploadBeneficiaryRequest.isBulkRemittance;
            uploadBeneficiaryRequest.isConsolidated = csvUploadBeneficiaryRequest.isConsolidated;
            uploadBeneficiaryRequest.isOffline = csvUploadBeneficiaryRequest.isOffline;
            uploadBeneficiaryRequest.mac = csvUploadBeneficiaryRequest.mac;
            uploadBeneficiaryRequest.sourceAccount = csvUploadBeneficiaryRequest.sourceAccount;
            uploadBeneficiaryRequest.terminalId = csvUploadBeneficiaryRequest.terminalId;
            BeneficiaryRequest[] beneficiaryRequestArr = extractBeneficiaryRequestsFromCSVUploadBeneficiaryRequest(csvUploadBeneficiaryRequestList);
            uploadBeneficiaryRequest.beneficiarys = beneficiaryRequestArr;

            return uploadBeneficiaryRequest;
        }
        
        public static List<CsvUploadBeneficiaryRequest> extractCSVUploadBeneficiaryRequestFromCSV(String csvFile) 
	    {   
            csvFile = "Resources/" + csvFile;
            FileHelperEngine<CsvUploadBeneficiaryRequest> engine = new FileHelperEngine<CsvUploadBeneficiaryRequest>();
            CsvUploadBeneficiaryRequest[] csvUploadBeneficiaryRequestArr = engine.ReadFile(@csvFile);
            List<CsvUploadBeneficiaryRequest> csvUploadBeneficiaryRequestList = csvUploadBeneficiaryRequestArr.Cast<CsvUploadBeneficiaryRequest>().ToList();
            return csvUploadBeneficiaryRequestList;
	    }


        private static BeneficiaryRequest[] extractBeneficiaryRequestsFromCSVUploadBeneficiaryRequest(List<CsvUploadBeneficiaryRequest> csvUploadBeneficiaryRequestList)
	    {
		    if(csvUploadBeneficiaryRequestList == null || csvUploadBeneficiaryRequestList.Count < 1)
			    return null;
		
		    int index = 0;
		    BeneficiaryRequest []beneficiaryRequestArr = new BeneficiaryRequest[csvUploadBeneficiaryRequestList.Count];
		    foreach(CsvUploadBeneficiaryRequest csvUploadBeneficiaryRequest in csvUploadBeneficiaryRequestList)
		    {
			    BeneficiaryRequest beneficiaryRequest = new BeneficiaryRequest();
                beneficiaryRequest.accountNumber = csvUploadBeneficiaryRequest.accountNumber;
                beneficiaryRequest.accountType = csvUploadBeneficiaryRequest.accountType;
                beneficiaryRequest.maxPayableAmount = csvUploadBeneficiaryRequest.maxPayableAmount;
                beneficiaryRequest.bankCBNCode = csvUploadBeneficiaryRequest.bankCBNCode;
                beneficiaryRequest.beneficiaryCode = csvUploadBeneficiaryRequest.beneficiaryCode;
                beneficiaryRequest.beneficiaryName = csvUploadBeneficiaryRequest.beneficiaryName;
                beneficiaryRequest.currencyCode = csvUploadBeneficiaryRequest.currencyCode;
                beneficiaryRequest.email = csvUploadBeneficiaryRequest.email;
                beneficiaryRequest.mobile = csvUploadBeneficiaryRequest.mobile;
                beneficiaryRequest.isCashCard = csvUploadBeneficiaryRequest.isCashCard;
                beneficiaryRequest.category = csvUploadBeneficiaryRequest.category;
			    beneficiaryRequestArr[index++] = beneficiaryRequest;
		    }
		
		    return beneficiaryRequestArr;
	    }

    }
}
