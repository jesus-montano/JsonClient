using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    class PostController
    {
        public async Task<Post> GetById(Client client, string id){
            //get Post
            try{
                HttpResponseMessage response = await client.GetAsync("posts/" + id);
                response.EnsureSuccessStatusCode();

                Post post = await response.Content.ReadAsAsync<Post>();

                return post;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Post>> GetAll(Client client){
            //get Post
            try{
                HttpResponseMessage response = await client.GetAsync("posts" );
                response.EnsureSuccessStatusCode();

                List<Post> post = await response.Content.ReadAsAsync<List<Post>>();

                return post;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Post> postPost(Client client, Post post){
            //post Post
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("posts", post);
                response.EnsureSuccessStatusCode();

                Post posts = await response.Content.ReadAsAsync<Post>();
                Console.WriteLine("saved");
                return post;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

        public async Task<Post> updatePost(Client client,string id, Post post){
            //put Post
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("comments/"+ id, post);
                response.EnsureSuccessStatusCode();

                Post posts = await response.Content.ReadAsAsync<Post>();
                Console.WriteLine("updated");
                return posts;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }
    }
    }