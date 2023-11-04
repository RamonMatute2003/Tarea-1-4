using Tarea_1_4.Models;

namespace Tarea_1_4.Views;

public partial class Page_list_people : ContentPage
{
    People selectedItem = null;
    public static byte[] temp_photo;
    public Page_list_people(){
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        base.OnAppearing();

        list.ItemsSource=await App.Instancia.list_people();
    }

    private void OnItemTapped(Object sender,SelectionChangedEventArgs e) {
        selectedItem=e.CurrentSelection.FirstOrDefault() as People;

        temp_photo=selectedItem.photo;
    }

    private async void view_photo(object sender,EventArgs e) {
        if(selectedItem!=null) {
            await Navigation.PushAsync(new View_data());
            selectedItem=null;
        } else {
            await DisplayAlert("Alerta","Seleccione una persona","Ok");
        }
    }
}