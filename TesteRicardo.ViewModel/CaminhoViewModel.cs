using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TesteRicardo.Model.Grafo;

namespace TesteRicardo.ViewModel
{
    public class CaminhoViewModel
    {
        public void TracarCaminho(string arquivo, string origem, string destino, StackPanel panel)
        {
            if (arquivo != String.Empty)
            {
                if (origem.Length == 1 || destino.Length == 1)
                {
                    Grafo grafo = new Grafo(false, arquivo);
                    GrafoCaminhoViewModel grafoCanvas = new GrafoCaminhoViewModel(grafo, 10.0, origem, destino);
                    panel.Children.Clear();
                    panel.Children.Add(grafoCanvas);
                    
                }
                else
                {
                    string valor = origem + " ou " + destino;
                    throw new ArgumentNullException("Vértice não pode ter como nome ", nameof(valor));
                }
            }
            else
            {
                
                throw new ArgumentNullException(@"Não está carregado um grafo.");
            }

        }
    }
}
