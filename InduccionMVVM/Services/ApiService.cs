using System;
using System.Text;
using InduccionMVVM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace InduccionMVVM.Services
{
    public class ApiService : iApiService
    {
        public ApiService()
        {
        }

        const string UriApi = "http://189.254.239.136:88/WebApiobj/api/Products";

        public async Task<List<Products>> GetProducts(string filter)
        {
            try
            {
                Debug.WriteLine("===========//==========");
                var queryString = string.Empty;
                if (!string.IsNullOrEmpty(filter))
                {
                    queryString += $"?name{System.Net.WebUtility.UrlEncode(filter)}";
                }
                var result = await this.MakeHttpCall<List<Products>>(queryString);
                return result;

            }
            catch(Exception ex)
            {
                Debug.WriteLine("===========//==========" + ex.Message);
                throw ex;
            }


        }



        /// <summary>
        /// Makes the http call. //este es reutilizable para cualquier api
        /// </summary>
        /// <returns>The http call.</returns>
        /// <param name="filter">Filter.</param>
        /// <typeparam name="TOutput">The 1st type parameter.</typeparam>
        private async Task<TOutput> MakeHttpCall<TOutput>(string filter)
        {
            string url = $"{UriApi}{filter}";

            var client = new HttpClient()
            {
                Timeout = TimeSpan.FromMinutes(1)
            };

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {

                response = await client.GetAsync(url);

                string responseText = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TOutput>(responseText);
                }
                else
                {
                    throw new Exception(string.Format("Response Statuscode for {0}: {1}", url, response.StatusCode));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("===========//==========" + ex.Message);
                throw ex;
            }
        }
        /*
       Task<List<Products>> iApiService.GetProducts(string filter)
        {
            throw new NotImplementedException();

        }*/
    }
}
