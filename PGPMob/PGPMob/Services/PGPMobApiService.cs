using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using PGPMob.Models;
using System.Net;
using PGPMob.Helper;

[assembly: Dependency(typeof(PGPMob.Services.PGPMobApiService))]
namespace PGPMob.Services
{
    public class PGPMobApiService : IPGPMobApiService
    {
        private const string BaseUrl = "http://192.168.0.10/pgpws/";

        public async Task<Usuario> PostValidaUsuario(string usuario, string senha)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var usuarioesenha = new
            {
                Usuario = usuario,
                Senha = senha
            };

            var jsonRequest = JsonConvert.SerializeObject(usuarioesenha);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{BaseUrl}Seguranca/ValidaUsuario", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<Usuario>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }

        public async Task<Usuario> ValidaUsuario(string usuario, string senha)
        {
            var usuarioesenha = new
            {
                Usuario = usuario,
                Senha = senha
            };

            var jsonRequest = JsonConvert.SerializeObject(usuarioesenha);

            return await MakePostRequest<Usuario>(BaseUrl + "Seguranca/ValidaUsuario", jsonRequest);
        }

        //private async T HttpPostJson<T>(string baseAdress, string url, string json)
        //{
        //    var webAddr = string.Concat(baseAdress, url); 
        //    var httpWebRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(webAddr);
        //    httpWebRequest.ContentType = "application/json; charset=utf-8";
        //    httpWebRequest.Method = "POST";

        //    var stream = await httpWebRequest.GetRequ   estStreamAsync();

        //    using (var writer = new StreamWriter(stream))
        //    {
        //        writer.Write(serializedDataString);
        //        writer.Flush();
        //        writer.Dispose();
        //    }

        //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //    {
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //    }

        //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    var streamReader = new StreamReader(httpResponse.GetResponseStream());
        //    var result = streamReader.ReadToEnd();

        //    return jss.Deserialize<T>(result);
        //}

        private async Task<T> MakePostRequest<T>(string url, string serializedDataString, bool isJson = true)
        {
            
            var request = WebRequest.CreateHttp(url);
            if (isJson)
                request.ContentType = "application/json";
            else
                request.ContentType = "application/x-www-form-urlencoded";

            request.Method = "POST";
            var stream = await request.GetRequestStreamAsync();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(serializedDataString);
                writer.Flush();
                writer.Dispose();
            }

            var response = await request.GetResponseAsync();
            var respStream = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(respStream))
            {
                return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
            }
        }

    }
}