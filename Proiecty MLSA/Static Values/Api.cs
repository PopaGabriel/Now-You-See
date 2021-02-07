using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Proiecty_MLSA.Static_Values
{
    public class ApiHelper
    {
        private HttpClient ApiClient;
        private static ApiHelper instance = null;

        public const string UriStringBase = "https://api.themoviedb.org/3/";

        // Format: [UriStringMovieGet][ID]?api_key=[ApiKey]
        // Example: https://api.themoviedb.org/3/movie/2000?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US
        public const string UriStringMovieGet = UriStringBase + "movie/";
        public const string ApiKey = "a54067ba9e2ae368e6a89cc91f806adc";
        public const string genresList = UriStringBase + "genre/movie/list?api_key=" + ApiKey;
        //https://api.themoviedb.org/3/movie/popular?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US&page=1
        public const string PopularApiAddress = UriStringBase + "popular?api_key=" + ApiKey + "&language=en-US&page=1";
        public const string languageAM = "language=en-US";

        public static ApiHelper getInstance()
        {
            if (instance == null)
                instance = new ApiHelper();
            return instance;
        }
        private ApiHelper()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(UriStringBase);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Saved_Movie>> GetPopularMovies()
        {
            using (HttpResponseMessage message = await ApiClient.GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US&page=1"))
            {
                if (message.IsSuccessStatusCode)
                {
                    List<Saved_Movie> listMovies = new List<Saved_Movie>();
                    Root root = await message.Content.ReadAsAsync<Root>();
                    
                    for (int i = 0; i < root.results.Count; i++)
                        listMovies.Add(new Saved_Movie(-1 ,await ApiHelper.getInstance().GetMovie(root.results[i].id)));

                    return listMovies;
                }
                else
                    return null;
            }
        }

        public async Task<Movie> GetMovie(int id)
        {
            using (HttpResponseMessage message = await ApiClient.GetAsync(UriStringMovieGet + id + "?api_key=" + ApiKey + "&" + languageAM))
            {
                if (message.IsSuccessStatusCode)
                {
                    Movie movie = await message.Content.ReadAsAsync<Movie>();
                    movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
                    return movie;
                }
                else
                    return null;
            }
        }
        public HttpClient GetClient()
        {
            return ApiClient;
        }
    }
}