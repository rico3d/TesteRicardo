using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TesteRicardo.Model.Grafo;

namespace TesteRicardo.ViewModel
{
    public class BrowserJsonViewModel:Window
    {
        public void PegaArquivo(string arquivo, StackPanel panel)
        {
            Grafo grafo = new Grafo(false, arquivo);
            GrafoViewModel grafoCanvas = new GrafoViewModel(grafo, 10.0);
            panel.Children.Clear();
            panel.Children.Add(grafoCanvas);
        }
    }
}
