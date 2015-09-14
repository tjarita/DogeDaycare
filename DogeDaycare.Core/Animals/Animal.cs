using Abp.Domain.Entities;
using DogeDaycare.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    [Table("Animals")]
    public class Animal : Entity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual Person Owner { get; set; }
        public virtual DateTime RegisteredTime { get; set; }
        
        public Animal()
        {
            Id = Guid.NewGuid();
            RegisteredTime = DateTime.Now;
        }

    }
}
