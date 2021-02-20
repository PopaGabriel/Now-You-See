using Proiecty_MLSA.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Proiecty_MLSA.Static_Values
{
    class Genres
    {
        private List<Genre> _genres;
        public static Genres Instance;
        private Genres()
        {
            _genres = new List<Genre>();
            FillGenres();
        }
        public Genre GetGenre(int id)
        {
            return _genres.FirstOrDefault(genre => genre.id == id);
        }
        private async void FillGenres()
        {
            using (HttpResponseMessage message = await ApiHelper.getInstance().GetClient().GetAsync(ApiHelper.GenresList))
            {
                if (!message.IsSuccessStatusCode) return;
                if (_genres.Count != 0) return;

                var movie = await message.Content.ReadAsAsync<Movie>();
                _genres = movie.genres;
            }
        }
        public static Genres GetInstance()
        {
            return Instance ?? (Instance = new Genres());
        }
    }
}
