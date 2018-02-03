using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvaluacionFinalXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pageContentMovies : ContentPage
    {        
        public string Message { get; set; }
        public string tokenVacio { get; set; }
        public pageContentMovies(string tokenRecibido, string Nombre)
        {
            InitializeComponent();
            this.tokenVacio = tokenRecibido;
            this.Message = Nombre;            
            Connect.tokenVacios = this.tokenVacio;
            this.Title = "..::*Cartelera*::..";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.lblUserSesion.Text = "Inició sesión: " + this.Message + "!";

            Connect.GetMovies((movies) =>
            {
                var adapter = new ObservableCollection<MovieModel>();
                foreach (MovieModel movieItem in movies)
                {
                    adapter.Add(movieItem);
                }
                this.lstvMovies.ItemsSource = adapter;
                this.lstvMovies.RowHeight = 80;
            },
                () =>
                {
                    DisplayAlert("Server Error", "Ha habido un error con el servidor", "Ok");
                }
            );

        }

        private void subDetail(object sender, ItemTappedEventArgs e)
        {
            MovieModel objmovie = (MovieModel)e.Item;
            Navigation.PushAsync(new pageDetail(objmovie));
        }       

        protected override bool OnBackButtonPressed()
        {
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (await DisplayAlert("Cerrar Sesión", "Estás seguro que desas cerrar la sesión?", "Si", "No"))
                {
                    base.OnBackButtonPressed();

                    await Navigation.PopAsync();
                }
            });
            
            return true;
        }        
    }
}