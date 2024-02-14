namespace PM02;

public partial class PageListPersonas : ContentPage
{
	public PageListPersonas()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        //var page = new NavigationPage(new PageInit());
        var page = new PageInit();
        await Navigation.PushAsync(page);
    }

    private async void ToolbarItem_Clicked_Mapa(object sender, EventArgs e)
    {
        //var page = new NavigationPage(new PageInit());
        var page = new Pagemapa();
        await Navigation.PushAsync(page);
    }

    private void listperson_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listperson.ItemsSource = await App.Database.GetListPersons();
    }
}