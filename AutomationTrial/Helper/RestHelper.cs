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

      public void SetEndpoint()
        {
            _client = new RestClient("https://jsonplaceholder.typicode.com");
            _request = new RestRequest("/posts", Method.GET);
            Thread.Sleep(3000);

        }
        
        //Accessing the Rest end point

        public HttpStatusCode GetTheResponse()
        {
            
             _response = _client.Execute(_request);
            HttpStatusCode statusCode = _response.StatusCode;

            return statusCode;
        }

        public void RetrieiveTheData()
        {
            _request.RequestFormat = DataFormat.Json;
            _response = _client.Execute(_request);
        }


        public int ObjCount()
        {
                       
            RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();

            _userList = deserial.Deserialize<List<Users>>(_response);

            return _userList.Count;                  

        }


    }

    }

