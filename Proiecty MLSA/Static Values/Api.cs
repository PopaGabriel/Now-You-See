using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Proiecty_MLSA.Static_Values
{
    public class ApiHelper
    {
        private readonly HttpClient _apiClient;
        private static ApiHelper _instance;

        public const string UriStringBase = "https://api.themoviedb.org/3/";

        // Format: [UriStringMovieGet][ID]?api_key=[ApiKey]
        // Example: https://api.themoviedb.org/3/movie/2000?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US
        public const string UriStringMovieGet = UriStringBase + "movie/";
        public const string ApiKey = "a54067ba9e2ae368e6a89cc91f806adc";
        public const string GenresList = UriStringBase + "genre/movie/list?api_key=" + ApiKey;
        //https://api.themoviedb.org/3/movie/popular?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US&page=1
        public const string PopularApiAddress = UriStringBase + "popular?api_key=" + ApiKey + "&language=en-US&page=1";
        public const string LanguageAm = "language=en-US";
        public const string DiscoverBase = "https://api.themoviedb.org/3/discover/movie?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";

        public static ApiHelper getInstance()
        {
            return _instance ?? (_instance = new ApiHelper());
        }
        private ApiHelper()
        {
            _apiClient = new HttpClient {BaseAddress = new Uri(UriStringBase)};
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<SavedMovie>> GetPopularMovies()
        {
            using (var message = await _apiClient.GetAsync("https://api.themoviedb.org/3/movie/popular?api_key=a54067ba9e2ae368e6a89cc91f806adc&language=en-US&page=1"))
            {
                if (!message.IsSuccessStatusCode) return null;

                var listMovies = new List<SavedMovie>();
                var root = await message.Content.ReadAsAsync<Root>();

                foreach (var t in root.results)
                    listMovies.Add(new SavedMovie(0, await ApiHelper.getInstance().GetMovie(t.id)));

                return listMovies;
            }
        }
        public async Task<ObservableCollection<SavedMovie>> SearchMovies(string baseText)
        {
            if (baseText == null) return null;
            var apiBuild = "https://api.themoviedb.org/3/search/movie?api_key=" + ApiKey + "&language=en-US&query=" + baseText + "&page=1&include_adult=true";

            using (var message = await _apiClient.GetAsync(apiBuild))
            {
                if (!message.IsSuccessStatusCode) return null;

                var listMovies = new ObservableCollection<SavedMovie>();
                var root = await message.Content.ReadAsAsync<Root>();

                foreach (var t in root.results)
                    listMovies.Add(new SavedMovie(0, await getInstance().GetMovie(t.id)));

                return listMovies;
            }
        }

        public async Task<Movie> GetMovie(double id)
        {
            using (var message = await _apiClient.GetAsync(UriStringMovieGet + id + "?api_key=" + ApiKey + "&" + LanguageAm))
            {
                if (!message.IsSuccessStatusCode) return null;

                var movie = await message.Content.ReadAsAsync<Movie>();
                movie.poster_path = "https://image.tmdb.org/t/p/original" + movie.poster_path;
                return movie;
            }
        }

        internal async Task<ObservableCollection<SavedMovie>> Recommend ()
        {
            var user = User.GetInstance();
            var recommendedMovies = new ObservableCollection<SavedMovie>();
            var mostWatchedList = await Task.Run(() => user.GetMostWatchedGenresAndYear());

            var baseString = DiscoverBase + "&release_date.gte=" + (mostWatchedList[3] - 5) +
                             "-01-01&release_date.lte=" + (mostWatchedList[3] + 5)
                             + "-12-12&with_genres=";


            using (var message = await _apiClient.GetAsync(baseString + mostWatchedList[0] + "%2C" + mostWatchedList[1] + "%2C" + mostWatchedList[2]+ "%7C"+
                                                            mostWatchedList[0] + "%2C" + mostWatchedList[1]))
            {
                if (!message.IsSuccessStatusCode) return recommendedMovies;
                
                var root = await message.Content.ReadAsAsync<Root>();
                foreach (var t in root.results)
                {
                    var movie = new SavedMovie(0, await getInstance().GetMovie(t.id));
                    if (!User.GetInstance().Contains(movie))
                        recommendedMovies.Add(movie);
                }
            }

            return recommendedMovies;
        }
        public HttpClient GetClient()
        {
            return _apiClient;
        }
    }
}