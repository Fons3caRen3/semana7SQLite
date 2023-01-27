using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {

        public int IdSeleccionado;
        private SQLiteAsyncConnection con;

        IEnumerable<Estudiante> rEliminar;
        IEnumerable<Estudiante> rActualizar;

        public Elemento(int Id, string Nombre, string Usuario, string Contrasena)
        {
            InitializeComponent();
            txtNombre.Text = Nombre;
            txtUsuario.Text = Usuario;
            txtContrasena.Text= Contrasena;
            IdSeleccionado= Id;
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id) {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE Id=?", id);
        }


        public static IEnumerable<Estudiante> Update(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre=?, Usuario=?, Contrasena=? where Id=?", nombre,usuario,contrasena,id);
        }


        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db=new SQLiteConnection(ruta);
                rActualizar = Update(db, IdSeleccionado, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}