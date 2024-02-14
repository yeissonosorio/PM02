using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace PM02
{
    public partial class Pagemapa : ContentPage
    {
        double lon, lat;
        Pin pin;

        public Pagemapa()
        {
            InitializeComponent();
            GetLocation();
        }

        async void GetLocation()
        {
            try
            {
                // Solicitar permiso de acceso a la ubicación
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    // Si se obtiene la ubicación, puedes usarla como desees
                    double latitude = location.Latitude;
                    double longitude = location.Longitude;

                    // Crear el mapa con la ubicación actual
                    var map = new Microsoft.Maui.Controls.Maps.Map(MapSpan.FromCenterAndRadius(new Location(latitude, longitude), Distance.FromMiles(1)));

                    // Crear el pin con la ubicación actual
                    pin = new Pin
                    {
                        Label = "Mi Ubicación",
                        Address = "Ubicación Actual",
                        Type = PinType.Place,
                        Location = new Location(latitude, longitude)
                    };

                    // Agregar el pin al mapa
                    map.Pins.Add(pin);

                    // Establecer el contenido de la página como el mapa
                    Content = map;

                    // Agregar un controlador de eventos al mapa para manejar clics o toques
                    map.MapClicked += OnMapClicked;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // La geolocalización no es compatible en este dispositivo/platforma
                Console.WriteLine($"Geolocalización no es soportada: {fnsEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // No se otorgó permiso para acceder a la ubicación
                Console.WriteLine($"Permiso de ubicación no otorgado: {pEx.Message}");
            }
            catch (Exception ex)
            {
                // Otras excepciones
                Console.WriteLine($"Error al obtener la ubicación: {ex.Message}");
            }
        }
    }
}
