using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;//variable de conexión
        public Registro()
        {
            InitializeComponent();
            con=DependencyService.Get<DataBase>().GetConnection(); //inicializar variable conexion
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };//Crear nuevo usuario
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            Navigation.PushAsync(new Login());
            
        }
    }
}