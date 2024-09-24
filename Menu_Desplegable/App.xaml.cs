using Menu_Desplegable.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UserRepository.Inicializador(filename);
            MainPage = new NavigationPage(new LoginPage());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
