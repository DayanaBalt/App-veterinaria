using Menu_Desplegable.Model;
using System;
using System.Xml.Linq;
using Xamarin.Forms;

namespace Menu_Desplegable
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {

            var name = NameEntry.Text;
            var celular = CelularEntry.Text;
            var direccion = DireccionEntry.Text;
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
               string.IsNullOrWhiteSpace(CelularEntry.Text) ||
               string.IsNullOrWhiteSpace(DireccionEntry.Text) ||
               string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
               string.IsNullOrWhiteSpace(PasswordEntry.Text))

            {
                await DisplayAlert("Alerta", "Llene completo el formulario", "OK");
            }
            else
            {



                long telefono;
                if (long.TryParse(CelularEntry.Text, out telefono))
                {

                    var result = UserRepository.Instancia.RegisterUser(name, celular, direccion, username, password);

                    if (result > 0)
                    {
                        await DisplayAlert("Success", "User registered successfully", "OK");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Registration failed", "OK");
                    }
                }
				else
				{
					await DisplayAlert("Alerta", "Teléfono debe ser un número válido", "OK");
				}
			}
        }
    }
}
