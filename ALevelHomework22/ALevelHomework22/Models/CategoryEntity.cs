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
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
        public List<BreedEntity> Breeds { get; set; } = new List<BreedEntity>();
    }
}
