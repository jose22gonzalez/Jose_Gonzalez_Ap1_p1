using System.Windows;
using System.Linq;
using System.Collections.Generic;
using Jose_Gonzalez_Ap1_p1.BLL;
using Jose_Gonzalez_Ap1_p1.Entidades;


namespace Jose_Gonzalez_Ap1_p1.UI.Consulta
{
    public partial class cConsulta : Window
    {
        public cConsulta()
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