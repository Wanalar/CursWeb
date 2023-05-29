using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CursWPF.Tools
{
    internal static class HttpApi
    {
        static HttpClient client = new HttpClient();
        static string host = "https://localhost:7100/api/";
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
            PropertyNameCaseInsensitive = true
        };

        public static async Task<string> Post(string controller, string method, object body)
        {
            try
            {
                string url = host + controller;
                if (!string.IsNullOrEmpty(method))
                    url += $"/{method}";
                //url += $"/{id}"; для get/delete/put
                string json = "";
                if (body != null)
                    json = JsonSerializer.Serialize(body, body.GetType(), options);
                var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                {
                    //MessageBox.Show(await response.Content.ReadAsStringAsync());
                    return "Ошибка";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "Предупреждение";
            }
        }


        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }

    //public static HttpApi instance;

    //public static HttpApi GetInstance()
    //{
    //    if (instance == null)
    //        instance = new HttpApi();
    //    return instance;
    //}
}
