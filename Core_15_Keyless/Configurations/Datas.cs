using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_15_Keyless.Configurations
{
    public class PersonData : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(new Person[]
            {
              new(){ PersonId  = 1, Name = "Ayşe" },
              new(){ PersonId  = 2, Name = "Hilmi" },
              new(){ PersonId  = 3, Name = "Raziye" },
              new(){ PersonId  = 4, Name = "Süleyman" },
              new(){ PersonId  = 5, Name = "Fadime" },
              new(){ PersonId  = 6, Name = "Şuayip" },
              new(){ PersonId  = 7, Name = "Lale" },
              new(){ PersonId  = 8, Name = "Jale" },
              new(){ PersonId  = 9, Name = "Rıfkı" },
              new(){ PersonId  = 10, Name = "Muaviye" },
            });
        }   
    }
    public class OrderData : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order[]
            {
              new(){ OrderId = 1, PersonId = 1, Description = "...", Price=11},
              new(){ OrderId = 2, PersonId = 2, Description = "...", Price=15},
              new(){ OrderId = 3, PersonId = 4, Description = "...", Price=13},
              new(){ OrderId = 4, PersonId = 5, Description = "...", Price=17},
              new(){ OrderId = 5, PersonId = 1, Description = "...", Price=19},
              new(){ OrderId = 6, PersonId = 6, Description = "...", Price=12},
              new(){ OrderId = 7, PersonId = 7, Description = "...", Price=16},
              new(){ OrderId = 8, PersonId = 1, Description = "...", Price=14},
              new(){ OrderId = 9, PersonId = 8, Description = "...", Price=16},
              new(){ OrderId = 10, PersonId = 9, Description = "...", Price=14},
              new(){ OrderId = 11, PersonId = 1, Description = "...", Price=14},
              new(){ OrderId = 12, PersonId = 2, Description = "...", Price=17},
              new(){ OrderId = 13, PersonId = 2, Description = "...", Price=11},
              new(){ OrderId = 14, PersonId = 3, Description = "...", Price=10},
              new(){ OrderId = 15, PersonId = 1, Description = "...", Price=19},
              new(){ OrderId = 16, PersonId = 4, Description = "...", Price=15},
              new(){ OrderId = 17, PersonId = 1, Description = "...", Price=17},
              new(){ OrderId = 18, PersonId = 1, Description = "...", Price=19},
              new(){ OrderId = 19, PersonId = 5, Description = "...", Price=13},
              new(){ OrderId = 20, PersonId = 6, Description = "...", Price=15},
              new(){ OrderId = 21, PersonId = 1, Description = "...", Price=16},
              new(){ OrderId = 22, PersonId = 7, Description = "...", Price=17},
              new(){ OrderId = 23, PersonId = 7, Description = "...", Price=19},
              new(){ OrderId = 24, PersonId = 8, Description = "...", Price=13},
              new(){ OrderId = 25, PersonId = 1, Description = "...", Price=12},
              new(){ OrderId = 26, PersonId = 1, Description = "...", Price=15},
              new(){ OrderId = 27, PersonId = 9, Description = "...", Price=14},
              new(){ OrderId = 28, PersonId = 9, Description = "...", Price=17},
              new(){ OrderId = 29, PersonId = 9, Description = "...", Price=12},
              new(){ OrderId = 30, PersonId = 2, Description = "...", Price=14},
              new(){ OrderId = 31, PersonId = 3, Description = "...", Price=17},
              new(){ OrderId = 32, PersonId = 1, Description = "...", Price=18},
              new(){ OrderId = 33, PersonId = 1, Description = "...", Price=18},
              new(){ OrderId = 34, PersonId = 1, Description = "...", Price=14},
              new(){ OrderId = 35, PersonId = 5, Description = "...", Price=19},
              new(){ OrderId = 36, PersonId = 1, Description = "...", Price=12},
              new(){ OrderId = 37, PersonId = 5, Description = "...", Price=14},
              new(){ OrderId = 38, PersonId = 1, Description = "...", Price=12},
              new(){ OrderId = 39, PersonId = 1, Description = "...", Price=11},
              new(){ OrderId = 40, PersonId = 1, Description = "...", Price=13},
            });
        }
    }
}
