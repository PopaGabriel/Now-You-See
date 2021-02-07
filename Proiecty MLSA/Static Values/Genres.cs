using Proiecty_MLSA.Classes;
using System.Collections.Generic;
using System.Net.Http;

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
        public Genre getGenre(int id)
        {
            foreach (Genre genre in genres)
                if (genre.id == id)
                    return genre;

            return null;
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
