using Menu_Desplegable.Model;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarCitaPage : ContentPage
    {
        private CitaViewModel _cita;

        public EditarCitaPage(CitaViewModel cita)
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
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var selectedUser = (User)UserPicker.SelectedItem;
                var selectedMascota = (UserMascota)MascotaPicker.SelectedItem;
                var selectedVeterinario = (Veterinario)VeterinarioPicker.SelectedItem;

                if (selectedUser == null || selectedMascota == null || selectedVeterinario == null || string.IsNullOrEmpty(DescripcionEntry.Text))
                {
                    await DisplayAlert("Error", "Por favor complete todos los campos", "OK");
                    return;
                }

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

                    UserRepository.Instancia.UpdateCita(citaToUpdate);
                    await DisplayAlert("Éxito", "Cita actualizada correctamente", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "OK");
            }
        }
    }
}
