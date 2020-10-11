using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;


namespace SeleniumBase.Framework.Core.Services
{  
     /// <summary>
     /// This services Class requires some refactoring as it is only
     /// exsample indications at the moment
     /// </summary>
    public static class APIServices
    {
        public const string ApiURI = "";
        public static IList<Info> GetAPIFunctions()
        {
            Log.Info("Api Services");
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
