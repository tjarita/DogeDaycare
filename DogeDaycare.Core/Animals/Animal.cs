using Abp.Domain.Entities;
using DogeDaycare.Persons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    /// <summary>
    /// Core animal model
    /// </summary>
    [Table("Animals")]
    public class Animal : Entity<Guid>
    {
        public virtual string Name { get; set; }
        //Marked JsonIgnore to avoid Entity Framework's lazy load serialization.
        [JsonIgnore]
        public Person Owner { get; set; }
        public virtual DateTime RegisteredTime { get; set; }
        
        public Animal()
        {
            Id = Guid.NewGuid();
            RegisteredTime = DateTime.Now;
        }

    }
}
