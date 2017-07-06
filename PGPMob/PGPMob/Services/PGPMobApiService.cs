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

        public async Task<Pedido[]> PostConsultaPedidoAsync(string searchTerm)
        {
            var httpClient = new HttpClient();
            
            //var consulta = new
            //{
            //    parametro = searchTerm
            //};

            //var jsonRequest = JsonConvert.SerializeObject(consulta);
            //var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{BaseUrl}Pedido/Obter?parametro="+searchTerm, null).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<Pedido[]>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }

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


    }
}