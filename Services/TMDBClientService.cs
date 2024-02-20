using BlazorMovie.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorMovie.Services
{
    public class TMDBClientService
    {
        private readonly HttpClient _httpClient;

        public TMDBClientService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string apikey = config.GetSection("apikey").Value
                ?? throw new Exception("TMDB key was not found");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apikey);
        }


        public async Task<PopularMoviePagedResponse?> GetPopularMovies(int pageNum = 1)
        {
            if (pageNum < 1) pageNum = 1;
            else if (pageNum > 500) pageNum = 500;
            throw new IndexOutOfRangeException();
            return await _httpClient.GetFromJsonAsync<PopularMoviePagedResponse>($"movie/popular?page={pageNum}");

        }

        public async Task<MovieDetails?> GetMovieById(int id)
        {
            return await _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
        }

    }
}
