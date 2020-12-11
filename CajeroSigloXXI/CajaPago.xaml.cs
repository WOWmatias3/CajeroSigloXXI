using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using BLL;

namespace CajeroSigloXXI
{
    /// <summary>
    /// Lógica de interacción para CajaPago.xaml
    /// </summary>
    public partial class CajaPago : Window
    {
        int total = 0;
        public CajaPago()
        {
            InitializeComponent();
            lblTOTAL.Content = "Total: $" + 0;
        }

        private void BtnActualizarLista_Click(object sender, RoutedEventArgs e)
        {
            BoletaBLL bolBLL = new BoletaBLL();
            DataTable Boletas = bolBLL.GetBoletasPorPagar();
            dtgBoletas.ItemsSource = Boletas.DefaultView;
        }

        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            var item = dtgBoletas.SelectedItem as DataRowView;
            if (null != item)
            {
                int id = Int32.Parse(item.Row[0].ToString());
                BoletaBLL bolBLL = new BoletaBLL();

                if(bolBLL.SetPagado(id, "pagado"))
                {
                    MessageBox.Show("Boleta Pagada Correctamente");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al Cambiar el estado de la boleta seleccionada");
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar una boleta para utilizar esta funcion");
            }
        }

        private void DtgBoletas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dtgBoletas.SelectedItem as DataRowView;
            if (null != item)
            {
                total = Int32.Parse( item.Row[5].ToString());
                string content = "Total: $" + item.Row[5].ToString();
                lblTOTAL.Content = content;
            }
        }

        private void TxtEfectivo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int tamanio = txtEfectivo.Text.Length;

            int ascii = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascii >= 48 && ascii <= 57)
            {
                e.Handled = false;
                lblVuelto.Content = int.Parse( txtEfectivo.Text)- total;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
