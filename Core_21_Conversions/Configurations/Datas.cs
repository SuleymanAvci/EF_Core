using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_21_Conversions.Configurations
{
    public class PersonData : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(new Person[]
            {
              new(){ Id  = 1, Name = "Ayşe"     ,Gender=Gender.Famele     ,Married=true},
              new(){ Id  = 2, Name = "Hilmi"    ,Gender=Gender.Male       ,Married=true},
              new(){ Id  = 3, Name = "Kaya"     ,Gender=Gender.Male       ,Married=false},
              new(){ Id  = 4, Name = "Süleyman" ,Gender=Gender.Male       ,Married=true},
              new(){ Id  = 5, Name = "Fadime"   ,Gender=Gender.Famele     ,Married=true},
              new(){ Id  = 6, Name = "Şuayip"   ,Gender=Gender.Male       ,Married=false},
              new(){ Id  = 7, Name = "Lale"     ,Gender=Gender.Famele     ,Married=true},
              new(){ Id  = 8, Name = "Jale"     ,Gender=Gender.Famele     ,Married=false},
              new(){ Id  = 9, Name = "Rıfkı"    ,Gender=Gender.Male       ,Married=false},
              new(){ Id  = 10, Name = "Hasan"   ,Gender=Gender.Male       ,Married=true}
            });
        }
    }
}
