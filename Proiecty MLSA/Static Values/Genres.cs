using Proiecty_MLSA.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Proiecty_MLSA.Static_Values
{
    internal class Genres
    {
        private ObservableCollection<Genre> _genres;
        private static Genres _instance;
        private Genres()
        {
            _genres = new ObservableCollection<Genre>();
            FillGenres();
        }
        public Genre GetGenre(int id)
        {
            return _genres.FirstOrDefault(genre => genre.id == id);
        }
        private async void FillGenres()
        {
            using (var message = await ApiHelper.getInstance().GetClient().GetAsync(ApiHelper.GenresList))
            {
                if (!message.IsSuccessStatusCode) return;
                if (_genres.Count != 0) return;

                var movie = await message.Content.ReadAsAsync<Movie>();
                _genres = movie.genres;
            }
        }

        public override string ToString()
        {
            var interior = new StringBuilder();
            foreach (var t in _genres)
                interior.Append(t).Append('\n');
            return interior.ToString();
        }

        public ObservableCollection<Genre> GetGenres()
        {
            return _genres;
        }
        public static Genres GetInstance()
        {
            return _instance ?? (_instance = new Genres());
        }
    }
}
