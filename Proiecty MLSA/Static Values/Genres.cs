using Proiecty_MLSA.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Proiecty_MLSA.Static_Values
{
    class Genres
    {
        private List<Genre> genres;
        public static Genres instance = null;
        private Genres()
        {
            genres = new List<Genre>();
            fillGenres();
        }
        private async void fillGenres()
        {
                using (HttpResponseMessage message = await ApiHelper.getInstance().GetClient().GetAsync(ApiHelper.genresList))
                {
                    if (message.IsSuccessStatusCode)
                        if (genres.Count == 0)
                        {
                        Movie movie = await message.Content.ReadAsAsync<Movie>();
                        genres = movie.genres;
                    }
                }
        }
        public static Genres getInstance()
        {
            if (instance == null)
                instance = new Genres();
            return instance;
        }
    }
}
