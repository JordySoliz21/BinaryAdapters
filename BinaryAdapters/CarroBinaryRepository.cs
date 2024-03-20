using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryAdapters
{
    public class CarroBinaryRepository : ICarroRepository
    {
        private string _filePath;
        public CarroBinaryRepository (string filePath)
        {
            _filePath = filePath;
        }
        public void Add(Carro carro)
        {
            List<Carro> cars = GetAll().ToList();
            carro.Id = cars.Count > 0 ? cars.Max(p => p.Id) + 1 : 1;
            cars.Add(carro);

            SaveCars(cars);
        }

        private void SaveCars(List<Carro> cars)
        {
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Create))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (Carro carro in cars)
                    {
                        bw.Write(carro.Id);
                        bw.Write(carro.Modelo);
                        bw.Write(carro.Marca);
                    }

                    bw.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar carros: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            List<Carro> cars = GetAll().ToList();
            cars.RemoveAll(p => p.Id == id);
            SaveCars(cars);
        }

        public IEnumerable<Carro> GetAll()
        {
            if (!File.Exists(_filePath))
                return Enumerable.Empty<Carro>();

            List<Carro> cars = new List<Carro>();
            try
            {
                using (FileStream fs = new FileStream(_filePath, FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        int id = br.ReadInt32();
                        string marca = br.ReadString();
                        string modelo = br.ReadString();
                        cars.Add(new Carro(id, marca, modelo));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los carros: {ex.Message}");
            }

            return cars;
        }

        public Carro GetCarro(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public void Update(Carro carro)
        {
            List<Carro> cars = GetAll().ToList();
            int index = cars.FindIndex(p => p.Id == carro.Id);
            if (index == -1)
            {
                cars[index] = carro;
                SaveCars(cars);
            }
            else
            {
                throw new ArgumentException("Carro no encontrado");
            }
        }
    }
}
