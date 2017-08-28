using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ZooFeeding.Models;

namespace ZooFeeding.DAL
{
    public class AnimalRepository : IAnimalRepository, IDisposable
    {
        private ZooContext context;

        public AnimalRepository(ZooContext context)
        {
            this.context = context;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return context.Animals.ToList();
        }

        public Animal GetAnimalByID(int id)
        {
            return context.Animals.Find(id);
        }

        public void InsertAnimal(Animal animal)
        {
            context.Animals.Add(animal);
        }

        public void DeleteAnimal(int animalID)
        {
            Animal animal = context.Animals.Find(animalID);
            context.Animals.Remove(animal);
        }

        public void UpdateAnimal(Animal animal)
        {
            context.Entry(animal).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}