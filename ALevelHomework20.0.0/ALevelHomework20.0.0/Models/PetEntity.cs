using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ALevelHomework20._0._0.Models;

namespace ALevelHomework20._0._0.Models
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BreedId { get; set; }
        public float Age { get; set; }
        public int LocationId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;

        public CategoryEntity Category { get; set; } = null!;
        public BreedEntity Breed { get; set; } = null!;
        public LocationEntity Location { get; set; } = null!;
    }
}
