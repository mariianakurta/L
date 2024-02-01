using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework20._0._0.Models
{
    public class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; } = null!;
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; } = null!;
        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}
