using CinemaProject.Commands;
using CinemaProject.Services;
using CinemaProject.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaProject.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public WrapPanel MyPanel { get; set; }

        private string searchText;

		public string SearchText
		{
			get { return searchText; }
			set { searchText = value; OnPropertyChanged(); }
		}

        public RelayCommand SearchCommand { get; set; }

        public MainViewModel()
        {
            SearchCommand = new RelayCommand((obj) =>
            {
                MyPanel.Children.Clear();
               var movies = MovieService.GetMovies(SearchText);
                int x = 10;
                int y = 10;

                foreach (var m in movies)
                {
                    var ucVM = new MovieCellViewModel();
                    ucVM.Movie = m;


                    var uc = new MovieCellUC(ucVM);


                    var data = Math.Ceiling(double.Parse(m.Rating)/2);

                    int count = (int)data;
                    for (int i = 0; i < count; i++)
                    {
                        ucVM.StarsPanel.Children.Add(new StarUC());
                    }



                    uc.Width = 300;
                    uc.Height = 200;
                    uc.Margin = new System.Windows.Thickness(x, y, 0, 0);

                    MyPanel.Children.Add(uc);

                }
            });
        }
    }
}
