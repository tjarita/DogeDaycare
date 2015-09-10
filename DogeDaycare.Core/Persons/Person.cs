using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    [Table("Persons")]
    public class Person : Entity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual List<Animals.Animal> Pets { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
            Pets = new List<Animals.Animal>();
        }

    }
}
