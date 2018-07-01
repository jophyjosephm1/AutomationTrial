using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace AutomationTrial.Helper
{
    class RestHelper
    {
         
        
        private List<Users> _userList;
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //Accessing the Rest endpoint

        public void SetEndpoint()
        {

            Log.Info("Accessing the REST Api resource..........");
            _client = new RestClient("https://jsonplaceholder.typicode.com");
            _request = new RestRequest("/posts", Method.GET);
            Thread.Sleep(3000);

        }
        
        //Getting the http response status

        public HttpStatusCode GetTheResponse()
        {
            Log.Info("Getting the http response code.....");
            _response = _client.Execute(_request);
            HttpStatusCode statusCode = _response.StatusCode;

            return statusCode;
        }

        //Retreving the Rest data
        public void RetrieiveTheData()
        {

            Log.Info("Retreiving the Rest details in Json format.....");
            _request.RequestFormat = DataFormat.Json;
            _response = _client.Execute(_request);
        }

        //Getting received objects count
        public int ObjCount()
        {
            Log.Info("Deserializersing Json data in to <List> objects and getting the total count.....");
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();

            _userList = deserial.Deserialize<List<Users>>(_response);
            return _userList.Count;                  

        }


    }

    }

