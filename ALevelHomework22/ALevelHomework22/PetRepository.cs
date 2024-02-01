using ALevelHomework20._0._0.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ALevelHomework20._0._0.Models;
using ALevelHomework20._0._0.Data;

namespace ALevelHomework20._0._0.Configurations
{
    public class PetRepository
    {
        private readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePetAsync(PetEntity pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<PetEntity> GetPetByIdAsync(int petId)
        {
            return await _context.Pets.FindAsync(petId);
        }

        public async Task<List<PetEntity>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task UpdatePetAsync(PetEntity pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int petId)
        {
            var pet = await GetPetByIdAsync(petId);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
