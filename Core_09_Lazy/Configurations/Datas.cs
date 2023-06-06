using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Core_09_Lazy.Configurations
{
    internal class EmployeeData : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(new Employee[]
            {
            new() {Id =1,RegionId=1, Name = "Ali", Surname = "Can", Salary=300},
            new() {Id =2,RegionId=2, Name = "Veli", Surname = "Melek", Salary=400},
            new() {Id =3,RegionId=1, Name = "Hasan", Surname = "Kale", Salary=500},
            new() {Id =4,RegionId=1, Name = "Murat", Surname = "Göl", Salary=300},
            new() {Id =5,RegionId=2, Name = "Osman", Surname = "Kara", Salary=700},
            new() {Id =6,RegionId=2, Name = "Slm", Surname = "Uzun", Salary=600},
            new() {Id =7,RegionId=1, Name = "İlhami", Surname = "Kar", Salary=300},
            new() {Id =8,RegionId=2, Name = "Ayşe", Surname = "Cono", Salary=500},
            new() {Id =9,RegionId=1, Name = "Erşan", Surname = "Kum", Salary=400},
            new() {Id =10,RegionId=1,Name = "Elif", Surname = "Tarak", Salary=500}
            });
        }
    }

    internal class RegionData : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData(new Region[]
            {
            new() { Id = 1, Name = "Ankara", },
            new() { Id = 2, Name = "Samsun", }
            });
        }
    }

    internal class OrderData : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order[]
            {
            new() { Id = 1, EmployeeId = 1, OrderDate = DateTime.Now },
            new() { Id = 2, EmployeeId = 2, OrderDate = DateTime.Now },
            new() { Id = 3, EmployeeId = 3, OrderDate = DateTime.Now }            
            });
        }
    }

}
