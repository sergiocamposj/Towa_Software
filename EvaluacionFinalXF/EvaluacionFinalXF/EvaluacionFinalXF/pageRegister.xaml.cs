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
    public partial class pageRegister : ContentPage
    {
        public pageRegister()
        {
            InitializeComponent();
            this.Title = "Sign up";

            this.btnRegisterRegister.Clicked += (sender, e) =>
            {
                if (this.entRegisterUsername.Text != string.Empty && this.entRegisterPassword.Text != string.Empty &&
                      this.entRegisterConfirmPassword.Text != string.Empty &&
                      this.entRegisterName.Text != string.Empty && this.entRegisterTelphone.Text != null &&
                      this.entRegisterEmail.Text != string.Empty)
                {
                    string username_IO = this.entRegisterUsername.Text;
                    string password_IO = this.entRegisterPassword.Text;
                    string passwordconfirm_IO = this.entRegisterConfirmPassword.Text;
                    string name_IO = this.entRegisterName.Text;
                    int phone_IO = int.Parse(this.entRegisterTelphone.Text);
                    string email_IO = this.entRegisterEmail.Text;

                    if (this.entRegisterPassword.Text == this.entRegisterConfirmPassword.Text)
                    {
                        string respuesta = Connect.Register(username_IO, password_IO, name_IO, phone_IO, email_IO);

                        if (respuesta == "OK")
                        {
                            DisplayAlert("Registro", "Se ha registrado a " + name_IO + " con éxito!", "Aceptar");
                            var pageToLogin = new pageLogin();
                            this.Navigation.PushAsync(pageToLogin);
                        }
                        else if (respuesta == "Hubo un problema en la comunicacion con el servidor")
                        {
                            DisplayAlert("SERVIDOR WEB", "Hubo un problema en la comunicacion con el servidor", "Aceptar");
                        }
                        else
                        {
                            DisplayAlert("Registro", "No se registró, intente nuevamente", "Reintentar");
                        }
                    }
                    else
                    {
                        DisplayAlert("Contraseña", "Las contraseñas deben ser iguales", "Reintentar");
                    }

                }
                else
                {
                    DisplayAlert("Registro", "Ningún campo debe estar vacío", "OK");
                }
            };
        }
    }
}