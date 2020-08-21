using DemoHugo.Helpers.NetworkHelpers;
using DemoHugo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace DemoHugo.Helpers
{
    public class MyHttp:NetworkStatus
    {
        public static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// metodo que selecciona las url dependiendo la bander que llegue como parametro
        /// </summary>
        /// <param name="bandera"></param>
        /// <returns></returns>
        public static string URL(string bandera)
        { 
           
            string url = string.Empty;
            switch (bandera)
            {
                    //Get Popular
                case "0":
                    url = "https://api.themoviedb.org/3/movie/popular?api_key=17282dff1783373cf64c8c0e055e60e3&language=en-US&page=1";
                    break;
                    //Get TopRated
                case "1":
                    url = "https://api.themoviedb.org/3/movie/top_rated?api_key=17282dff1783373cf64c8c0e055e60e3&language=en-US&page=1";
                    break;
                    //Get UpComming
                case "2":
                    url = "https://api.themoviedb.org/3/movie/upcoming?api_key=17282dff1783373cf64c8c0e055e60e3&language=en-US&page=1";
                    break;
                default:
                    break;
            }
            return url;
        }
        /// <summary>
        /// metodo que obtine las peliculas mas populares
        /// </summary>
        /// <returns></returns>
        public static async Task<Popular> GetPopular()
        {
            try
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Cargando ...", null, null, true, MaskType.Clear);
                string urlRest = $"{URL("0")}";
                HttpResponseMessage response = await httpClient.GetAsync(urlRest);
                var resultado = response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<Popular>(
                        await response.Content.ReadAsStringAsync());
                }
                if (response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout ||
                    response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                {
                    //await GetActivosAsync(action, id);
                }
       
                return null;
            }
            catch (Exception ex)
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Recargando ...", null, null, true, MaskType.Clear);
                
                return null;
            }

        }
        /// <summary>
        /// Metodo que obtiene el top de peliculas
        /// </summary>
        /// <returns></returns>
        public static async Task<TopRated> GetTopRated()
        {
            try
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Cargando ...", null, null, true, MaskType.Clear);
                string urlRest = $"{URL("1")}";
                HttpResponseMessage response = await httpClient.GetAsync(urlRest);
                var resultado = response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<TopRated>(
                        await response.Content.ReadAsStringAsync());
                }
                if (response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout ||
                    response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                {
                    //await GetActivosAsync(action, id);
                }

                return null;
            }
            catch (Exception ex)
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Recargando ...", null, null, true, MaskType.Clear);

                return null;
            }

        }
        /// <summary>
        /// metodo que obtiene las peliculas que saldran proximamente
        /// </summary>
        /// <returns></returns>
        public static async Task<UpComing> GetUpComming()
        {
            try
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Cargando ...", null, null, true, MaskType.Clear);
                string urlRest = $"{URL("2")}";
                HttpResponseMessage response = await httpClient.GetAsync(urlRest);
                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<UpComing>(
                        await response.Content.ReadAsStringAsync());
                }
                if (response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout ||
                    response.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
                {
                    //await GetActivosAsync(action, id);
                }

                return null;
            }
            catch (Exception ex)
            {
                //IProgressDialog dialog = UserDialogs.Instance.Loading("Recargando ...", null, null, true, MaskType.Clear);

                return null;
            }

        }
    }
}
