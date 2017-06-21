using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string message = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "message", true) == 0)
        .Value;

    string http_code = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "http_code", true) == 0)
        .Value;

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    message = message ?? data?.message;

    //if ((http_code == null) || (http_code == HttpStatusCode.OK))
    //if ((String.Compare (http_code, "200", true)  == 0))

    //if (message.CompareTo("200") == 0)
    //{
        return message == null
            ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a message on the query string or in the request body")
            : req.CreateResponse(HttpStatusCode.OK, "[" + DateTime.Now + "]: " + message);
    //} 
    //else
    //{
    //    return message == null
    //        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a message on the query string or in the request body")
    //        : req.CreateResponse(HttpStatusCode.OK, "[" + DateTime.Now + "]: " + message);
    //} 

}
