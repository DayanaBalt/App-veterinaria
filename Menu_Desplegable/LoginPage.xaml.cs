using Menu_Desplegable.Model;
using System;
using Xamarin.Forms;

namespace Menu_Desplegable
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var user = UserRepository.Instancia.GetUser(username, password);

            if (user != null)
            {
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
