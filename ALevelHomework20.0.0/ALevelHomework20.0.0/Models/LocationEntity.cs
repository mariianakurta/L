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
    public class LocationEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; } = null!;

        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}
