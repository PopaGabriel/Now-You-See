using Newtonsoft.Json;
using Proiecty_MLSA.Static_Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proiecty_MLSA.Classes
{
    public class User
    {
        private static User instance = null;
        public int id { set; get; }
        public String UserName { set; get; }
        public List<Saved_Movie_Data> idsList { set; get; }
        public List<Movie> GoodMovies { set; get; }
        public List<Movie> BadMovies { set; get; }
        private String Email { set; get; }
        private User()
        {
            GoodMovies = new List<Movie>();
            BadMovies = new List<Movie>();
            idsList = new List<Saved_Movie_Data>();
            //I will have to add a new Json file for this crap
            //but it works so far as a proof of concept
            idsList.Add(new Saved_Movie_Data(2.5, 200));
            idsList.Add(new Saved_Movie_Data(3, 201));
            idsList.Add(new Saved_Movie_Data(3.5, 202));
            idsList.Add(new Saved_Movie_Data(4.0, 203));
            idsList.Add(new Saved_Movie_Data(4.5, 204));
            idsList.Add(new Saved_Movie_Data(5, 205));
            fillUserMovies();
        }
        public static User getInstance()
        {
            if (instance == null)
                instance = new User();
            return instance;
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
                        BadMovies.Add(badTask.Result);
                }
                else
                {
                    goodTask = ApiHelper.getInstance().GetMovie(idsList[i].id);
                    if (goodTask.Result != null)
                        GoodMovies.Add(goodTask.Result);
                }
            }
        }
        public static void SaveData()
        {
            string submittedFilePath =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\UserData.json";
            string text = File.ReadAllText(submittedFilePath);

            using (StreamWriter file = new StreamWriter(submittedFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Movie> movies = ApiHelper.getInstance().GetPopularMovies().Result;
                serializer.Serialize(file, movies);
            }

            text = File.ReadAllText(submittedFilePath);
            Console.WriteLine(text + "Dap Florin");

        }
    }
    public class MarkSort : IComparer
    {
        int IComparer.Compare(Object x, Object y)
        {
            Movie A = (Movie)x;
            Movie B = (Movie)y;
            return ((new CaseInsensitiveComparer()).Compare(B.vote_average, A.vote_average));
        }
    }
}
