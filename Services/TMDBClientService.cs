﻿using BlazorMovie.Models;
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
            try
            {
                if (pageNum < 1) pageNum = 1;
                else if (pageNum > 500) pageNum = 500;

                return await _httpClient.GetFromJsonAsync<PopularMoviePagedResponse>($"movie/popular?page{pageNum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }    
        }

        public async Task<MovieDetails?> GetMovieById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
