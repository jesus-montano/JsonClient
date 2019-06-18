using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    class CommentController
    {
        public async Task<Comment> GetById(Client client, string id){
            //get Comment
            try{
                HttpResponseMessage response = await client.GetAsync("comments/" + id);
                response.EnsureSuccessStatusCode();

                Comment comment = await response.Content.ReadAsAsync<Comment>();

                return comment;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Comment>> GetAll(Client client){
            //get Comment
            try{
                HttpResponseMessage response = await client.GetAsync("comments" );
                response.EnsureSuccessStatusCode();

                List<Comment> comments = await response.Content.ReadAsAsync<List<Comment>>();

                return comments;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Comment> postComment(Client client, Comment comment){
            //post Comment
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("comments", comment);
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

        public async Task<Comment> updateComment(Client client,string id, Comment comment){
            //put Comment
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("comments/"+ id, comment);
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