namespace EvaluacionSantiagoAlulema_Front.Components.services
{
    public class TitlesApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TitlesApi(IHttpClientFactory httpClientFactory)
            => _httpClientFactory = httpClientFactory;

        public async Task<List<string>> GetTitlesByUserIdAsync(int userId, CancellationToken ct = default)
        {
            var http = _httpClientFactory.CreateClient("ApiClient");
            var url = $"posts/titles?userId={userId}";

            var resp = await http.GetAsync(url, ct);
            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                throw new Exception($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}");
            }

            var result = await resp.Content.ReadFromJsonAsync<List<string>>(cancellationToken: ct);
            return result ?? new List<string>();
        }

        public async Task<string> SyncTitlesAsync(CancellationToken ct = default)
        {
            var http = _httpClientFactory.CreateClient("ApiClient");

            var resp = await http.GetAsync("posts/refresh", ct);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                throw new Exception($"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}. Body: {body}");
            }

            return await resp.Content.ReadAsStringAsync(ct);
        }
    }
}
