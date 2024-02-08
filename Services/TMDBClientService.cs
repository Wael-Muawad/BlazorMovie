namespace BlazorMovie.Services
{
    public class TMDBClientService
    {
        private readonly HttpClient _httpClient;

        public TMDBClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


    }
}
