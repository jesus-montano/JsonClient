using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    public class Client : HttpClient {
        public Client(){
            this.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplicatiion/json"));

        }

    }
}