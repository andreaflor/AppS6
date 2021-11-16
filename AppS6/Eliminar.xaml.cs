using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        private const string Url = "http://192.168.56.1/moviles/post.php";
        
        public Eliminar()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtCodigo.Text);

            HttpClient cliento = new HttpClient();
            var resultado = await cliento.DeleteAsync(String.Concat("http://192.168.56.1/moviles/post.php?codigo={0}&nombre={1}&apellido={2}&edad={3}", txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtEdad.Text));
            if (resultado.IsSuccessStatusCode)
            {
                await DisplayAlert("Mensaje", "Registro eliminado", "Ok");
            }

            
        }

        private  async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}