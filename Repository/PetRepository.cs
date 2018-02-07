using System.Collections.Generic;
using System.Linq;
using MVC.Data;
using MVC.Models;

namespace MVC.Repository{

    public class PetRepository : IPetRepository
    {
        private ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Delete(Pet pet)
        {
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }

        public void Edit(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet GetSinglePet(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p=>p.Id == id);
            return pet;
        }
    }
}