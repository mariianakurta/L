using ALevelHomework20._0._0.Configurations;
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

public class PetService
{
    private readonly PetRepository _petRepository;
    private readonly LocationRepository _locationRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly BreedRepository _breedRepository;

    public PetService(
        PetRepository petRepository,
        LocationRepository locationRepository,
        CategoryRepository categoryRepository,
        BreedRepository breedRepository)
    {
        _petRepository = petRepository;
        _locationRepository = locationRepository;
        _categoryRepository = categoryRepository;
        _breedRepository = breedRepository;
    }
    public async Task<List<GroupedPetResult>> GroupPetsByCategoryAndBreedAsync()
    {
        var pets = await _petRepository.GetAllPetsAsync();

        var result = pets
            .Where(p => p.Age > 3 && p.Location.LocationName == "Ukraine")
            .GroupBy(p => new { CategoryName = p.Category.CategoryName })
            .Select(g => new GroupedPetResult
            {
                CategoryName = g.Key.CategoryName,
                BreedCount = g.Select(p => p.Breed.BreedName).Distinct().Count()
            })
            .ToList();

        return result;
    }
}

public class GroupedPetResult
{
    public string CategoryName { get; set; }
    public int BreedCount { get; set; }
}
