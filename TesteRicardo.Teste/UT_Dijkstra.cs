using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteRicardo.Model.Grafo;
using TesteRicardo.Model.Serialization;

namespace TesteRicardo.Teste
{
    [TestClass]
    public class UT_Dijkstra
    {

        [TestMethod]
        public void TesteSerialization()
        {
            //arrange:
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
            var vertices = new VerticesJson();

            //act:
            var listaVertices = vertices.ListaVertices(pastaArquivo + @"\" + nomeArquivo);

            //assert:
            Assert.IsNotNull(listaVertices);
           


        }



        [TestMethod]
        public void TesteGrafo()
        {
            //arrange:
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
         

            string id = "A";

            //act:
            Grafo grafo = new Grafo(false, pastaArquivo + @"\" + nomeArquivo);

            //assert:
            Assert.IsNotNull(grafo);
           
        }

        [TestMethod]
        public void Teste_Dijkstra()
        {
            //arrange:
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
            Grafo grafo = new Grafo(false, pastaArquivo + @"\" + nomeArquivo);
            string origem = "A";

            //act:
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Monta(grafo, origem);

            //assert:
            Assert.IsNotNull(grafo);


        }

        [TestMethod]
        public void Teste_Caminho()
        {
            //arrange:
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
            Grafo grafo = new Grafo(false, pastaArquivo + @"\" + nomeArquivo);
            string origem = "A";
            string destino = "C";
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.Monta(grafo, origem);
            string dist = "30";

            //act:
            Caminho caminho = new Caminho();
            List<string> listaCaminho = caminho.calcula_caminho(grafo.get_vertice(destino));


            //assert:
            Assert.IsNotNull(listaCaminho);
            Assert.AreEqual(grafo.get_vertice(destino).get_distancia().ToString("0"),"30");
        }

        [TestMethod]
        public void Teste_EulerPossivel()
        {
            //arrange:
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
            Grafo grafo = new Grafo(false, pastaArquivo + @"\" + nomeArquivo);
            bool possivel = true;

            //act:
            Euler euler = new Euler(grafo);
            var teste = euler.IsPossible();

            //assert:
            Assert.IsNotNull(euler);
            Assert.AreEqual(possivel,teste);

        }

        [TestMethod]
        public void Teste_Triangulo()
        {
            string pastaArquivo = @"C:\Trabalho\TestePromob\JSONs";
            string nomeArquivo = "Grafo1.json";
            Grafo grafo = new Grafo(false, pastaArquivo + @"\" + nomeArquivo);
        }


    }
}
