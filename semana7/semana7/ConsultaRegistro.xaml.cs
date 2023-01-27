using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;//variable de conexión
        private ObservableCollection<Estudiante> tEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection(); //inicializar variable conexion
            Listar();
        }

        public async void Listar(){

            var resultado=await con.Table<Estudiante>().ToListAsync();
            tEstudiante= new ObservableCollection<Estudiante>(resultado);
            ListaEstudiantes.ItemsSource=tEstudiante;
        }

        public void OnSelection(object sender, SelectedItemChangedEventArgs e){

            var obj=(Estudiante)e.SelectedItem;
            var item=obj.Id.ToString();
            var Id=Convert.ToInt32(item);
            var Nombre=obj.Nombre.ToString();
            var Usuario=obj.Usuario.ToString();
            var Contrasena= obj.Contrasena.ToString();

            Navigation.PushAsync(new Elemento(Id,Nombre, Usuario, Contrasena));

        }

        private void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}