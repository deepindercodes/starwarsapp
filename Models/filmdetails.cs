using System;
using System.Collections.Generic;

namespace starwarsapp.Models
{
    public class filmdetails
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        public List<characters> characterinfo { get; set; }
        public List<planets> planetsinfo { get; set; }
        public List<starships> starshipsinfo { get; set; }
        public List<vehicles> vehiclesinfo { get; set; }
        public List<species> speciesinfo { get; set; }
    }
}