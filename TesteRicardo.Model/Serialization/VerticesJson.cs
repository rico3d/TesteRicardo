using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TesteRicardo.Model.Serialization
{
    public class VerticesJson
    {
        public List<VerticeJson> ListaVertices(string enderecoArquivo)
        {
            //List<Vertice> listaVertices = new List<Vertice>();
            var json = File.ReadAllText(enderecoArquivo);

            var listaVertices = JsonConvert.DeserializeObject <List<VerticeJson>>(json);

            return listaVertices;
        }
    }
}
