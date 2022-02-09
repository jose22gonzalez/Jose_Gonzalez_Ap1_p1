using System.Windows;
using Jose_Gonzalez_Ap1_p1.Entidades;
using Jose_Gonzalez_Ap1_p1.BLL;


namespace Jose_Gonzalez_Ap1_p1.UI.Registro
{
    public partial class rRegistro : Window
    {
        private Productos productos = new Productos();
        public rRegistro()
        {
            InitializeComponent();
            this.DataContext = productos;

        }


        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.productos;
        }

        private void Limpiar()
        {
            this.productos = new Productos();
            this.DataContext = productos;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(productos.Descripcion))
            {
                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Debe indicar la Descripcion!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(productos.Productoid.ToString()))
            {
                esValido = false;
                ProductoidTextbox.Focus();
                MessageBox.Show("Debe indicar el ProductoID!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductoBLL.Buscar(this.productos.Productoid);
            if (encontrado != null)
            {
                this.productos = encontrado;
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

            if (!Validar())
            {
                return;
            }
            if (!ProductoBLL.Existe(productos.Productoid))
            {
                productos.ValorInventario = productos.Costo * productos.Existencia;
               
                
                paso = ProductoBLL.Guardar(productos);
                 MessageBox.Show("Producto guardado con eso exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }else{
                MessageBox.Show("No se puede guardar el Producto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }


/*
            if (paso)
            {
                MessageBox.Show("Producto guardado con eso exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puede guardar el Producto", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }*/

        }

        public void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductoBLL.Eliminar(productos.Productoid))
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