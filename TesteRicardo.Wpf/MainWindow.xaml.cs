using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using TesteRicardo.ViewModel;

//using TesteRicardo.ViewModel;

namespace TesteRicardo.Wpf
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _arquivoJason;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Trabalho\TestePromob\JSONs";
            openFileDialog.Filter = "Text files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                
                _arquivoJason = openFileDialog.FileName;
                btnOpenFile.Content = _arquivoJason;
                BrowserJsonViewModel browser = new BrowserJsonViewModel();
                browser.PegaArquivo(_arquivoJason, stack_panel);
            }
            else
            {
                _arquivoJason = String.Empty;
            }
        }


        private void btnCaminho_Click(object sender, RoutedEventArgs e)
        {
                string origem = txtBoxOrigem.Text;
                string destino = txtBoxDestino.Text;
                CaminhoViewModel caminho = new CaminhoViewModel();

                caminho.TracarCaminho(_arquivoJason, origem, destino, stack_panel);
           
        }

        private void BtnTriangulo_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
