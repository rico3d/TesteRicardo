using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRicardo.Model.Grafo
{
    public class Euler
    {
        private Grafo _grafo;
        
        public Euler(Grafo grafo)
        {
            _grafo = grafo;
        }

        public bool IsPossible()
        {
            int contador = 0; 
            
            var vertices = _grafo.get_vertices();

            foreach (var vertice in vertices)
            {
                if (vertice.Value.get_adjacentes().Count % 2 != 0)
                {
                    contador++;
                }
            }

            if (contador == 0 || contador == 2)
                return true;
            else
                return false;

            
        }

        
    }
}
