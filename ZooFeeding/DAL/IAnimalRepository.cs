using System;
using System.Collections.Generic;
using ZooFeeding.Models;

namespace ZooFeeding.DAL
{
    public interface IAnimalRepository : IDisposable
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimalByID(int animalId);
        void InsertAnimal(Animal animal);
        void DeleteAnimal(int animalID);
        void UpdateAnimal(Animal animal);
        void Save();
    }
}