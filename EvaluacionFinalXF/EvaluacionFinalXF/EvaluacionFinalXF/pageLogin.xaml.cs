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
    public partial class pageLogin : ContentPage
    {
        public pageLogin()
        {
            InitializeComponent();
            this.Title = "SIGN IN";

            this.btnRegister.Clicked += (sender, e) =>
            {
                var pagRegister = new pageRegister();
                this.Navigation.PushAsync(pagRegister);
                this.entUser.Text = string.Empty;
                this.entPassword.Text = string.Empty;
            };
        }
        public async void subLogin(object sender, EventArgs e)
        {
            if (this.entUser.Text != null && this.entUser.Text != null)
            {
                var objUserModelVoid = new UserModel();
                objUserModelVoid.username = this.entUser.Text;
                objUserModelVoid.password = this.entPassword.Text;

                UserModel objUserModelRespuesta = Connect.Login(objUserModelVoid);
                if (objUserModelRespuesta.username != null)
                {
                    this.entUser.Text = string.Empty;
                    this.entPassword.Text = string.Empty;
                    await this.Navigation.PushAsync(new pageContentMovies(objUserModelRespuesta._kmd.authtoken, objUserModelRespuesta.name));
                }
                else
                {
                    await DisplayAlert("Credenciales", "Usuario y/o contraseña no existen", "Reintentar");
                }
            }
            else
            {
                await DisplayAlert("Credenciales", "Ningún campo debe estar vacío", "OK");
            }
        }
    }
}