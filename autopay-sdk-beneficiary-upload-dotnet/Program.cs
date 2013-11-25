using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.dto;
using com.interswitchng.techquest.autopay.sdk.beneficiary.upload.services;

namespace com.interswitchng.techquest.autopay.sdk.beneficiary.upload
{
    class Program
    {
        static void Main(string[] args)
        {
            String csvFile = "beneficiary.csv";
            CsvBeneficiaryUpload.CLIENT_ID = "IKIAEC529AFD17F2933B45A79FFDF488B68E07C67ADA";
            CsvBeneficiaryUpload.CLIENT_SECRET_KEY = "NjPmuXURqZONFkYTWvXzv4TV9wwzAnWZykznYQ==";
            CsvBeneficiaryUpload csvUploadPayment = new CsvBeneficiaryUpload();
            RestResponse restResponse = csvUploadPayment.uploadBeneficiarys(csvFile);

            bool isSuccess = restResponse.successful;
            if (isSuccess)
            {
                Console.WriteLine("Payment Upload is successful");
            }
            else
            {
                Errors errors = (Errors)restResponse;
                Error error = errors.errors[0];
                Console.WriteLine("Payment Upload is not successful");
                Console.WriteLine("Error code: " + error.code);
                Console.WriteLine("Payment Upload is not successful: " + error.message);
            }
        }
    }
}
