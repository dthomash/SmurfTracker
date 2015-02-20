using System;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LolBackdoor.Riot
{
    public class RiotResponse
    {
        public JObject Response { get { return _responseObject; } }
        private readonly JObject _responseObject;
        public RiotResponse(RiotRequest request)
        {
            Exception innerException = null;
            string message = "An error has occurred processing the request.";
            string responseString = null;
            bool responseRead = false;
            bool success = false;
            using (var response = request.GetWebRequest().GetResponse())
            {
                var tryCount = 0;
                var retry = true;
                while (tryCount < 5 && retry && !success)
                {
                    try
                    {
                        if (!response.ContentType.ToString().Contains("application/json"))
                        {
                            throw new RiotException("The response from the Riot API was not of the Content-Type json.",
                                request.ApiConfig);
                        }
                        if (!responseRead)
                        {
                            responseString = GetResponseBody(response);
                            responseRead = true;
                        }
                        
                        _responseObject = GetJObjectFromResponseString(responseString);
                        success = true;
                    }
                    catch (WebException we)
                    {
                        retry = false;
                        var errorResponse = we.Response as HttpWebResponse;
                        switch (errorResponse.StatusCode)
                        {
                            case HttpStatusCode.BadRequest:
                                message =
                                    "This error indicates that there is a syntax error in the request and the request has therefore been denied. The client should not continue to make similar requests without modifying the syntax or the requests being made.\n\nCommon Reasons\n - A provided parameter is in the wrong format (e.g., a string instead of an integer)\n - A required parameter was not provided";
                                break;
                            case HttpStatusCode.Unauthorized:
                                message =
                                    "This error indicates that the API request being made did not contain the necessary authentication credentials and therefore the client was denied access. If authentication credentials were already included then the Unauthorized response indicates that authorization has been refused for those credentials. In the case of the API, authorization credentials refer to your API key.\n\nCommon Reasons\n - No API key was provided with the API request\n - An invalid API key was provided with the API request\n - The API request was for an incorrect or unsupported path";
                                break;
                            case HttpStatusCode.NotFound:
                                message =
                                    "This error indicates that the server has not found a match for the API request being made. No indication is given whether the condition is temporary or permanent.\n\nCommon Reasons\n - The ID or name provided does not match any existing resource (e.g., there is no summoner matching the specified ID)\n - The API request was for an incorrect or unsupported path";
                                break;
                            case HttpStatusCode.InternalServerError:
                                message =
                                    "This error indicates an unexpected condition or exception which prevented the server from fulfilling an API request.";
                                break;
                            case HttpStatusCode.ServiceUnavailable:
                                message =
                                    "This error indicates the server is currently unavailable to handle requests because of an unknown reason. The Service Unavailable response implies a temporary condition which will be alleviated after some delay.";
                                break;
                            default:
                                if (errorResponse.StatusDescription == "Rate Limit Exceeded")
                                {
                                    message =
                                        "This error indicates that the application has exhausted its maximum number of allotted API calls allowed for a given duration. If the client receives a Rate Limit Exceeded response the client should process this response and halt future API calls for the duration, in seconds, indicated by the Retry-After header. Due to the increased frequency of clients ignoring this response, applications that are in violation of this policy may be disabled to preserve the integrity of the API.\n\nCommon Reasons\n - Unregulated API calls. Check your API Call Graphs to monitor your Dev and Production API key activity.";
                                }
                                break;
                        }
                        innerException = we;
                    }
                    catch (JsonReaderException jre)
                    {
                        tryCount++;
                        message = "Invalid JSON returned from Riot.";
                        innerException = jre;
                    }
                }
            }

            if (!success)
            {
                throw new RiotException("Exceeded max retry attempts: " + message, request.ApiConfig, innerException);
            }
        }

        private string GetResponseBody(WebResponse response)
        {
            byte[] responseContentByteArray = new byte[100];
            var bodySb = new StringBuilder();
            var reponseContentStream = response.GetResponseStream();

            int bytesRead = reponseContentStream.Read(responseContentByteArray, 0, responseContentByteArray.Length);

            while (bytesRead > 0)
            {
                char[] responseContentCharArray = new char[bytesRead];
                for (int j = 0; j < bytesRead; j++)
                {
                    responseContentCharArray[j] = (char)responseContentByteArray[j];
                }
                var responseContentString = new string(responseContentCharArray);
                bodySb.Append(responseContentString);

                bytesRead = reponseContentStream.Read(responseContentByteArray, 0, responseContentByteArray.Length);
            }
            var body = bodySb.ToString();

            System.Diagnostics.Debug.Write(body + "\r\n");

            return body;
        }

        private JObject GetJObjectFromResponseString(string response)
        {
            return JObject.Parse(response);
        }
    }
}
