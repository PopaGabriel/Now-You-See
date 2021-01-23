using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proiecty_MLSA.Classes
{
    public class MarkSort : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Movie A = (Movie)x;
            Movie B = (Movie)y;
            return ((new CaseInsensitiveComparer()).Compare(B.Mark_from_site, A.Mark_from_site));
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
            for(int i = 0; i < 30; i++)
            {
                MovieList.Add(new Movie("Movie"+" "+i, i));
            }
            MovieList = MovieList.OrderBy(i => i.Mark_from_site).ToList();
            
            if (MovieList.Count <= 5)
                GoodMovies = MovieList;
            else
                GoodMovies = MovieList.GetRange(0, 5);

            if (MovieList.Count > 5 && MovieList.Count < 10)
                BadMovies = MovieList.GetRange(5, MovieList.Count - 5);
            else
                BadMovies = MovieList.GetRange(MovieList.Count-5, 5);
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
