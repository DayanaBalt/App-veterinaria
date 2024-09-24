using Menu_Desplegable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        ObservableCollection<User> userscollection;
        public HomePage()
        {
            InitializeComponent();
            userscollection = new ObservableCollection<User>();
            userList.ItemsSource = userscollection;
            LoadData();
        }
		void LoadData()
		{
			var userss = UserRepository.Instancia.GetUsers();
			foreach (var userC in userss)
			{
				userscollection.Add(userC);
			}
		}
		private void BtnInsert_Clicked(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtName.Text) ||
			   string.IsNullOrWhiteSpace(txtCelular.Text) ||
			   string.IsNullOrWhiteSpace(txtDireccion.Text)) 
			   
			{
				DisplayAlert("Alerta", "Llene completo el formulario", "OK");
			}
			else
			{
				StatusMessage.Text = string.Empty;


				long telefono;
				if (long.TryParse(txtCelular.Text, out telefono))
				{
                    UserRepository.Instancia.AddNewUser(txtName.Text, txtCelular.Text, txtDireccion.Text);

                    StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
                    userscollection.Clear();
                    LoadData();
                }
                else
				{
					DisplayAlert("Alerta", "Celular debe ser un número válido", "OK");
				}
			}
			//StatusMessage.Text = string.Empty;

			//UserRepository.Instancia.AddNewUser(txtName.Text, txtCelular.Text, txtDireccion.Text);

			//StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;

			txtName.Text = string.Empty;
			txtCelular.Text = string.Empty;
			txtDireccion.Text = string.Empty;

		}

        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {
			entryContainer.IsVisible = false;
            BtnInsert.IsVisible = false;
            BtnAtras.IsVisible= true;
            BtnAllUser.IsVisible= false;
            userList.IsVisible = true;
			BusquedaC.IsVisible = true;
            Agregar.IsVisible = false;
            LISTA.IsVisible = true;
			//var allusers = UserRepository.Instancia.GetUsers();

           //userList.ItemsSource = allusers;
           // LoadData() ;
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var user = button.BindingContext as User;

            string newName = await DisplayPromptAsync("Editar Nombre", "Nuevo nombre:", initialValue: user.Name);
            string newCelular = await DisplayPromptAsync("Editar Celular", "Nuevo celular:", initialValue: user.Celular);
            string newDireccion = await DisplayPromptAsync("Editar Dirección", "Nueva dirección:", initialValue: user.Direccion);

            if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newCelular) && !string.IsNullOrWhiteSpace(newDireccion))
            {
                user.Name = newName;
                user.Celular = newCelular;
                user.Direccion = newDireccion;
                UserRepository.Instancia.UpdateUser(user);
              //  BtnAllUser_Clicked(sender, e);
              userscollection.Clear();
                LoadData();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var user = button.BindingContext as User;
            UserRepository.Instancia.DeleteUser(user.Id);
            userscollection.Remove(user);
           // BtnAllUser_Clicked(sender, e);
           // LoadData();

        }

		private void BtnAtras_Clicked(object sender, EventArgs e)
		{
			entryContainer.IsVisible = true;
            BtnAllUser.IsVisible = true;
            BtnInsert.IsVisible = true;
            BtnAtras.IsVisible = false;
            userList.IsVisible = false;
            BusquedaC.IsVisible = false;
            Agregar.IsVisible= true;
            LISTA.IsVisible = false; 

		}

		private void BusquedaC_TextChanged(object sender, TextChangedEventArgs e)
		{

			string file = BusquedaC.Text;
			userscollection.Clear();
			var cl = UserRepository.Instancia.SearchClienteByNombre(file);
			foreach (var cliente in cl)
			{
				userscollection.Add(cliente);
			}

		}
	}
}