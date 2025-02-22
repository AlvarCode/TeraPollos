using System.Net.Http;
using System.Net.Http.Json;
namespace TeraPollos.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		using (HttpClient client = new HttpClient())
		{
			string urlrecurso = "http://192.168.71.208:8000/login";
			LoginRequest datos = new LoginRequest(Convert.ToInt32(codigo.Text), contra.Text);
			HttpResponseMessage respuesta = await client.PostAsJsonAsync(urlrecurso, datos);
			Console.WriteLine(respuesta.Content.ToString());
		}
    }
}
class LoginRequest
{
	public int UserId { get; set; }
	public string Password { get; set; }
	public LoginRequest(int userId, string password)
	{
		UserId = userId;
		Password = password;
	}
}