using EvaluacionSantiagoAlulema_Front.Components.Class;
using System.Net.Http;

namespace EvaluacionSantiagoAlulema_Front.Components.services
{
    public class UsersApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersApi(IHttpClientFactory httpClientFactory)
            => _httpClientFactory = httpClientFactory;

        public async Task<List<UserDto>> GetUsersAsync(CancellationToken ct = default)
        {
            var http = _httpClientFactory.CreateClient("ApiClient");

            var resp = await http.GetAsync("external/users", ct);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                throw new Exception($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}");
            }

            var users = await resp.Content.ReadFromJsonAsync<List<UserDto>>(cancellationToken: ct);
            return users ?? new List<UserDto>();
        }
    }
}
