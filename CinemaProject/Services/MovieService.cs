using CinemaProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaProject.Services
{
    public class MovieService
    {
        public static dynamic? Data { get; set; }
        public static dynamic? SingleData { get; set; }

        public static List<Movie> GetMovies(string movie)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync($"http://www.omdbapi.com/?apikey=ddee1dae&s={movie}&plot=full").Result;
            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);
            List<Movie> movies = new List<Movie>();
            if (Data != null)
            {
                try
                {
                    for (int i = 0;; i++)
                    {
                        response = httpClient.GetAsync($"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[i].Title}&plot=full").Result;
                        str = response.Content.ReadAsStringAsync().Result;
                        SingleData = JsonConvert.DeserializeObject(str);
                        if (SingleData != null)
                        {
                            var mymovie = new Movie
                            {
                                Description = SingleData.Plot,
                                ImagePath = SingleData.Poster,
                                Name = SingleData.Title,
                                Rating = SingleData.imdbRating,
                            };
                            movies.Add(mymovie);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return movies;
        }
    }
}
