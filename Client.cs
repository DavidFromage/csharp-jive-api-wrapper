using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CheezeIT.JiveAPI.Wrapper
{

    public class Client
    {
        private ILogger _logger;
        public string APIBaseURI { get; set; }
        public string AuthenticationURI { get; set; }
        public string OauthId { get; set; }
        public string OauthSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthentified { get; private set; }
        private string _accessToken = null;



        /// <summary>
        /// Inits a wrapper to connect to Jive API
        /// </summary>
        public Client()
        {
            IsAuthentified = false;
            // Enforcing TLS 1.2 protocol
            ServicePointManager.MaxServicePointIdleTime = 100000;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // DEBUG ONLY : avoiding certificate check
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            }
        }

        /// <summary>
        /// Setting logger
        /// </summary>
        /// <param name="logger"></param>
        public void setLogger(ILogger logger) {
            _logger = logger;
        }

        /// <summary>
        /// Authentication against Jive API
        /// Requires admin credentials in order to do impersonation
        /// </summary>
        public bool Authentify()
        {
            try
            {
                string resultfinal = "no result";
                string resultrequest = "";
                HttpClient client = new HttpClient();
                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting authentication"));

                var authHeader = new AuthenticationHeaderValue("basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(OauthId + ":" + OauthSecret)));
                client.DefaultRequestHeaders.Authorization = authHeader;

                // Create the HttpContent for the form to be posted.
                var requestContent = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", Username),
                    new KeyValuePair<string, string>("password", Password)
                    });

                // FOR TESTING PURPOSE ONLY : overriding certificate validation
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                // Get the response.
                var task = System.Threading.Tasks.Task.Run(async () => await client.PostAsync(AuthenticationURI, requestContent));
                task.Wait();
                HttpResponseMessage response = task.Result;

                // Get the response content.
                HttpContent responseContent = response.Content;

                // Get the stream of the content.
                var taskResult = System.Threading.Tasks.Task.Run(async () => await responseContent.ReadAsStreamAsync());
                taskResult.Wait();
                using (var reader = new StreamReader(taskResult.Result))
                {
                    // Write the output.
                    var taskResult2 = System.Threading.Tasks.Task.Run(async () => await reader.ReadToEndAsync());
                    taskResult2.Wait();
                    resultrequest = taskResult2.Result;
                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Authentication result : " + taskResult2.ToString()));
                }

                dynamic stuff = JsonConvert.DeserializeObject(resultrequest);
                resultfinal = null;
                if (stuff.error != null)
                {
                    _logger.Log(new LogEntry(LoggingEventType.Error, "Authentication error : " + stuff.error_description));
                    throw new UnauthorizedAccessException("Error during authentication against API : "+ stuff.error_description);
                }
                else if (stuff.access_token == null)
                {
                    _logger.Log(new LogEntry(LoggingEventType.Error, "Authentication error : " + stuff.error_description));
                    throw new UnauthorizedAccessException("Error during authentication against API. Acces token is null. " + stuff.error_description);
                }
                else
                {
                    resultfinal = stuff.access_token;
                    this.IsAuthentified = true;
                    _accessToken = resultfinal;
                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Authentication result : " + resultfinal));
                    return true;
                }
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error during authentication. ", e));
                throw e;
            }
    
        }


        /// <summary>
        /// Requests the Jive API and returns the content 
        /// </summary>
        /// <param name="contentId">ID of content to get</param>
        /// <param name="endpoint">endpoint of the content</param>
        /// <returns></returns>
      /*  public APIResult PostItem<ContentType>(string endpoint, string runAsLogin, string contentId = null, List<HttpContent> requestContents = null )
        {
            String responseStr = "";
            try
            {
                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                string urlJivePost = EndPoints.ContentById;
                // passing content ID if needed
                if (contentId != null)
                {
                    contentId = String.Format(endpoint, contentId);
                }
                string URI = _APIBaseURI + endpoint;
                
                // init requestBody
                MultipartFormDataContent requestBody = null; 

                using (HttpClient client = new HttpClient())
                {
                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    if (runAsLogin != null)
                    {
                        client.DefaultRequestHeaders.Add("X-Jive-Run-As", "username " + runAsLogin);
                    }
                    // adding contents
                    if (requestContents != null) {       
                        requestBody = new MultipartFormDataContent();
                        foreach (HttpContent requestContent in requestContents) {
                            requestBody.Add(requestContent, "");
                        }
                    }

                    // adding json-accept header
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // defining request
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, URI );
                    if (requestBody != null) {
                        requestMessage.Content = requestBody;
                    }
                    
                    // sending request
                    var task = System.Threading.Tasks.Task.Run(async () => await client.SendAsync(requestMessage));
                    task.Wait();
                    var result = task.Result;
                    var task2 = System.Threading.Tasks.Task.Run(async () => await result.Content.ReadAsStreamAsync());
                    task2.Wait();
                    var result2 = task2.Result;
                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Response of request : " + result2));

                    responseStr = responseStr.Replace("throw 'allowIllegalResourceCall is false.';", "");
                }

            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
            _logger.Log(new LogEntry(LoggingEventType.Debug, "Response "));
            return new APIResult();
        }*/

        /// <summary>
        /// Requests the Jive API and returns the content 
        /// </summary>
        /// <param name="contentId">ID of content to get</param>
        /// <param name="endpoint">endpoint of the content</param>
        /// <returns></returns>
        public ContentType GetItem<ContentType>(string endpoint)
        {
            String responseStr = "";
            ContentType returnedItem;
            try
            {
                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                // If endpoint doesn't contains base URI, prefixing with base
                if (!endpoint.StartsWith(APIBaseURI))
                {
                    endpoint = APIBaseURI + endpoint;
                }

                using (HttpClient client = new HttpClient())
                {
                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    responseStr = GetJsonStream(client, endpoint).Result;

                    // workaround : remove first line as it's not JSON
                    responseStr = responseStr.Replace("throw 'allowIllegalResourceCall is false.';", "");
                }
                returnedItem = JsonConvert.DeserializeObject<ContentType>(responseStr);
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
            _logger.Log(new LogEntry(LoggingEventType.Debug, "Response " + responseStr));
            return returnedItem;
        }

        /// <summary>
        /// Requests the Jive API and returns the content 
        /// </summary>
        /// <param name="contentId">ID of content to get</param>
        /// <param name="endpoint">endpoint of the content</param>
        /// <returns></returns>
        public APIResult PostItem<JiveItem>(string endpoint, JiveItem jiveItem, string runAsUserLogin = null)
        {
            try
            {
                if (!IsAuthentified) {
                    throw new UnauthorizedAccessException("Please first authenticate with Authentify() method.");
                }

                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                string URI = APIBaseURI + endpoint;

                // serialize jive item
                String jsonStr = JsonConvert.SerializeObject(
                    jiveItem,
                    Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                    );
               
                using (HttpClient client = new HttpClient())
                {

                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    if (runAsUserLogin != null)
                    {
                        client.DefaultRequestHeaders.Add("X-Jive-Run-As", "username " + runAsUserLogin);
                    }

                    // Init de la requête          
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, URI);
                    request.Content = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");

                    // Envoi de la requête
                    var task = System.Threading.Tasks.Task.Run(async () => await client.SendAsync(request));
                    task.Wait();
                    var result = task.Result;
                   
                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Response : "+ result.ToString()));
                    string location = "";
                    if (result.Headers.Location != null)
                    {
                        location = result.Headers.Location.ToString();
                    }
                    return new APIResult(location, (int)result.StatusCode);
                }
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
        }

        /// <summary>
        /// Push an item to the Jive API using PUT method 
        /// </summary>
        /// <param name="contentId">ID of content to get</param>
        /// <param name="endpoint">endpoint of the content</param>
        /// <returns></returns>
        public APIResult PutItemWithBinaryFile<JiveItem>(string endpoint, JiveItem jiveItem, byte[] FileData, string runAsUserLogin = null)
        {
            try
            {
                if (!IsAuthentified)
                {
                    throw new UnauthorizedAccessException("Please first authenticate with Authentify() method.");
                }

                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                string URI = APIBaseURI + endpoint;

                // serialize jive item
                String jsonStr = JsonConvert.SerializeObject(
                    jiveItem,
                    Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                    );

                using (HttpClient client = new HttpClient())
                {

                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    if (runAsUserLogin != null)
                    {
                        client.DefaultRequestHeaders.Add("X-Jive-Run-As", "username " + runAsUserLogin);
                    }
                    
                    // Init de la requête          
                    var requestContent = new MultipartFormDataContent();
                    var staticJsonContent = new StringContent(jsonStr, System.Text.Encoding.UTF8, "application/json");
                    var staticFileContent = new ByteArrayContent(FileData);
                    requestContent.Add(staticJsonContent, "json");
                    requestContent.Add(staticFileContent, "file");

                    // debug form 
                    String toto = requestContent.ReadAsStringAsync().Result;

                    // Envoi de la requête
                    var task = System.Threading.Tasks.Task.Run(async () => await client.PutAsync(URI, requestContent));
                    task.Wait();
                    var result = task.Result;

                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Response : " + result.ToString()));
                    string location = "";
                    if (result.Headers.Location != null)
                    {
                        location = result.Headers.Location.ToString();
                    }
                    return new APIResult(location, (int)result.StatusCode);
                }
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
        }

        /// <summary>
        /// POsting sp
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="parametersList"></param>
        /// <param name="runAsUserLogin"></param>
        /// <returns></returns>
        public APIResult PostFormToEndPoint(string endpoint, List<KeyValuePair<string, string>> parametersList, string runAsUserLogin = null)
        {
            try
            {
                if (!IsAuthentified)
                {
                    throw new UnauthorizedAccessException("Please first authenticate with Authentify() method.");
                }

                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                string URI = APIBaseURI + endpoint;

                using (HttpClient client = new HttpClient())
                {

                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    if (runAsUserLogin != null)
                    {
                        client.DefaultRequestHeaders.Add("X-Jive-Run-As", "username " + runAsUserLogin);
                    }

                    // Init request          
                    var req = new HttpRequestMessage(HttpMethod.Post, URI) { Content = new FormUrlEncodedContent(parametersList) };

                    // Sending request
                    var task = System.Threading.Tasks.Task.Run(async () => await client.SendAsync(req));
                    task.Wait();
                    var result = task.Result;

                    _logger.Log(new LogEntry(LoggingEventType.Debug, "Response : " + result.ToString()));
                    string location = "";
                    if (result.Headers.Location != null)
                    {
                        location = result.Headers.Location.ToString();
                    }
                    return new APIResult(location, (int)result.StatusCode);
                }
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
        }

        /// <summary>
        /// Uploads a binary file to a Jive item. Usually an attachment to a blog post
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="data">Binary data to upload</param>
        /// <param name="dataExtension">Extension of the file (eg. png)</param>
        /// <param name="dataMimetype">Mimetype of the file (eg. image/png)</param>
        /// <param name="dataName">Name of the file</param>
        /// <param name="runAsUserLogin">If specfied, the data will be pushed on behalf the user's login</param>
        /// <returns></returns>
        public APIResult UploadToItem(string endpoint, byte[] data, string dataExtension, string dataMimetype, string dataName, string runAsUserLogin = null)
        {

            try
            {
                if (!IsAuthentified)
                {
                    throw new UnauthorizedAccessException("Please first authenticate with Authentify() method.");
                }

                _logger.Log(new LogEntry(LoggingEventType.Debug, "Starting request"));
                string URI = APIBaseURI + endpoint;
                using (HttpClient client = new HttpClient())
                {

                    // adding authorization headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    if (runAsUserLogin != null)
                    {
                        client.DefaultRequestHeaders.Add("X-Jive-Run-As", "username " + runAsUserLogin);
                    }

                    var requestContent = new MultipartFormDataContent();
                    //    here you can specify boundary if you need---
                    var dataByteArray = new ByteArrayContent(data);
                    dataByteArray.Headers.ContentType = MediaTypeHeaderValue.Parse(dataMimetype);

                    requestContent.Add(dataByteArray, dataExtension, dataName);

                    var task = System.Threading.Tasks.Task.Run(async () => await client.PostAsync(URI, requestContent));
                    task.Wait();
                    var result = task.Result;
                    return new APIResult(result.Headers.Location.ToString(), (int)result.StatusCode);
                }
            }
            catch (Exception e)
            {
                _logger.Log(new LogEntry(LoggingEventType.Error, "Error while requesting ", e));
                throw e;
            }
        }


        /// <summary>
        /// Getting JSON stream
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetJsonStream(HttpClient client, string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }



    }
}
