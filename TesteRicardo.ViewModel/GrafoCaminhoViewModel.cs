using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TesteRicardo.Model.Grafo;

namespace TesteRicardo.ViewModel
{
    public class GrafoCaminhoViewModel:GrafoViewModel
    {
        private string _origem;
        private string _destino;
        private List<string> _listaCaminho;
        private string _custo;


        public GrafoCaminhoViewModel(Grafo grafo, double escala, string origem, string destino) : base(grafo, escala)
        {
            _origem = origem;
            _destino = destino;
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Monta(grafo, origem);
            Caminho caminho = new Caminho();
            _listaCaminho = caminho.calcula_caminho(grafo.get_vertice(destino));
            _custo = grafo.get_vertice(destino).get_distancia().ToString("0.00");
        }

        public string Custo
        {
            get { return _custo; }
        }

        public override void draw_arestas(DrawingContext dc)
        {
            
            var arestas = _grafo.get_arestas();

            foreach (var aresta in arestas)
            {
                

                var nome1 = aresta.Item1.get_id();
                var coordenada = aresta.Item1.get_coordenada();
                var xIni = (coordenada[0] + _pivot[0]) * _escala + _xInicial;
                var yIni = (coordenada[1] + _pivot[1]) * _escala + _yInicial;

                var nome2 = aresta.Item2.get_id();
                coordenada = aresta.Item2.get_coordenada();
                var xFim = (coordenada[0] + _pivot[0]) * _escala + _xInicial;
                var yFim = (coordenada[1] + _pivot[1]) * _escala + _yInicial;

                if(_listaCaminho.ToArray().Contains(nome1) && _listaCaminho.ToArray().Contains(nome2))
                {
                    dc.DrawLine(new Pen(Brushes.Red, 2), new Point(xIni, yIni), new Point(xFim, yFim));
                }
                else
                {
                    dc.DrawLine(new Pen(Brushes.Black, 2), new Point(xIni, yIni), new Point(xFim, yFim));
                }
                
            }

            FormattedText formattedText = new FormattedText(
                "A distancia percorrida para este percurso é: " + _custo + "km",
                CultureInfo.GetCultureInfo("pt-BR"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                12,
                Brushes.Black);

            dc.DrawText(formattedText, new Point(10,10));
        }

        
    }
}
