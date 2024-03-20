using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryAdapters
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public Carro()
        {
            AsignarValoresPredeterminados(0, string.Empty, string.Empty);
        }

        public Carro(int id, string modelo, string marca)
        {
            AsignarValoresPredeterminados(id, modelo, marca);
        }

        private void AsignarValoresPredeterminados(int id, string modelo, string marca)
        {
            Id = id;
            Modelo = modelo;
            Marca = marca;
        }
    }
}
