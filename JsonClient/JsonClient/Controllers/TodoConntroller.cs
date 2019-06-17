using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    class TodoController
    {
        public async Task<Todo> GetById(Client client, string id){
            //get Todo
            try{
                HttpResponseMessage response = await client.GetAsync("todos/" + id);
                response.EnsureSuccessStatusCode();

                Todo todo = await response.Content.ReadAsAsync<Todo>();

                return todo;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Todo>> GetAll(Client client){
            //get Todo
            try{
                HttpResponseMessage response = await client.GetAsync("todos" );
                response.EnsureSuccessStatusCode();

                List<Todo> todos = await response.Content.ReadAsAsync<List<Todo>>();

                return todos;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Todo> postTodo(Client client, Todo todo){
            //post Todo
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("todos", todo);
                response.EnsureSuccessStatusCode();

                Todo todos = await response.Content.ReadAsAsync<Todo>();
                Console.WriteLine("saved");
                return todos;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

        public async Task<Todo> updateTodo(Client client,string id, Todo todo){
            //put Todo
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("todos/"+ id, todo);
                response.EnsureSuccessStatusCode();

                Todo todos = await response.Content.ReadAsAsync<Todo>();
                Console.WriteLine("updated");
                return todos;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }
    }
    }