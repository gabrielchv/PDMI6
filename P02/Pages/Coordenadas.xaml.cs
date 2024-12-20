using P02.Models;

namespace P02.Pages;

public partial class Coordenadas : ContentPage
{
    private GeoLoc geoLoc;

    public Coordenadas()
	{
		InitializeComponent();
        loadGeoLoc();
    }

    private async Task<GeoLoc> loadGeoLoc()
    {
        geoLoc = new GeoLoc();
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
            {
                geoLoc.Longitude = location.Longitude.ToString();
                geoLoc.Latitude = location.Latitude.ToString();
                geoLoc.Altitude = location.Altitude.ToString();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            return geoLoc;
        }
        catch (FeatureNotEnabledException fneEx)
        {
            return geoLoc;
        }
        catch (PermissionException pEx)
        {
            return geoLoc;
        }
        catch (Exception ex)
        {
            return geoLoc;
        }

        this.OnAppearing();
        return geoLoc;
    }

    protected override void OnAppearing()
    {
        BindingContext = geoLoc;
        base.OnAppearing();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}