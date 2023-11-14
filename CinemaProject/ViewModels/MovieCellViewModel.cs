using CinemaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaProject.ViewModels
{
    public class MovieCellViewModel:BaseViewModel
    {
		private Movie movie;

		public Movie Movie
		{
			get { return movie; }
			set { movie = value;
				movie.Description = movie.Description.Length>25?movie.Description.Substring(0, 20)
					:movie.Description;
				
				OnPropertyChanged(); }
		}


        public WrapPanel StarsPanel { get; set; }

        public MovieCellViewModel()
        {
        }
    }
}
