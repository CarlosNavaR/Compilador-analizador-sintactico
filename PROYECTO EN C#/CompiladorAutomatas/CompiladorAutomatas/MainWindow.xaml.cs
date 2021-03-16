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
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;
using T_Simbolos;
using Microsoft.Win32;
using System.IO;
using System.Collections.Specialized;
using CompiladorAutomatas.VistaTokens;

namespace CompiladorAutomatas
{
    public partial class MainWindow : Window
    {
        T_SimbolosM Tsimbolos = new T_SimbolosM();

        public MainWindow()
        {
            InitializeComponent();
            Tsimbolos.Tokens();
        }
        //Metodos de disenio y formato
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void OnFocus(object sender, RoutedEventArgs e)
        {
            Button bt = e.Source as Button;
            SolidColorBrush mb = new SolidColorBrush(Color.FromArgb(80, 255, 255, 255));
            bt.Background = mb;
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
        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            var iconMin = new PackIcon { Kind = PackIconKind.WindowRestore };
            var iconMax = new PackIcon { Kind = PackIconKind.WindowMaximize };
            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                btnMax.Content = iconMin;
            }
            else 
            {
                btnMax.Content = iconMax;
                this.WindowState = WindowState.Normal;
            }
        }
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if(WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Minimized;
            }
        }


        //Metodos de usabilidad, guardar, abrir codigo
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = " Abrir archivo      -        CompiladorBuz ";
            openFileDialog.Filter = "Archivos CBuz#(*.Buz)|*.Buz";
            if (openFileDialog.ShowDialog() == true)
                txtB.Text = File.ReadAllText(openFileDialog.FileName);
        }
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = " Abrir archivo      -        CompiladorBuz ";
            saveFileDialog.Filter = "Archivos CBuz#(*.Buz)|*.Buz";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtB.Text);
        }

        //Metodo para scroll de ambos textbox y numeracion
        private void Proof(Object sender, ScrollChangedEventArgs e)
        {
            txtLines.ScrollToVerticalOffset(e.VerticalOffset);
            txtB.ScrollToVerticalOffset(e.VerticalOffset);
        }
        private void txtB_TextChanged(object sender, TextChangedEventArgs e)
        {
            AnalizadorSintactico();
            var linIzq = txtB.LineCount;
            // Comprobar cuál de los dos textBoxes tiene más líneas
            txtLines.Text = " ";
            for (var i = 1; i <= linIzq; i++)
                // Indentar el texto a la derecha
                txtLines.Text += i.ToString("0").PadLeft(4) + "\r";
        }

        //Analizador
        public void AnalizadorSintactico()
        {

            TokensData.Items.Clear();
            string[] linea = new string[txtB.LineCount];
            if (txtB.Text != null)
            {
                for(int i =0; i< linea.Length; i++)
                {
                   
                    linea[i] = txtB.GetLineText(i);
                    if (linea[i] != null)
                    {
                        if (Regex.IsMatch(linea[i], @"^(>int|>Entero)\s+\w+(\s+:\s+\d)*;(|\s)$"))
                        {
                            ImprimirToken(">int", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^(>double|>decimal)\s+\w+(\s+:\s+\d+\.+\d)*;(|\s)$"))
                        {
                            ImprimirToken(">double", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^>string|>texto\s+[a-z](1,15)(\s+:\s+[a-z](1,15)')*;$"))
                        {
                            ImprimirToken(">string", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^>bool|>Booleano\s+[a-z](1,15)(\s+:\s+(true|false))*;$"))
                        {
                            ImprimirToken(">bool", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"<<*.*>>+[\r\n]$"))
                        {
                            ImprimirToken("<<", i, linea[i].ToString());
                            ImprimirToken(">>", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"[a-z]\s+:+\s[a-z]|(\w)*\s\+\s(\w)*|\d(0,32000)*;+[\r\n]$"))
                        {
                            ImprimirToken(":", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^{+[\r\n]$"))
                        {
                            ImprimirToken("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @"^}|}+[\r\n]$")) 
                        {
                            ImprimirToken("}", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">si\(\w+\s(<|>|<:|>:|::|!:)\s+\w+\)\s\{+[\r\n]$"))
                        {
                            ImprimirToken(">si", i, linea[i].ToString());
                            ImprimirToken("{", i, linea[i].ToString());
                            ImprimirToken("(", i, linea[i].ToString());
                            ImprimirToken(")", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">sino\s*\{+[\r\n]$"))
                        {
                            ImprimirToken(">sino", i, linea[i].ToString());
                            ImprimirToken("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">print\((\w*)|'\w*'\);$"))
                        {
                            ImprimirToken(">print", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">class\s+\w+\s\{+[\r\n]$"))
                        {
                            ImprimirToken(">class", i, linea[i].ToString());
                            ImprimirToken("{", i, linea[i].ToString());
                        }
                        else if (Regex.IsMatch(linea[i], @">func\s+\w+\s\(+(\s?|\w)+\)\{+[\r\n]$"))
                        {
                            ImprimirToken(">func", i, linea[i].ToString());
                            ImprimirToken("(", i, linea[i].ToString());
                            ImprimirToken(")", i, linea[i].ToString());
                        }
                    }
                }
            }
            else
            {
                TokensData.Items.Clear();
            }
        }
       
        //Funcion para mostrar los tokens
        private void Mostrar_Click(object sender, RoutedEventArgs e)
        {
            VistaTokens.VistaTokens tk = new VistaTokens.VistaTokens();
            this.Hide();
            tk.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //Imprimir tokens en listview del editor
        public void ImprimirToken(string token, int i, string linea)
        {
            Tsimbolos.datos.Clear();
            dynamic datos = new List<Complete>();
            datos = Tsimbolos.BuscarToken(token, i, linea);
            foreach (var x in datos)
            {
                TokensData.Items.Add(x);
            }
        }
    }
}
