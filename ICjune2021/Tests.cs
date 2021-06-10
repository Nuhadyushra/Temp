using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;

namespace ICjune2021
{
    public class Tests
    {

        string Auth = "{\"email\": \"user13@sector36.com\",\"password\": \"user@12365\"}";
        string BaseUrl = "http://api.qaauto.co.nz/api";
        String version = "v1";
        string token = "";

        [SetUp]
        public void auth()
        {  // setting up URL

            string url = $"{BaseUrl}/{version}/auth/login";
            //url = "http://api.qaauto.co.nz/api/v1/auth/login";
            var client = new RestClient($"{url}");
            TestContext.WriteLine(url);

            //Setting up method
            var request = new RestRequest(Method.POST);

            //headers
            request.AddHeader("Content-Type", "application/json");

            //How to set up body
            request.AddParameter("application/json", Auth, ParameterType.RequestBody);

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            token = data.access_token;
            
        }

        [Test]
        public void GetAllRecords()
        {

            TestContext.WriteLine($"Access token : {token}");
            String Url = $"{BaseUrl}/{version}/customers";
            var client = new RestClient(Url);
            TestContext.WriteLine(Url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"bearer {token}");

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
        }
        [Test]
        public void GetsingleRecords()
        {
            String Url = $"{BaseUrl}/{version}/customers/17";
            var client = new RestClient(Url);
            TestContext.WriteLine(Url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"bearer {token}");

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
        }

        string PostBody = "{\"company_name\": \"IC\",\"vat_number\": \"\",\"phone\": \"\",\"website\": \"API.com\",\"currency\": \"NZD\",\"country\": \"Aussie\",\"default_language\":\"English\"}";
        string UpdateBody = "{\"company_name\": \"IC\",\"vat_number\": \"\",\"phone\": \"\",\"website\": \"API.com\",\"currency\": \"NZD\",\"country\": \"Aussie\",\"default_language\":\"English\"}";
        [Test]
        public void CreateRecords(object PostBody)
        {
            String Url = $"{BaseUrl}/{version}/customers/17";
            var client = new RestClient(Url);
            TestContext.WriteLine(Url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/jason");
            request.AddHeader("Authorization", $"bearer {token}");
            //What this issue ? can you call on slack ?
            

            //How to set up body
            request.AddParameter("application/json", PostBody, ParameterType.RequestBody);

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
        }

        [Test]
        public void UpdateRecords()
        {
            String Url = $"{BaseUrl}/{version}/customers/17";
            var client = new RestClient(Url);
            TestContext.WriteLine(Url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/jason");
            request.AddHeader("Authorization", $"bearer {token}");

            //How to set up body
            request.AddParameter("application/json", UpdateBody, ParameterType.RequestBody);

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
        }

        [Test]
        public void DeletesingleRecords()
        {
            String Url = $"{BaseUrl}/{version}/customers/17";
            var client = new RestClient(Url);
            TestContext.WriteLine(Url);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"bearer {token}");

            //execute request
            IRestResponse response = client.Execute(request);

            //Response you Getting back
            TestContext.WriteLine(response.Content);
        }

    }
   

    

}




  

  
