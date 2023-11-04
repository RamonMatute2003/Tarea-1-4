namespace Tarea_1_4.Views;

public partial class View_data : ContentPage
{
	public View_data()
	{
		InitializeComponent();

	}

    protected override async void OnAppearing() {
        base.OnAppearing();

        image.Source=ImageSource.FromStream(() => new MemoryStream(Page_list_people.temp_photo));
    }
}