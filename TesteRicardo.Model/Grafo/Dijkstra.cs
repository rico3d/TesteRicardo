using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRicardo.Model.Grafo
{
    public class Dijkstra
    {
        

        private ArrayList caminho;
        private Vertice origem;
        private Vertice vertice_alvo; //

        public void Monta(Grafo g, string strOrigem)
        {
            
          
            origem = g.get_vertice(strOrigem);

            SortedDictionary<string, Vertice> Q = new SortedDictionary<string, Vertice>();

            initialize_single_source(g, origem);

            Q = g.get_vertices();

            SortedDictionary<string, Vertice> S = new SortedDictionary<string, Vertice>();

            while (Q.Count > 0)
            {

                Vertice u = extract_min(Q);

                u.set_visitado(true);

                foreach (KeyValuePair<Vertice, double> v in u.get_adjacentes())
                {
                    if (v.Key.get_visitado() == true)
                    {
                        continue;
                    }
                    relax(u, v.Key);
                }
                add_S(u, S);
            }

            /* S tem os pesos finais de caminho mínimos a partir da fonte determinada, assim atualiza o grafo 
             * com os vértices atualizados*/
            g.set_vertices(S);

        }

        private void initialize_single_source(Grafo g, Vertice s)
        {
            foreach (KeyValuePair<string, Vertice> v in g.get_vertices())
            {
                v.Value.set_distancia(Double.MaxValue);
            }
            s.set_distancia(0);
        }

        private void relax(Vertice u, Vertice v)
        {

            double distancia = u.get_distancia() + u.get_peso(v);

            if (v.get_distancia() > distancia)
            {
                v.set_distancia(distancia);
                v.set_vertice_caminho_anterior(u);
                //Console.WriteLine("Atualizei a distância " + distancia + " do vértice " + u.get_id()  + " para o vértice " + v.get_id());
            }
            else
            {
                //Console.WriteLine("NÃO atualizei a distância " + distancia + " do vértice " + u.get_id() + " para o vértice " + v.get_id());
            }
        }

        static Vertice extract_min(SortedDictionary<string, Vertice> Q)
        {
            var key = Q.Keys.ToList()[0];
            Vertice min = Q[key];
            foreach (KeyValuePair<string, Vertice> v in Q)
            {
                if (v.Value.get_distancia() < min.get_distancia())
                {
                    min = v.Value;
                }
            }
            Q.Remove(min.get_id());
            return min;
        }

        static void add_S(Vertice u, SortedDictionary<string, Vertice> S)
        {
            Vertice vertice;
            if (S.TryGetValue(u.get_id(), out vertice))
            {
                vertice = u;
            }
            else
            {
                S.Add(u.get_id(), u);
            }
        }



    }
}
