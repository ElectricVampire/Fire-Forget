using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace EventSenderAPI
{
    public class CustomWebAPIClient
    {
        const string baseAddress = @"http://localhost:54728/";
        const string endPoint = @"api/Listener/DoSomethingWithEvent?id=";

        public async void CallWebAPIAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync(endPoint+id);
                if (response.IsSuccessStatusCode)
                {
                    // Return the msg that thread processing is completed.
                }
            }
        }
    }
}