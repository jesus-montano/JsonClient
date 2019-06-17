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

       public async Task<Comment> GetById( string id){
            //get Comment
            try{
                HttpResponseMessage response = await this.GetAsync("comments/" + id);
                response.EnsureSuccessStatusCode();

                Comment comment = await response.Content.ReadAsAsync<Comment>();

                return comment;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Comment>> GetAll(){
            //get Comment
            try{
                HttpResponseMessage response = await this.GetAsync("comments" );
                response.EnsureSuccessStatusCode();

                List<Comment> comments = await response.Content.ReadAsAsync<List<Comment>>();

                return comments;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Comment> postComment(Comment comment){
            //post Comment
            try{
                HttpResponseMessage response = await this.PostAsJsonAsync("comments", comment);
                response.EnsureSuccessStatusCode();

                Comment comments = await response.Content.ReadAsAsync<Comment>();
                Console.WriteLine("saved");
                return comments;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

        public async Task<Comment> updateComment(string id, Comment comment){
            //put Comment
            try{
                HttpResponseMessage response = await this.PutAsJsonAsync("comments/"+ id, comment);
                response.EnsureSuccessStatusCode();

                Comment comments = await response.Content.ReadAsAsync<Comment>();
                Console.WriteLine("updated");
                return comments;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }
    }
}