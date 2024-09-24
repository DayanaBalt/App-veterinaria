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
    public partial class LogoutPage : ContentPage
    {
		ObservableCollection<Veterinario> filteredVeterinarios;

		public LogoutPage()
        {
            InitializeComponent();

			filteredVeterinarios = new ObservableCollection<Veterinario>();
			userList.ItemsSource = filteredVeterinarios;
			LoadData();

		}
		void LoadData()
		{
			var veterinarios = UserRepository.Instancia.GetVeterinarios();
			foreach (var veterinario in veterinarios)
			{
				filteredVeterinarios.Add(veterinario);
			}
		}
		private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
		{

			string filter = searchBar.Text;
			filteredVeterinarios.Clear();

			var veterinarios = UserRepository.Instancia.SearchVeterinariosByNamestr(filter);
			foreach (var veterinario in veterinarios)
			{
				filteredVeterinarios.Add(veterinario);
			}

		}
	}
}