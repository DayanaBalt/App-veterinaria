using Menu_Desplegable.Model;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitasPage : ContentPage
    {
        public CitasPage()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
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

            var citas = UserRepository.Instancia.GetAllCitas().ToList();

            var citasViewModel = from cita in citas
                                 join user in users on cita.UserId equals user.Id
                                 join mascota in mascotas on cita.MascotaId equals mascota.Id
                                 join veterinario in veterinarios on cita.VeterinarioId equals veterinario.VeterinarioID
                                
                                 select new CitaViewModel
                                 {
                                     Id = cita.Id,
                                     Fecha = cita.Fecha,
                                     Descripcion = cita.Descripcion,
                                     ClienteNombre = user.Name,
                                     MascotaNombre = mascota.Name,
                                     VeterinarioNombre = veterinario.Nombre,
									 Desc  = veterinario.descripcion,
                                     Especialidad =veterinario.Especialidad
                                     
								 };

            CitasListView.ItemsSource = citasViewModel;
        }

        private void OnAddCitaButtonClicked(object sender, EventArgs e)
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
					DisplayAlert("Error", "Por favor complete todos los campos", "OK");
					return;
				}
				else if (selectedDate < DateTime.Now.Date) // Comparar solo la parte de la fecha, ignorar la hora
				{
					DisplayAlert("Error", "La fecha seleccionada no puede ser anterior a la fecha actual", "OK");
					return;
				}
				else
				{
					// Agregar la nueva cita al repositorio
					UserRepository.Instancia.AddNewCita(
						selectedUser.Id,
						selectedMascota.Id,
						selectedVeterinario.VeterinarioID,
						selectedDate,
						descripcion,
						veterinarioDES,
						especialidad
					);


					// Cargar los datos actualizados
					LoadData();

					// Enviar mensaje para actualizar la lista de citas en otras páginas
					MessagingCenter.Send(this, "UpdateCitasList");
				}

			

			}
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "OK");
            }
        }

        private async void OnEditCitaButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var citaViewModel = button.BindingContext as CitaViewModel;

            string newDescripcion = await DisplayPromptAsync("Editar Descripción", "Nueva descripción:", initialValue: citaViewModel.Descripcion);

            if (!string.IsNullOrWhiteSpace(newDescripcion))
            {
                var citaToUpdate = UserRepository.Instancia.GetAllCitas().FirstOrDefault(c => c.Id == citaViewModel.Id);
                if (citaToUpdate != null)
                {
                    citaToUpdate.Descripcion = newDescripcion;
                    UserRepository.Instancia.UpdateCita(citaToUpdate);
                    LoadData();

                    // Enviar mensaje para actualizar la lista de citas en otras páginas
                    MessagingCenter.Send(this, "UpdateCitasList");
                }
            }
        }

        private async void OnCitaSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedCita = e.SelectedItem as CitaViewModel;
            await Navigation.PushAsync(new DetalleCitaPage(selectedCita));

            ((ListView)sender).SelectedItem = null;
        }

        private void OnDeleteCitaButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var citaViewModel = button.BindingContext as CitaViewModel;
            UserRepository.Instancia.DeleteCita(citaViewModel.Id);
            LoadData();

            // Enviar mensaje para actualizar la lista de citas en otras páginas
            MessagingCenter.Send(this, "UpdateCitasList");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

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

	public class CitaViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string ClienteNombre { get; set; }
        public string MascotaNombre { get; set; }
        public string VeterinarioNombre { get; set; }
       
        public string Desc {  get; set; }
        public string Especialidad { get; set; }
    }
}