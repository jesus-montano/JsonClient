using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    class AlbumController
    {
        public async Task<Album> GetById(Client client, string id){
            //get Album
            try{
                HttpResponseMessage response = await client.GetAsync("albums/" + id);
                response.EnsureSuccessStatusCode();

                Album album = await response.Content.ReadAsAsync<Album>();

                return album;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Album>> GetAll(Client client){
            //get Album
            try{
                HttpResponseMessage response = await client.GetAsync("albums" );
                response.EnsureSuccessStatusCode();

                List<Album> albums = await response.Content.ReadAsAsync<List<Album>>();

                return albums;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Album> postAlbum(Client client, Album album){
            //post Album
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("albums", album);
                response.EnsureSuccessStatusCode();

                Album albums = await response.Content.ReadAsAsync<Album>();
                Console.WriteLine("saved");
                return album;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

        public async Task<Album> updateAlbum(Client client,string id, Album album){
            //put Album
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("albums/"+ id, album);
                response.EnsureSuccessStatusCode();

                Album albums = await response.Content.ReadAsAsync<Album>();
                Console.WriteLine("updated");
                return albums;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }
    }
}