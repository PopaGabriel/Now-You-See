using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Proiecty_MLSA.Classes
{
    public class MarkSort : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Movie A = (Movie)x;
            Movie B = (Movie)y;
            return ((new CaseInsensitiveComparer()).Compare(B.vote_average, A.vote_average));
        }
    }
    public class User
    {
        public User()
        {
            UserName = "Eu";
            MovieList = new List<Movie>();
            BadMovies = new List<Movie>();
            GoodMovies = new List<Movie>();

            MovieList = MovieList.OrderBy(i => i.vote_average).ToList();

            if (MovieList.Count <= 5)
                GoodMovies = MovieList;
            else
                GoodMovies = MovieList.GetRange(0, 5);

            if (MovieList.Count > 5 && MovieList.Count < 10)
                BadMovies = MovieList.GetRange(5, MovieList.Count - 5);
            else
                BadMovies = MovieList.GetRange(MovieList.Count - 5, 5);
        }
        public String UserName { set; get; }
        public List<Movie> MovieList { set; get; }
        public List<Movie> GoodMovies { set; get; }
        public List<Movie> BadMovies { set; get; }
        public int Average_Mark_Given { set; get; }
        private String Email { set; get; }
        private String Password { set; get; }
    }
}
