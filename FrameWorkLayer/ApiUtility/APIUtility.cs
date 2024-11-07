using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.ApiUtility
{
    public class APIUtility
    {
        private RestClient restClient;
        private RestRequest restRequest;

        public APIUtility(string url)
        {
            restClient = new RestClient(url);
        }

        public RestRequest GetRestRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }

        public RestResponse<T> Get<T>(string endpoint) where T : new()
        {
            var request = GetRestRequest(endpoint, Method.Get);
            var response = restClient.Execute<T>(request);

            // Check for network errors or non-HTTP exceptions.
            if (response.ErrorException != null)
                throw new ApplicationException("Error in the network request.", response.ErrorException);

            // Check for non-success statuses.
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException($"Expected status code 200 OK, but got {response.StatusCode}. " +
                                               $"Response content: {response.Content}");

            return response; // This includes both the status code and the data.
        }


        public RestResponse<TResponse> PostData<TResponse, TRequest>(string endPoint, TRequest data) where TRequest : class
        {
            var restRequest = new RestRequest(endPoint, Method.Post);
            restRequest.AddJsonBody(data);
            var response = restClient.Execute<TResponse>(restRequest);
            if (response.StatusCode != HttpStatusCode.Created)
                throw new ApplicationException($"Expected status code 201 Created, but got {response.StatusCode}. Response content: {response.Content}");
            return response;
        }

        //PUT
        public RestResponse<T> Put<T>(string endpoint, T body) where T : class
        {
            restRequest = GetRestRequest(endpoint, Method.Put);
            restRequest.AddJsonBody(body);
            var response = restClient.Execute<T>(restRequest);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ApplicationException($"Expected status code 200 OK, but got {response.StatusCode}. Response content: {response.Content}");

            return response;
        }

        public RestResponse Delete(string endpoint)
        {
            var request = GetRestRequest(endpoint, Method.Delete);
            var response = restClient.Execute(request);

            

            return response;
        }
    }

    }

