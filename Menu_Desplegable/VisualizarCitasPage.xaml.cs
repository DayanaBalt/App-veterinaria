using Menu_Desplegable.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Desplegable
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisualizarCitasPage : ContentPage
    {
		ObservableCollection<CitaViewModel> citasColletion;

		public VisualizarCitasPage()
        {
            InitializeComponent();
            citasColletion = new ObservableCollection<CitaViewModel>();
            CitasListView.ItemsSource = citasColletion;

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
            var citas = UserRepository.Instancia.GetAllCitas().ToList();

            var citasViewModel = from cita in citas
                                 join user in users on cita.UserId equals user.Id
                                 join mascota in mascotas on cita.MascotaId equals mascota.Id
                                 join veterinario in veterinarios on cita.VeterinarioId equals veterinario.VeterinarioID
								 orderby cita.Fecha
                                 select new CitaViewModel
                                 {
									 Id = cita.Id,
									 Fecha = cita.Fecha,
									 Descripcion = cita.Descripcion,
									 ClienteNombre = user.Name,
									 MascotaNombre = mascota.Name,
									 VeterinarioNombre = veterinario.Nombre,
									 Desc = veterinario.descripcion,
									 Especialidad = veterinario.Especialidad
								 };

			citasColletion.Clear();
			foreach (var cit in citasViewModel)
			{
				citasColletion.Add(cit);
			}

			//CitasListView.ItemsSource = citasViewModel;
        }

        private async void OnCitaSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedCita = e.SelectedItem as CitaViewModel;
            await Navigation.PushAsync(new DetalleCitaPage(selectedCita));

            ((ListView)sender).SelectedItem = null;
			citasColletion.Clear();
			LoadData();
        }

		private async void BtnCompletar_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			var citaViewModel = button.BindingContext as CitaViewModel;

			bool answer = await DisplayAlert("Confirmación", "¿Estás seguro de que deseas eliminar esta cita?", "Sí", "No");
			if (answer)
			{
				UserRepository.Instancia.DeleteCita(citaViewModel.Id);
				LoadData();
			}
		}

		private void BusquedaCita_TextChanged(object sender, TextChangedEventArgs e)
		{

			string filter = BusquedaCita.Text;

			var users = UserRepository.Instancia.GetAllUsers().ToList();
			var mascotas = UserRepository.Instancia.GetAllUsersM().ToList();
			var veterinarios = UserRepository.Instancia.GetAllVeterinarios().ToList();
			var citasList = UserRepository.Instancia.GetAllCitas().ToList();
			var filteredCitas = from cita in citasList
							   join user in users on cita.UserId equals user.Id
							   join mascota in mascotas on cita.MascotaId equals mascota.Id
							   where mascota.Name.ToLower().Contains(filter.ToLower())	
							   join veterinario in veterinarios on cita.VeterinarioId equals veterinario.VeterinarioID
							   //where veterinario.Nombre.ToLower().Contains(filter.ToLower())
							   select new CitaViewModel
							   {
								   Id = cita.Id,
								   Fecha = cita.Fecha,
								   Descripcion = cita.Descripcion,
								   ClienteNombre = user.Name,
								   MascotaNombre = mascota.Name,
								   VeterinarioNombre = veterinario.Nombre,
								   Desc = veterinario.descripcion,
								   Especialidad = veterinario.Especialidad
							   } into citaViewModel
								orderby citaViewModel.Fecha
								select citaViewModel; ;
			citasColletion.Clear();
			foreach (var cita in filteredCitas)
			{
				citasColletion.Add(cita);
			}


		}
	}
}
