

namespace PM02;

public partial class PageInit : ContentPage
{
    Controllers.PersonasControllers PersonDB;

    FileResult photo;

    public PageInit() {
        InitializeComponent();
    }

    public string GetImage64()
    {
        if(photo != null)
        {
            using(MemoryStream ms = new MemoryStream()) {
                Stream stream = photo.OpenReadAsync().Result;
                stream.CopyTo(ms);
                byte[] data = ms.ToArray(); 
                String Base64 = Convert.ToBase64String(data);

                return Base64;
            }
        }
        return null;
    }


    private async void btnprocesar_Clicked(object sender, EventArgs e)
    {
        try
        {
                var person = new Models.Personas
                {
                    Nombres = Nombre.Text,
                    Apellidos = Apellido.Text,
                    FechaNac = Fechanac.Date,
                    Telefono = telefono.Text,
                    foto = GetImage64()
                };

                if (await App.Database.StorePerson(person) > 0)
                {
                    await DisplayAlert("Aviso", "Registro ingresado con exito!!", "OK");
                }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No ingrese numero repetido", "OK");
        }
    }
    private async void btntomar_Clicked(object sender, EventArgs e)
    {
        photo = await MediaPicker.CapturePhotoAsync();
        if (photo != null)
        {
            string path = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using Stream sourcephoto = await photo.OpenReadAsync();
            using FileStream Stringlocal=File.OpenWrite(path);

            Foto.Source = ImageSource.FromStream(()=>photo.OpenReadAsync().Result);

            await sourcephoto.CopyToAsync(Stringlocal);
        }
    }

    private async void btnVerlista_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Lista());
    }
        
    }