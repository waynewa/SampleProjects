using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;


namespace Customers.Framework.Core.Services
{
    public static class APIServices
    {
        public const string ApiURI = "";
        public static IList<Info> GetAPIFunctions()

        {
            var client = new RestClient(ApiURI);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("info endpoints failed with " + response.StatusCode);
            }

            return JsonConvert.DeserializeObject<IList<Info>>(response.Content);
        }
    }
}
