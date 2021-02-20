﻿using Newtonsoft.Json;
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
        private int id { set; get; }
        private string UserName { set; get; }
        private double AverageRating { set; get; }

        private double age { set; get; }

        public int getId()
        {
            return id;
        }
        public Information(InformationBuilder info)
        {
            AverageRating = info.AverageRating;
            UserName = info.Name;
            age = info.age;
        }
    }
    public class InformationBuilder : IInformationBuilder
    {
        public double AverageRating { set; get; }
        public int age { set; get; }

        public String Name { set; get; }

        public IInformationBuilder setAge(int age)
        {
            this.age = age;
            return this;
        }

        public IInformationBuilder setAverageRating(double AverageRating)
        {
            this.AverageRating = AverageRating;
            return this;
        }

        public IInformationBuilder setName(string Name)
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
        private static User instance = null;
        private String ColorTheme { get; set; }
        private Information info { set; get; }
        public List<Saved_Movie_Data> idsList { set; get; }
        public ObservableCollection<Saved_Movie> GoodMovies { set; get; }
        public ObservableCollection<Saved_Movie> BadMovies { set; get; }
        private String Email { set; get; }
        private User()
        {
            GoodMovies = new ObservableCollection<Saved_Movie>();
            BadMovies = new ObservableCollection<Saved_Movie>();
            idsList = new List<Saved_Movie_Data>();

            //I will have to add a new Json file for this crap
            //but it works so far as a proof of concept
            ColorTheme = "Blue";
            idsList.Add(new Saved_Movie_Data(2.5, 200));
            idsList.Add(new Saved_Movie_Data(3, 201));
            idsList.Add(new Saved_Movie_Data(3.5, 202));
            idsList.Add(new Saved_Movie_Data(4.0, 203));
            idsList.Add(new Saved_Movie_Data(4.5, 204));
            idsList.Add(new Saved_Movie_Data(5, 205));
            fillUserMovies();
            info = new InformationBuilder().
                    setAge(10).
                    setAverageRating(CalculateRating()).
                    setName("UserTest").
                    Build();
        }
        public static User getInstance()
        {
            return instance ?? (instance = new User());
        }
        public double CalculateRating()
        {
            var sum = 0.0;
            foreach (Saved_Movie movie in GoodMovies)
            {
                sum += movie.savedRating;
            }
            foreach (Saved_Movie movie in BadMovies)
            {
                sum += movie.savedRating;
            }
            return sum / (GoodMovies.Count + BadMovies.Count);
        }
        private void fillUserMovies()
        {
            Task<Movie> goodTask;
            Task<Movie> badTask;

            for (int i = 0; i < idsList.Count; i++)
            {
                if (idsList[i].rating <= 2.5)
                {
                    badTask = ApiHelper.getInstance().GetMovie(idsList[i].id);
                    if (badTask.Result != null)
                        BadMovies.Add(new Saved_Movie(idsList[i].rating, badTask.Result));
                }
                else
                {
                    goodTask = ApiHelper.getInstance().GetMovie(idsList[i].id);
                    if (goodTask.Result != null)
                        GoodMovies.Add(new Saved_Movie(idsList[i].rating, goodTask.Result));
                }
            }
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
            return info.getId() + " " + GoodString + " " + BadString;
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
