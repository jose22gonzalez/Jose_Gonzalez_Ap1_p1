using System.Windows;
using Jose_Gonzalez_Ap1_p1.Entidades;
using Jose_Gonzalez_Ap1_p1.BLL;


namespace Jose_Gonzalez_Ap1_p1.UI.Registro
{
    public partial class rRegistro : Window
    {
        private Productos Productos = new Productos();
        public rRegistro()
        {
            InitializeComponent();

        }

        public void CalcularUnitario()
        {
            
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Productos;
        }

        private void Limpiar()
        {
            this.Productos = new Productos();
            this.DataContext = Productos;
        }

        private bool Validad()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Productos.Descripcion))
            {
                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Debe escribir la Descripcion!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(Productos.Costo.ToString()))
            {
                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("Debe escribir la Costo!", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            return esValido;
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductoBLL.Buscar(this.Productos.Productoid);
            if (encontrado != null)
            {
                this.Productos = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el producto!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            if (!Validad())
            {
                return;
            }

            paso = ProductoBLL.Guardar(Productos);

            if (paso)
            {
                MessageBox.Show("Producto guardado con eso exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Producto guardado con eso exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductoBLL.Eliminar(Productos.Productoid))
            {
                Limpiar();
                MessageBox.Show("Producto Eliminado", "Con exito!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puede Eliminar el Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




    }
}