using System;
using System.Collections.Generic;
using System.Text;

namespace Proiecty_MLSA.Classes
{
    public class Movie
    {
        public Movie(String Name, int Mark_from_site)
        {
            Team = new List<Worker>();
            this.Name = Name;
            this.Mark_from_site = Mark_from_site;
        }
        public void Add_Members(Worker worker)
        {
            Team.Add(worker);
        }
        public void Remove_Member(Worker worker)
        {
            if (Team.Contains(worker))
                Team.Remove(worker);
            else
                Console.WriteLine("Merge_fratelelelelelele");
        }
        public override String ToString()
        {
            return Name + " " + Mark_from_site;
        }
        public String Name { set; get; }
        public List<Worker> Team {set; get;}
        
        public int Mark_from_site { set; get; }

        public int Your_mark { set; get; }

        public int Number_of_votes { set; get; }

        public String Image { set; get; }

        public String Description { set; get; }

    }
}
