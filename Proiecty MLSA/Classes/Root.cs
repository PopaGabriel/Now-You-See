﻿using System.Collections.Generic;

namespace Proiecty_MLSA.Classes
{
    public class Root
    {
        public int page { get; set; }
        public List<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
