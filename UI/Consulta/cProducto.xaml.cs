using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Jose_Gonzalez_Ap1_p1.BLL;
using Jose_Gonzalez_Ap1_p1.Entidades;

namespace Jose_Gonzalez_Ap1_p1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cProducto.xaml
    /// </summary>
    public partial class cProducto : Window
    {
        public cProducto()
        {
            InitializeComponent();
        }

         public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if (string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                listado = ProductoBLL.GetList(l => true);
            }
            else
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProductoBLL.GetList(l => l.Productoid.ToString().Contains(CriterioTextBox.Text));
                        break;
                    case 1:
                        listado = ProductoBLL.GetList(l => l.Descripcion.Contains(CriterioTextBox.Text));
                        break;
                }
            }

            ProductoDataGrid.ItemsSource = null;
            ProductoDataGrid.ItemsSource = listado;
        }
    }
}
