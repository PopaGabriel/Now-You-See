using Newtonsoft.Json;
using Proiecty_MLSA.Static_Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiecty_MLSA.Classes
{
    public class Information
    {
        private int Id { set; get; }
        private string UserName { set; get; }
        private double AverageRating { set; get; }

        private double Age { set; get; }

        public int GetId()
        {
            return Id;
        }
        public Information(InformationBuilder info)
        {
            AverageRating = info.AverageRating;
            UserName = info.Name;
            Age = info.age;
        }
    }
    public class InformationBuilder : IInformationBuilder
    {
        public double AverageRating { set; get; }
        public int age { set; get; }

        public String Name { set; get; }

        public IInformationBuilder SetAge(int age)
        {
            this.age = age;
            return this;
        }

        public IInformationBuilder SetAverageRating(double AverageRating)
        {
            this.AverageRating = AverageRating;
            return this;
        }

        public IInformationBuilder SetName(string Name)
        {
            this.Name = Name;
            return this;
        }
        public Information Build()
        {
            return new Information(this);
        }
    }

    public class User
    {
        private static User _instance = null;
        private string ColorTheme { get; set; }
        private Information Info { set; get; }
        public List<Saved_Movie_Data> IdsList { set; get; }
        public ObservableCollection<SavedMovie> GoodMovies { set; get; }
        public ObservableCollection<SavedMovie> BadMovies { set; get; }
        private string Email { set; get; }
        private User()
        {
            GoodMovies = new ObservableCollection<SavedMovie>();
            BadMovies = new ObservableCollection<SavedMovie>();
            IdsList = new List<Saved_Movie_Data>();

            //I will have to add a new Json file for this crap
            //but it works so far as a proof of concept
            ColorTheme = "Blue";
            IdsList.Add(new Saved_Movie_Data(2.5, 200));
            IdsList.Add(new Saved_Movie_Data(3, 201));
            IdsList.Add(new Saved_Movie_Data(3.5, 202));
            IdsList.Add(new Saved_Movie_Data(4.0, 203));
            IdsList.Add(new Saved_Movie_Data(4.5, 204));
            IdsList.Add(new Saved_Movie_Data(5, 205));
            fillUserMovies();
            Info = new InformationBuilder().
                    SetAge(10).
                    SetAverageRating(CalculateRating()).
                    SetName("UserTest").
                    Build();
        }
        public static User GetInstance()
        {
            return _instance ?? (_instance = new User());
        }
        public double CalculateRating()
        {
            var sum = GoodMovies.Sum(movie => movie.SavedRating) + BadMovies.Sum(movie => movie.SavedRating);
            return sum / (GoodMovies.Count + BadMovies.Count);
        }
        private void fillUserMovies()
        {
            Task<Movie> goodTask;
            Task<Movie> badTask;

            for (int i = 0; i < IdsList.Count; i++)
            {
                if (IdsList[i].rating <= 2.5)
                {
                    badTask = ApiHelper.getInstance().GetMovie(IdsList[i].id);
                    if (badTask.Result != null)
                        BadMovies.Add(new SavedMovie(IdsList[i].rating, badTask.Result));
                }
                else
                {
                    goodTask = ApiHelper.getInstance().GetMovie(IdsList[i].id);
                    if (goodTask.Result != null)
                        GoodMovies.Add(new SavedMovie(IdsList[i].rating, goodTask.Result));
                }
            }
        }
        public bool Contains(SavedMovie savedMovie)
        {
            return GoodMovies.Any(movie => movie.id == savedMovie.id) || BadMovies.Any(movie => movie.id == savedMovie.id);
        } 
        public static void SaveData()
        {
            var submittedFilePath =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UserData.json";
            string text;

            using (var file = new StreamWriter(submittedFilePath))
            {
                var serializer = new JsonSerializer();
                var movies = ApiHelper.getInstance().GetPopularMovies().Result;
                serializer.Serialize(file, movies);
            }

        }
        public override string ToString()
        {
            var GoodString = new StringBuilder();
            var BadString = new StringBuilder();
            foreach (var movie in GoodMovies)
                GoodString.Append(movie);
            foreach (var movie in BadMovies)
                BadMovies.Append(movie);
            return Info.GetId() + " " + GoodString + " " + BadString;
        }

        public int[] GetMostWatchedGenresAndYear()
        {

            var allGenres = Genres.GetInstance().GetGenres();
            var tableOfValues = allGenres.ToDictionary(genre => genre.id, genre => 0);
            var median_year = 0;

            foreach (var movie in GoodMovies)
            {
                foreach (var genre in movie.genres)
                    tableOfValues[genre.id] += 5;

                median_year += int.Parse(movie.release_date.Substring(0,4));
            }
            foreach (var movie in BadMovies)
            {
                foreach (var genre in movie.genres)
                    tableOfValues[genre.id] += 1;

                median_year += int.Parse(movie.release_date.Substring(0,4));
            }
            var returnMatrix = new int[4];

            for (int i = 0; i < 3; i++)
            {
                var keyOfMaxValue = tableOfValues.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                tableOfValues.Remove(keyOfMaxValue);
                returnMatrix[i] = keyOfMaxValue;
            }
            returnMatrix[3] = median_year / (GoodMovies.Count + BadMovies.Count);

            return returnMatrix;
        }
    }
    public class MarkSort : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            var a = (Movie)x;
            var b = (Movie)y;
            return ((new CaseInsensitiveComparer()).Compare(b.vote_average, a.vote_average));
        }
    }
}
