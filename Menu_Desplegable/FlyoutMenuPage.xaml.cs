using System;
using Xamarin.Forms;

namespace Menu_Desplegable
{
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
            listview.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is FlyoutItemPage item)
            {
                var page = (Page)Activator.CreateInstance(item.TargetPage);
                page.Title = item.Title;

                var parent = (FlyoutPage)Parent;
                parent.Detail = new NavigationPage(page);
                parent.IsPresented = false;
            }
        }
    }

    //public class FlyoutItemPage
    //{
    //    public string Title { get; set; }
    //    public string IconSource { get; set; }
    //    public Type TargetPage { get; set; }
    //}
}
