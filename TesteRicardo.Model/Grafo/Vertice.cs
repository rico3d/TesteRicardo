using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRicardo.Model.Grafo
{
    public class Vertice
    {
        private string _id = String.Empty;
        private double[] _coordenada;
        private Dictionary<Vertice, double> adjacencias = new Dictionary<Vertice, double>();
        private double _distancia = 0;
        private Boolean _visitado = false;
        private Vertice _vertice_anterior = null;

        public Vertice(string id, string strCoordenada)
        {
            _id = id;
            var culture = new System.Globalization.CultureInfo("en-US");

            double x = Convert.ToDouble(strCoordenada.Split(',')[0], culture.NumberFormat);
            double y = Convert.ToDouble(strCoordenada.Split(',')[1], culture.NumberFormat);
            _coordenada = new[] {x, y};


        }

        public string get_id()
        {
            return _id;
        }

        public double[] get_coordenada()
        {
            return _coordenada;
        }

        public void inserir_vertice_adjacente(Vertice para, double peso)
        {
            adjacencias[para] = peso;
        }

        public Dictionary<Vertice, double> get_adjacentes()
        {
            var dicaux = adjacencias.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return dicaux;
        }

        public void set_distancia(double distancia)
        {
            _distancia = distancia;
        }

        public double get_distancia()
        {
            return _distancia;
        }

        public double get_peso(Vertice v)
        {
            return adjacencias[v];
        }

        public void set_visitado(Boolean visitado)
        {
            _visitado = visitado;
        }
        public Boolean get_visitado()
        {
            return _visitado;
        }

        public void set_vertice_caminho_anterior(Vertice v)
        {
            _vertice_anterior = v;
        }

        public Vertice get_vertice_caminho_anterior()
        {
            return _vertice_anterior;
        }

        
    }
}
