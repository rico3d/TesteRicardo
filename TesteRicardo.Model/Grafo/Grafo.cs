using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRicardo.Model.Serialization;

namespace TesteRicardo.Model.Grafo
{
    public class Grafo
    {
        private SortedDictionary<string, Vertice> _vertices;
        private Boolean _direcionado = false;
        private List<VerticeJson> _listaVerticesJson;


        public Grafo(Boolean direcionado, string nomeArquivo)
        {
            var verticesJson = new VerticesJson();
            _listaVerticesJson = verticesJson.ListaVertices(nomeArquivo);
            _vertices = new SortedDictionary<string, Vertice>();
            _direcionado = direcionado;
            inserir_vertices();
            inserir_arestas();
        }

        

        private void inserir_vertices()
        {
            for (int i = 0; i < _listaVerticesJson.Count; i++)
            {
                inserir_vertice(_listaVerticesJson[i].Name, _listaVerticesJson[i].Coordenates);
            }
        }

        private void inserir_arestas()
        {
            for (int i = 0; i < _listaVerticesJson.Count; i++)
            {
                if ((i + 1) < _listaVerticesJson.Count)
                {
                    double distancia = calculaPeso(
                        _vertices[_listaVerticesJson[i].Name].get_coordenada(), 
                        _vertices[_listaVerticesJson[i + 1].Name].get_coordenada());

                    inserir_aresta(_listaVerticesJson[i].Name, _listaVerticesJson[i + 1].Name, distancia);
                }
            }
        }

        

        private void inserir_vertice(string id, string strCoordenada)
        {
            Vertice v = new Vertice(id, strCoordenada);
            _vertices[id] = v;
        }

        public void inserir_aresta(string de, string para, double peso)
        {


            Vertice p = _vertices[para];
            Vertice d = _vertices[de];

            

            _vertices[de].inserir_vertice_adjacente(p, peso);
            if (!_direcionado)
            {
                _vertices[para].inserir_vertice_adjacente(d, peso);
            }
        }

        private double calculaPeso(double[] pontoPara, double[] pontoDe)
        {
            var culture = new System.Globalization.CultureInfo("en-US");

            var peso = Math.Sqrt(Math.Pow((pontoPara[0] - pontoDe[0]), 2) + Math.Pow((pontoPara[1] - pontoDe[1]),2));

            return peso;
        }

        public List<Tuple<Vertice, Vertice>> get_arestas()
        {
            List<Tuple<Vertice, Vertice>> arestas = new List<Tuple<Vertice, Vertice>>();
            foreach (KeyValuePair<string, Vertice> u in _vertices)
            {
                foreach (KeyValuePair<Vertice, double> v in u.Value.get_adjacentes())
                {
                    arestas.Add(Tuple.Create(u.Value, v.Key));
                }
            }
            return arestas;
        }

        public Vertice get_vertice(string vertice)
        {
            if (_vertices.ContainsKey(vertice))
            {
                return _vertices[vertice];
            }
            else
            {
                return null;
            }
        }
        public SortedDictionary<string, Vertice> get_vertices()
        {
            return _vertices;
        }

        public void set_vertices(SortedDictionary<string, Vertice> vs)
        {
            _vertices = vs;
        }
    }
}
