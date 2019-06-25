using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI.HTTPHelperMethpds
{
    public class HTTPHelpers
    {
        public static T GetListMethod<T>(string host, string resource, Method HttpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, HttpMethod);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public static void PostMethod(string host, string resource, Method Httpmethod, object obj)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddJsonBody(obj);
            client.Execute(request);
        }
        

        public static T GetMethod<T>(string host, string resource, Method HttpMethod, object id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, HttpMethod);
            request.AddParameter("id", id);
            var response = client.Execute<T>(request);
            return response.Data;
        }
        public static T LoginMethod<T>(string host, string resource, Method Httpmethod, object obj)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddJsonBody(obj);
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public static void DeleteMethod(string host, string resource, Method Httpmethod, object id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("id", id);
            client.Execute(request);
        }
    }
}