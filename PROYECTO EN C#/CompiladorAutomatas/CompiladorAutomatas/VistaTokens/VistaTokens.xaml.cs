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
using System.Windows.Shapes;
using CompiladorAutomatas;
using T_Simbolos;
namespace CompiladorAutomatas.VistaTokens
{
    /// <summary>
    /// Lógica de interacción para VistaTokens.xaml
    /// </summary>
    public partial class VistaTokens : Window
    {
        public VistaTokens()
        {
            InitializeComponent();
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void OnFocusR(object sender, RoutedEventArgs e)
        {
            Button bt = e.Source as Button;
            SolidColorBrush mb = new SolidColorBrush(Color.FromArgb(120, 255, 17, 0));
            bt.Background = mb;
        }
        private void LeaveFocus(object sender, RoutedEventArgs e)
        {
            Button bt = e.Source as Button;
            bt.Background = Brushes.Transparent;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            T_SimbolosM tk = new T_SimbolosM();
            tk.Tokens();
            var datos = tk.ObtenerTokens();

            foreach (var x in datos)
            {
                TokensShow.Items.Add(x);
            }
        }
    }
}
