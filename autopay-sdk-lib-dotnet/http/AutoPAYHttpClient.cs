using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.interswitchng.techquest.autopay.sdk.lib.dto;
using Spring.Rest;
using Spring.Rest.Client;
using Spring.Http;
using Spring.Http.Converters.Json;
using Spring.Http.Converters;
using Spring.IO;
using System.Net;
using com.interswitchng.techquest.autopay.sdk.lib.utils;
using Newtonsoft.Json;

namespace com.interswitchng.techquest.autopay.sdk.lib.http
{
    public class AutoPAYHttpClient<Req>
    {

        public RestResponse post(String url, Req request, IDictionary<String, String> headers)
        {            
            try
            {
                RestTemplate restTemplate = new RestTemplate();
                //restTemplate.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
                restTemplate.MessageConverters.Add(new SpringJsonHttpMessageConverter());
                restTemplate.MessageConverters.Add(new StringHttpMessageConverter());
                HttpHeaders requestHttpHeaders = copyHttpHeaders(headers);

                String requestData = JsonConvert.SerializeObject(request);
                HttpEntity entity = new HttpEntity(requestData, requestHttpHeaders);
                HttpResponseMessage<String> httpResponseMessage = restTemplate.Exchange<String>(url, HttpMethod.POST, entity);
                String restResponseBody = httpResponseMessage.Body;
                RestResponse restResponse = JsonConvert.DeserializeObject<RestResponse>(restResponseBody);

                if (restResponse != null)
                    restResponse = new RestResponse();

                HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                bool isSuccess = isSuccessful(statusCode);
                if (isSuccess)
                {
                    HttpHeaders responseHttpHeaders = httpResponseMessage.Headers;
                    restResponse.signature = responseHttpHeaders.Get(ConstantUtils.SIGNATURE_HEADER);
                    restResponse.signatureMethod = responseHttpHeaders.Get(ConstantUtils.SIGNATURE_METHOD_HEADER);
                    restResponse.nonce = responseHttpHeaders.Get(ConstantUtils.NONCE_HEADER);
                    restResponse.timestamp = responseHttpHeaders.Get(ConstantUtils.TIMESTAMP_HEADER);
                }
                restResponse.successful = isSuccess;
                return restResponse;
            }
            catch (HttpClientErrorException hceex)
            {
                Errors errors = new Errors();   
                String error = hceex.GetResponseBodyAsString();
                errors = JsonConvert.DeserializeObject<Errors>(error);
                return errors;
            }
            catch (HttpServerErrorException hseex)
            {
                Errors errors = new Errors();   
                String error = hseex.GetResponseBodyAsString();
                errors = JsonConvert.DeserializeObject<Errors>(error);
                return errors;
            }
            catch (Exception ex)
            {
                String exception = ex.StackTrace;
                Errors errors = new Errors();
                return errors;
            }            
        }


        private HttpHeaders copyHttpHeaders(IDictionary<String, String> headers)
        {
            HttpHeaders requestHttpHeaders = new HttpHeaders();
            foreach (KeyValuePair<String, String> entry in headers)
                requestHttpHeaders.Add(entry.Key, entry.Value);
            return requestHttpHeaders;
        }


        private bool isSuccessful(HttpStatusCode statusCode)
        {
            return (HttpStatusCode.Accepted == statusCode || HttpStatusCode.Created == statusCode
                || HttpStatusCode.NoContent == statusCode || HttpStatusCode.NonAuthoritativeInformation == statusCode
                || HttpStatusCode.OK == statusCode || HttpStatusCode.PartialContent == statusCode
                || HttpStatusCode.ResetContent == statusCode);
        }
    }
}
