using Menu_Desplegable.Model;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleCitaPage : ContentPage
    {
        private CitaViewModel _cita;
        public DetalleCitaPage(CitaViewModel cita)
        {
            InitializeComponent();
            _cita = cita;
            BindingContext = _cita;
            LoadData();
        }

        private void LoadData()
        {
            var users = UserRepository.Instancia.GetAllUsers().ToList();
            var mascotas = UserRepository.Instancia.GetAllUsersM().ToList();
            var veterinarios = UserRepository.Instancia.GetAllVeterinarios().ToList();

            UserPicker.ItemsSource = users;
            UserPicker.ItemDisplayBinding = new Binding("Name");

            MascotaPicker.ItemsSource = mascotas;
            MascotaPicker.ItemDisplayBinding = new Binding("Name");

            VeterinarioPicker.ItemsSource = veterinarios;
            VeterinarioPicker.ItemDisplayBinding = new Binding("Nombre");

            UserPicker.SelectedItem = users.FirstOrDefault(u => u.Name == _cita.ClienteNombre);
            MascotaPicker.SelectedItem = mascotas.FirstOrDefault(m => m.Name == _cita.MascotaNombre);
            VeterinarioPicker.SelectedItem = veterinarios.FirstOrDefault(v => v.Nombre == _cita.VeterinarioNombre);
        }

        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            FechaPicker.IsEnabled = true;
            DescripcionEntry.IsEnabled = true;
            UserPicker.IsEnabled = true;
            MascotaPicker.IsEnabled = true;
            VeterinarioPicker.IsEnabled = true;
            txtVeterinarioDES.IsEnabled = true;
            txtEspecialidad.IsEnabled = true;
            EditButton.IsVisible = false;
            SaveButton.IsVisible = true;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
				var selectedUser = (User)UserPicker.SelectedItem;
				var selectedMascota = (UserMascota)MascotaPicker.SelectedItem;
				var selectedVeterinario = (Veterinario)VeterinarioPicker.SelectedItem;
				string descripcion = DescripcionEntry.Text;
				string especialidad = txtEspecialidad.Text;
				string veterinarioDES = txtVeterinarioDES.Text;
				DateTime selectedDate = FechaPicker.Date;

                // Verificar que todos los campos estén completos y que la fecha seleccionada no sea anterior a hoy
                if (selectedUser == null || selectedMascota == null || selectedVeterinario == null ||
                    string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(especialidad) || string.IsNullOrEmpty(veterinarioDES))
                {
                   await  DisplayAlert("Error", "Por favor complete todos los campos", "OK");
                    return;
                }
                else if (selectedDate < DateTime.Today) // Comparar solo la parte de la fecha, ignorar la hora
                {
                    await DisplayAlert("Error", "La fecha seleccionada no puede ser anterior a la fecha actual", "OK");
                    return;
                }
                else
                {

                    _cita.Fecha = FechaPicker.Date;
                    _cita.Descripcion = DescripcionEntry.Text;
                    _cita.ClienteNombre = selectedUser.Name;
                    _cita.MascotaNombre = selectedMascota.Name;
                    _cita.VeterinarioNombre = selectedVeterinario.Nombre;

                    var citaToUpdate = UserRepository.Instancia.GetAllCitas().FirstOrDefault(c => c.Id == _cita.Id);
                    if (citaToUpdate != null)
                    {
                        citaToUpdate.Fecha = _cita.Fecha;
                        citaToUpdate.Descripcion = _cita.Descripcion;
                        citaToUpdate.UserId = selectedUser.Id;
                        citaToUpdate.MascotaId = selectedMascota.Id;
                        citaToUpdate.VeterinarioId = selectedVeterinario.VeterinarioID;
                        citaToUpdate.EspecialidadVeterinaria = txtEspecialidad.Text;
                        citaToUpdate.veterinarioDES = txtVeterinarioDES.Text;

                        UserRepository.Instancia.UpdateCita(citaToUpdate);
                        await DisplayAlert("Éxito", "Cita actualizada correctamente", "OK");
                        LoadData();
                        await Navigation.PopAsync(); // Regresar a la página anterior
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "OK");
            }
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirmar", "¿Está seguro de que desea eliminar esta cita?", "Sí", "No");
            if (confirm)
            {
                UserRepository.Instancia.DeleteCita(_cita.Id);
                await Navigation.PopAsync(); // Regresar a la página anterior
            }
        }

		private void VeterinarioPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedVeterinario = (Veterinario)VeterinarioPicker.SelectedItem;
			if (selectedVeterinario != null)
			{
				var veterinarioDetails = UserRepository.Instancia.GetVeterinarioById(selectedVeterinario.VeterinarioID);
				if (veterinarioDetails != null)
				{
					txtEspecialidad.Text = veterinarioDetails.Especialidad;
					txtVeterinarioDES.Text = veterinarioDetails.descripcion;
				}
			}
			else
			{
				txtEspecialidad.Text = string.Empty;
				txtVeterinarioDES.Text = string.Empty;
			}
		}
	}
}

