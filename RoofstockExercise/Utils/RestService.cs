using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RoofstockExercise.Utils
{
    public class RestService
    {
        public RestClient restClient;
        public RestService(string uriBase)
        {
            restClient = new RestClient(uriBase);
        }

        public JObject Get(string resource)
        {
            IRestRequest request = new RestRequest(resource);
            var response = restClient.Get(request).Content;
            return JObject.Parse(response);
        }
    }
}
