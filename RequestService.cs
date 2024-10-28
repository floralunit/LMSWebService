using LMSWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LMSWebService
{
    public interface IRequestService
    {
        Task<List<Request>> GetRequestsAsync(string url, string token);
    }
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Получает список запросов из API.
        /// </summary>
        /// <returns>Список запросов.</returns>
        public async Task<List<Request>> GetRequestsAsync(string url, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetStringAsync(url + "/api/request?status=1");
                return JsonConvert.DeserializeObject<List<Request>>(response);
            }
            catch (HttpRequestException httpEx)
            {
                // Обработка ошибок HTTP
                Console.WriteLine($"Ошибка HTTP: {httpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                throw;

            }

        }
    }
}