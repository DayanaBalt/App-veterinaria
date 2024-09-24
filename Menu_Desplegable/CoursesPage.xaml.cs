using Menu_Desplegable.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesPage : ContentPage
    {
        ObservableCollection<UserMascota> Bmascotas;
        public CoursesPage()
        {
            InitializeComponent();
         Bmascotas = new ObservableCollection<UserMascota>();
          userList.ItemsSource = Bmascotas;
			LoadData();
		}
        void LoadData()
        {
          // var Mas = UserRepository.Instancia.GetAllUsersMascota();
            var Mas = UserRepository.Instancia.GetMascota();
            foreach (var Mascot in Mas)
            {
                Bmascotas.Add(Mascot);
            }
        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {


			if (string.IsNullOrWhiteSpace(txtName.Text) ||
	  string.IsNullOrWhiteSpace(txtPeso.Text) ||
	  string.IsNullOrWhiteSpace(txtRaza.Text) ||
	  string.IsNullOrWhiteSpace(txtEspecie.Text) ||
	  string.IsNullOrWhiteSpace(txtEdad.Text))
			{
				DisplayAlert("Alerta", "Llene completo el formulario", "OK");
			}
			else
			{
				StatusMessage.Text = string.Empty;

				int edad;
				if (int.TryParse(txtEdad.Text, out edad))
				{
					UserRepository.Instancia.AddNewUserM(
						txtName.Text,
						txtRaza.Text,
						txtPeso.Text,
						txtEspecie.Text,
						edad
					);
                    Bmascotas.Clear();
                    LoadData();
				}
				else
				{
					DisplayAlert("Alerta", "Edad debe ser un número válido", "OK");
				}
			}

			StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;

            txtName.Text = string.Empty;
            txtRaza.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            txtEdad.Text = string.Empty;
        }

        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {
            entryContainer.IsVisible = false;
            BtnAllUser.IsVisible = false;
            BtnInsert.IsVisible = false;
            BtnAtras.IsVisible= true;
           userList.IsVisible = true;
            BusquedaM.IsVisible= true;
            Agregar.IsVisible = true;
            Listass.IsVisible = true;
            //var allusers = UserRepository.Instancia.GetMascota();

            //userList.ItemsSource = allusers;
			//var Mas = UserRepository.Instancia.GetMascota();
			//    foreach (var Mascota in Bmas)
			//   {
			//       Bmas.Add(Mascota);
			//    }

			//StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
           // LoadData();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var userMascota = button.BindingContext as UserMascota;

            string newName = await DisplayPromptAsync("Editar Nombre", "Nuevo nombre:", initialValue: userMascota.Name);
            string newRaza = await DisplayPromptAsync("Editar Raza", "Nueva raza:", initialValue: userMascota.Raza);
            string newPeso = await DisplayPromptAsync("Editar Peso", "Nuevo peso:", initialValue: userMascota.Peso);
            string newEspecie = await DisplayPromptAsync("Editar Especie", "Nueva especie:", initialValue: userMascota.Especie);
            string newEdadString = await DisplayPromptAsync("Editar Edad", "Nueva edad:", initialValue: userMascota.Edad.ToString());

            if (!string.IsNullOrWhiteSpace(newName) &&
                !string.IsNullOrWhiteSpace(newRaza) &&
                !string.IsNullOrWhiteSpace(newPeso) &&
                !string.IsNullOrWhiteSpace(newEspecie) &&
                int.TryParse(newEdadString, out int newEdad))
            {
                userMascota.Name = newName;
                userMascota.Raza = newRaza;
                userMascota.Peso = newPeso;
                userMascota.Especie = newEspecie;
                userMascota.Edad = newEdad;
                UserRepository.Instancia.UpdateUserM(userMascota);
               // BtnAllUser_Clicked(sender, e);
               Bmascotas.Clear();
                LoadData();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
			//        var button = sender as Button;
			//        var userMascota = button.BindingContext as UserMascota;
			//        UserRepository.Instancia.DeleteUserM(userMascota.Id);

			//LoadData();

			var button = sender as Button;
			var userMascota = button.BindingContext as UserMascota;

			// Elimina el objeto de la base de datos
			UserRepository.Instancia.DeleteUserM(userMascota.Id);

			// Elimina el objeto de la colección ObservableCollection
			Bmascotas.Remove(userMascota);

			// Actualiza el mensaje de estado
			StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
          //  BtnAllUser_Clicked(sender, e);
          //BtnAtras_Clicked(sender, e);

		}

		private void BtnAtras_Clicked(object sender, EventArgs e)
		{
			entryContainer.IsVisible = true;
			BtnAllUser.IsVisible = true;
			BtnInsert.IsVisible = true;
			BtnAtras.IsVisible = false;
			userList.IsVisible = false;
            BusquedaM.IsVisible = false;
            Agregar.IsVisible = true;
            Listass.IsVisible = false;

		}



		private void busquedaMascota_TextChanged(object sender, TextChangedEventArgs e)
		{

            string file = BusquedaM.Text;
            Bmascotas.Clear();
             var Mb = UserRepository.Instancia.SearchMascotaByNombre(file);
            foreach (var m in Mb)
            {
                Bmascotas.Add(m);
            }

		}
	}
}
