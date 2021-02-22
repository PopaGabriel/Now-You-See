using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Proiecty_MLSA.Classes
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return id + " " + name;
        }
    }
    public class Saved_Movie_Data
    {
        public Saved_Movie_Data(double rating, double id)
        {
            this.rating = rating;
            this.id = id;
        }
        public double rating { set; get; }

        public double id { get; set; }
    }

    public class ProductionCompany
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class ProductionCountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class SpokenLanguage
    {
        public string english_name { get; set; }
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

    public class Movie
    {
        public Movie()
        {
            genre_ids = new List<int>();
            production_companies = new List<ProductionCompany>();
            production_countries = new List<ProductionCountry>();
            spoken_languages = new List<SpokenLanguage>();
        }
        public bool adult { get; set; }
        public double budget { get; set; }
        public ObservableCollection<Genre> genres { get; set; }
        public List<int> genre_ids { get; set; }
        public string homepage { get; set; }
        public double id { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompany> production_companies { get; set; }
        public List<ProductionCountry> production_countries { get; set; }
        public string release_date { get; set; }
        public double revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguage> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public void FillGenres(List<int> list)
        {
            foreach (var t in list)
            {
                var genre = new Genre {id = t};
                genres.Add(genre);
            }
        }
        public override string ToString()
        {
            return "Overview: " + overview + 
                   "\n vote_average: " + vote_average + 
                   "\nTitle: " + title + 
                   "\nPoster_Address: " + poster_path + 
                   "\nGenres:" + ShowGenres();
        }
        private string ShowGenres()
        {
            var genresString = new StringBuilder();
            foreach (var VARIABLE in genres)
            {
                genresString.Append(VARIABLE.id)
                    .Append("\n")
                    .Append(VARIABLE.name)
                    .Append("\n");
            }
            return genresString.ToString();
        }
    }


    public class SavedMovie : Movie
    {
        public double SavedRating { get; set; }

        public SavedMovie(double savedRating, Movie movie)
        {
            title = movie.title;
            vote_average = movie.vote_average;
            poster_path = movie.poster_path;
            release_date = movie.release_date;
            runtime = movie.runtime;
            overview = movie.overview;
            id = movie.id;
            genres = movie.genres;
            SavedRating = savedRating;
        }
    }
}
