using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AndroidX.Core.App.NotificationCompat.MessagingStyle;

namespace AppS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        private const string Url= "http://192.168.56.1/moviles/post.php";
        public Actualizar()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                HttpClient client = new HttpClient();
                var response = client.PutAsync(String.Format("http://192.168.56.1/moviles/post.php?codigo={0}&nombre={1}&apellido={2}&edad={3}", txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtEdad.Text), null).Result;
                await DisplayAlert("Mensaje", "Actualizacion correcta", "ok");

            }
            catch (Exception ex)
            {
                 await DisplayAlert("Mensaje", ex.Message, "ok");
            }
        }
        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new MainPage());
        }
    }
}