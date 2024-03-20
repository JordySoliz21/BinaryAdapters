using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdapters
{
    public interface ICarroRepository
    {
        Carro GetCarro(int id);
        IEnumerable<Carro> GetAll();
        void Add(Carro carro);
        void Update(Carro carro);
        void Delete(int Id);
    }
}
