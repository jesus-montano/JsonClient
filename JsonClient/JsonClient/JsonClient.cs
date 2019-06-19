using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JsonClient
{
    public class JsonClient<TModel>
    {
        private HttpClient client;

        public JsonClient()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplicatiion/json"));
        }
        public async Task<TModel> GetAsync(string id){
            //get Comment
            try{
                var requestURL = $"{typeof(TModel).Name.ToLower()}s";
                HttpResponseMessage response = await client.GetAsync($"{requestURL}/{id}");
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<TModel>();

                return result;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return default(TModel);
            }
        }

       public async Task<IEnumerable<TModel>> GetAsync(){
            //get Comment
            try{
                var requestURL = $"{typeof(TModel).Name.ToLower()}s";
                HttpResponseMessage response = await client.GetAsync(requestURL);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<IEnumerable<TModel>>();

                return result;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return default(IEnumerable<TModel>);
            }
        }

        public async Task<TModel> postAsync(TModel model){
             //post Comment
             try{
                 var requestURL = $"{typeof(TModel).Name.ToLower()}s";
                 HttpResponseMessage response = await client.PostAsJsonAsync(requestURL, model);
                 response.EnsureSuccessStatusCode();

                 var models = await response.Content.ReadAsAsync<TModel>();
                 Console.WriteLine("saved");
                 return models;

             }
             catch(HttpRequestException e){
                 Console.WriteLine("{0}", e.Message);
                 return default(TModel);
             }
         }

         public async Task<TModel> updateAsync(string id, TModel model){
             //put Comment
             try{
                  var requestURL = $"{typeof(TModel).Name.ToLower()}s";
                 HttpResponseMessage response = await client.PutAsJsonAsync($"{requestURL}/{id}", model);
                 response.EnsureSuccessStatusCode();

                 TModel models = await response.Content.ReadAsAsync<TModel>();
                 Console.WriteLine("updated");
                 return models;

             }
             catch(HttpRequestException e){
                 Console.WriteLine("{0}", e.Message);
                 return default(TModel);
             }
         }
        }
    }


