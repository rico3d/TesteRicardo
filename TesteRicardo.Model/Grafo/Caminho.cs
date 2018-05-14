using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRicardo.Model.Serialization;

namespace TesteRicardo.Model.Grafo
{
    public class Caminho
    {

       

        


        public List<string> calcula_caminho(Vertice alvo)
        {
            List<string> resultado = new List<string>();
            ArrayList caminho = new ArrayList();

            if (caminho.Count == 0)
            {
                caminho.Add(alvo);
            }
            while (alvo.get_vertice_caminho_anterior() != null)
            {
                caminho.Add(alvo.get_vertice_caminho_anterior());
                alvo = alvo.get_vertice_caminho_anterior();
            }

            if (caminho.Count > 0)
            {
                foreach (var item in caminho)
                {
                    var vertice = item as Vertice;
                    resultado.Add(vertice.get_id());
                }
               return resultado; //imprime_caminho(caminho, origem, vertice_alvo);
            }
            else
            {
                return null;
            }

        }
    }
}
