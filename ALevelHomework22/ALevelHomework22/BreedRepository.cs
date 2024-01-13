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
    public class BreedRepository
    {
        private readonly ApplicationDbContext _context;

        public BreedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBreedAsync(BreedEntity breed)
        {
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();
        }

        public async Task<BreedEntity> GetBreedByIdAsync(int breedId)
        {
            return await _context.Breeds.FindAsync(breedId);
        }

        public async Task<List<BreedEntity>> GetAllBreedsAsync()
        {
            return await _context.Breeds.ToListAsync();
        }

        public async Task UpdateBreedAsync(BreedEntity breed)
        {
            _context.Breeds.Update(breed);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBreedAsync(int breedId)
        {
            var breed = await GetBreedByIdAsync(breedId);
            if (breed != null)
            {
                _context.Breeds.Remove(breed);
                await _context.SaveChangesAsync();
            }
        }
    }
}
