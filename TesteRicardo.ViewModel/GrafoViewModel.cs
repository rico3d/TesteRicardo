using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using TesteRicardo.Model.Grafo;

namespace TesteRicardo.ViewModel
{
    public class GrafoViewModel : Canvas
    {
       
        protected Grafo _grafo;
        protected double _escala;
        protected double _xInicial;
        protected double _yInicial;
        protected double[] _pivot;

            public GrafoViewModel(Grafo grafo, double escala) : base()
            {
                _grafo = grafo;
                _escala = escala;
                _pivot = EncontraPivot();
                _xInicial = 50;
                _yInicial = 50;
            }

            protected override void OnRender(DrawingContext dc)
            {

                draw_arestas(dc);
                drawVertices(dc);

            }

            double[] EncontraPivot()
            {
                double xNegMax = 0.0;
                double yNegMax = 0.0;

                var vertices = _grafo.get_vertices();

                foreach (var vertice in vertices)
                {
                    var coordenada = vertice.Value.get_coordenada();
                    var xCapture = coordenada[0];
                    if (xCapture < 0)
                    {
                        if (Math.Abs(xCapture) > Math.Abs(xNegMax))
                        {
                            xNegMax = xCapture;
                        }
                    }

                    var yCapture = coordenada[1];
                    if (yCapture < 0)
                    {
                        if (Math.Abs(yCapture) > Math.Abs(yNegMax))
                        {
                            yNegMax = yCapture;
                        }
                    }


                }

                return new double[] {Math.Abs(xNegMax), Math.Abs(yNegMax)};

            }

            void drawVertices(DrawingContext dc)
            {
                var vertices = _grafo.get_vertices();

                foreach (var vertice in vertices)
                {
                    var texto = vertice.Key;
                    var coordenada = vertice.Value.get_coordenada();
                    var x = (coordenada[0] + _pivot[0]) * _escala + _xInicial;
                    var y = (coordenada[1] + _pivot[1]) * _escala + _yInicial;
                    drawVertice(dc, texto, x, y);
                }


            }

            public virtual void draw_arestas(DrawingContext dc)
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

                    dc.DrawLine(new Pen(Brushes.Black, 2), new Point(xIni, yIni), new Point(xFim, yFim));
                }

            }







            void drawVertice(DrawingContext dc, string texto, double coordenadaX, double coordenadaY)
            {
                double raio = 11;


                dc.DrawEllipse(Brushes.Aqua,
                    new Pen(Brushes.Black, 2),
                    new Point(coordenadaX, coordenadaY),
                    raio,
                    raio);

                FormattedText formattedText = new FormattedText(
                    texto,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    FlowDirection.LeftToRight,
                    new Typeface("Verdana"),
                    16,
                    Brushes.Black);

                dc.DrawText(formattedText, new Point(coordenadaX - raio * 0.5, coordenadaY - raio));
            }


            //void draw_arestas(DrawingContext dc)
            //{

            //    PathFigure pathFigure = new PathFigure();
            //    pathFigure.StartPoint = new Point(0, 0);
            //    //pathFigure.IsClosed = true;
            //    var arestas = _grafo.get_arestas();
            //    for (int i = 0; i < arestas.Count; i++)
            //    {
            //        var coordenada = arestas[i].Item1.get_coordenada();
            //        var x = coordenada[0] * _escala + _xInicial;
            //        var y = coordenada[1] * _escala + _yInicial;
            //        pathFigure.Segments.Add(new LineSegment(new Point(x, y), true));



            //        //drawVertice(dc, arestas[i].Item1.get_id(), x, y);

            //        coordenada = arestas[i].Item2.get_coordenada();
            //        x = coordenada[0] * _escala + _xInicial;
            //        y = coordenada[1] * _escala + _yInicial;
            //        pathFigure.Segments.Add(new LineSegment(new Point(x, y), true));

            //        //drawVertice(dc, arestas[i].Item1.get_id(), x, y);




            //    }

            //    //pathFigure.Segments.Add(new LineSegment(new Point(0, 200), true));
            //    //pathFigure.Segments.Add(new LineSegment(new Point(200, 200), true));


            //    PathGeometry geometry = new PathGeometry();
            //    geometry.Figures.Add(pathFigure);

            //    dc.DrawGeometry(Brushes.White,
            //        new Pen(Brushes.Black, 2), geometry);



            //}





        
    }
}
