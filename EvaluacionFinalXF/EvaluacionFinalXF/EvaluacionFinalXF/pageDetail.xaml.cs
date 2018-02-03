using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EvaluacionFinalXF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pageDetail : ContentPage
	{
        public MovieModel movie { get; set; }  
        public pageDetail (MovieModel objm)
		{
			InitializeComponent ();
            movie = objm;
            this.Title = "..::*Sinopsis*::..";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            this.lblNombre.Text = movie.title;
            this.lblDescripcion.Text = "Descripción: " + movie.description;
            this.lblCategoria.Text = "Categoría: " + movie.category;
            this.lblRating.Text = "Rating: 4";
            this.imgImagen.Source = movie.image;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
        }
        
    }
}