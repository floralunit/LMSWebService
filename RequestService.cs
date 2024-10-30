using LMSWebService.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LMSWebService
{
    public interface IRequestService
    {
        Task<List<Request>> GetLeadsAsync(string url, string token, HttpClient _httpClient);
    }
    public class RequestService : IRequestService
    {
        /// <summary>
        /// Получает список лидов из API.
        /// </summary>
        /// <returns>Список лидов.</returns>
        public async Task<List<Request>> GetLeadsAsync(string url, string token, HttpClient _httpClient)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetStringAsync(url);
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