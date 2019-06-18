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

    //    public async Task<Comment> postComment(Client client, Comment comment){
    //         //post Comment
    //         try{
    //             HttpResponseMessage response = await client.PostAsJsonAsync("comments", comment);
    //             response.EnsureSuccessStatusCode();

    //             Comment comments = await response.Content.ReadAsAsync<Comment>();
    //             Console.WriteLine("saved");
    //             return comments;

    //         }
    //         catch(HttpRequestException e){
    //             Console.WriteLine("{0}", e.Message);
    //             return null;
    //         }
    //     }

    //     public async Task<Comment> updateComment(Client client,string id, Comment comment){
    //         //put Comment
    //         try{
    //             HttpResponseMessage response = await client.PutAsJsonAsync("comments/"+ id, comment);
    //             response.EnsureSuccessStatusCode();

    //             Comment comments = await response.Content.ReadAsAsync<Comment>();
    //             Console.WriteLine("updated");
    //             return comments;

    //         }
    //         catch(HttpRequestException e){
    //             Console.WriteLine("{0}", e.Message);
    //             return null;
    //         }
    //     }
        }
    }