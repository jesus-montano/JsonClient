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
        private string requestURL;
        public JsonClient()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplicatiion/json"));
            requestURL = $"{typeof(TModel).Name.ToLower()}s";
        }

        public async Task<TModel> GetAsync(string id)
        {
            //get Comment
            var result = default(TModel);

            HttpResponseMessage response = await client.GetAsync($"{requestURL}/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<TModel>();

            return result;
        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            //get Comment
            var result = default(IEnumerable<TModel>);
            HttpResponseMessage response = await client.GetAsync(requestURL);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<IEnumerable<TModel>>();

            return result;
        }

        public async Task<TModel> PostAsync(TModel model)
        {
            //post Comment
            var result = default(TModel);
            HttpResponseMessage response = await client.PostAsJsonAsync(requestURL, model);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<TModel>();

            return result;
        }

        public async Task<TModel> UpdateAsync(string id, TModel model)
        {
            //put Comment
            var result = default(TModel);
            HttpResponseMessage response = await client.PutAsJsonAsync($"{requestURL}/{id}", model);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<TModel>();

            return result;
        }
    }
}


