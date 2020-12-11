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
using BLL;
using MahApps.Metro.Controls;

namespace CajeroSigloXXI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            usuarioBLL usrbll = new usuarioBLL();
            bool check = usrbll.getLogin(txt_nombreusuario.Text, txtPass.Password.ToString());
            if (check)
            {
                MessageBox.Show("Bienvenido " + txt_nombreusuario.Text);

                CajaPago caja = new CajaPago();
                
                caja.ShowDialog();
            }
            else
            {
                MessageBox.Show("Credenciales o Rol Incorrectos \n Intente nuevamente");
            }
        }
    }
}
