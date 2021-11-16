using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppS6
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.56.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppS6.Ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get(){
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppS6.Ws.Datos> posts = JsonConvert.DeserializeObject<List<AppS6.Ws.Datos>>(content);
                _post = new ObservableCollection<AppS6.Ws.Datos>(posts);

                MyListView.ItemsSource = _post;
               
            }
            catch (Exception ex) {
                _ = DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        
        }

       
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Insertar());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Actualizar());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Eliminar());
        }
    }
}
