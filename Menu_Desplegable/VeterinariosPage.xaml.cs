using Menu_Desplegable.Model;
using System;
using System.Security;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VeterinariosPage : ContentPage
    {
        public VeterinariosPage()
        {
            InitializeComponent();
        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
	           string.IsNullOrWhiteSpace(txtApellido.Text) ||
	           string.IsNullOrWhiteSpace(txtEspecialidad.Text) ||
	           string.IsNullOrWhiteSpace(txtTelefono.Text) ||
	           string.IsNullOrWhiteSpace(txtDescripcion.Text))
			{
				DisplayAlert("Alerta", "Llene completo el formulario", "OK");
			}
			else
			{
				StatusMessage.Text = string.Empty;

				
				long telefono;
				if (long.TryParse(txtTelefono.Text, out telefono))
				{
					UserRepository.Instancia.AddNewVeterinario(
						txtNombre.Text,
						txtApellido.Text,
						txtEspecialidad.Text,
						txtTelefono.Text,
						txtDescripcion.Text
					);
				}
				else
				{
					DisplayAlert("Alerta", "Teléfono debe ser un número válido", "OK");
				}
			}


			StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;

                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                txtEspecialidad.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            
        }

        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {
			entryContainer.IsVisible = false;
			BtnAllUser.IsVisible = false;
			BtnInsert.IsVisible = false;
			BtnAtras.IsVisible = true;
			userList.IsVisible = true;
            Agregar.IsVisible = false;
            Lista.IsVisible = true;
			var allusers = UserRepository.Instancia.GetAllVeterinarios();

            userList.ItemsSource = allusers;

            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var veterinario = button.BindingContext as Veterinario;

            string newNombre = await DisplayPromptAsync("Editar Nombre", "Nuevo nombre:", initialValue: veterinario.Nombre);
            string newApellido = await DisplayPromptAsync("Editar Apellido", "Nuevo apellido:", initialValue: veterinario.Apellido);
            string newEspecialidad = await DisplayPromptAsync("Editar Especialidad", "Nueva especialidad:", initialValue: veterinario.Especialidad);
            string newTelefono = await DisplayPromptAsync("Editar Teléfono", "Nuevo teléfono:", initialValue: veterinario.Telefono);
            string newDescripcion = await DisplayPromptAsync("editar descripcion","Nueva descrpcion", initialValue: veterinario.descripcion);

            if (!string.IsNullOrWhiteSpace(newNombre) &&
                !string.IsNullOrWhiteSpace(newApellido) &&
                !string.IsNullOrWhiteSpace(newEspecialidad) &&
                !string.IsNullOrWhiteSpace(newTelefono) &&
                !string.IsNullOrWhiteSpace(newDescripcion)


				)
            {
                veterinario.Nombre = newNombre;
                veterinario.Apellido = newApellido;
                veterinario.Especialidad = newEspecialidad;
                veterinario.Telefono = newTelefono;
                veterinario.descripcion = newDescripcion;
                UserRepository.Instancia.UpdateVeterinario(veterinario);
                BtnAllUser_Clicked(sender, e);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var veterinario = button.BindingContext as Veterinario;
            UserRepository.Instancia.DeleteVeterinario(veterinario.VeterinarioID);
            BtnAllUser_Clicked(sender, e);
        }

		private void BtnAtras_Clicked(object sender, EventArgs e)
		{
			entryContainer.IsVisible = true;
			BtnAllUser.IsVisible = true;
			BtnInsert.IsVisible = true;
			BtnAtras.IsVisible = false;
			userList.IsVisible = false;
            Agregar.IsVisible = true;
            Lista.IsVisible = false;
		}
	}
}
