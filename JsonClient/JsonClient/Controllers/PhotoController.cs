using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
namespace JsonClient
{
    class PhotoController
    {
        public async Task<Photo> GetById(Client client, string id){
            //get Photo
            try{
                HttpResponseMessage response = await client.GetAsync("photos/" + id);
                response.EnsureSuccessStatusCode();

                Photo photo = await response.Content.ReadAsAsync<Photo>();

                return photo;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<List<Photo>> GetAll(Client client){
            //get Photo
            try{
                HttpResponseMessage response = await client.GetAsync("photos" );
                response.EnsureSuccessStatusCode();

                List<Photo> photo = await response.Content.ReadAsAsync<List<Photo>>();

                return photo;
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

       public async Task<Photo> postPhoto(Client client, Photo photo){
            //post Photo
            try{
                HttpResponseMessage response = await client.PostAsJsonAsync("photos", photo);
                response.EnsureSuccessStatusCode();

                Photo photos = await response.Content.ReadAsAsync<Photo>();
                Console.WriteLine("saved");
                return photos;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }

        public async Task<Photo> updatePhoto(Client client,string id, Photo photo){
            //put Photo
            try{
                HttpResponseMessage response = await client.PutAsJsonAsync("photo/"+ id, photo);
                response.EnsureSuccessStatusCode();

                Photo photos = await response.Content.ReadAsAsync<Photo>();
                Console.WriteLine("updated");
                return photos;

            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
                return null;
            }
        }
    }
}