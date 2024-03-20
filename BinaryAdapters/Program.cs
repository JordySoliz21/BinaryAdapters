using BinaryAdapters;
using System;

string filePath = "people.bin";

ICarroRepository carroRepository = new CarroBinaryRepository(filePath);

// Agregar algunas personas 
carroRepository.Add(new Carro { Marca = "BMW", Modelo = "X5" });
carroRepository.Add(new Carro { Marca = "Toyota", Modelo = "Corolla" });
carroRepository.Add(new Carro { Marca = "Mercedez-Benz", Modelo = "E-Class" });
carroRepository.Add(new Carro { Marca = "Ford", Modelo = "Mustang" });
carroRepository.Add(new Carro { Marca = "Volkswagen", Modelo = "Golf" });

Console.WriteLine($"Datos de personas guardados en {filePath} ");
foreach (Carro carro in carroRepository.GetAll())
    Console.WriteLine($"Id: {carro.Id}, Marca: {carro.Marca}, Modelo: {carro.Modelo}");