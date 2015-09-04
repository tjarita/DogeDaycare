using Abp.Domain.Entities;
using DogeDaycare.Humans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public class Animal : Entity<Guid>
    {
        public virtual string Name { get; set; }
        [ForeignKey("IdOwner")]
        public virtual Person Owner { get; set; }
        public virtual Guid? IdOwner { get; set; }
        public virtual Guid IdAnimal { get; set; }
        public virtual DateTime RegisteredTime { get; set; }
        
        public Animal()
        {
            RegisteredTime = DateTime.Now;
            IdAnimal = Guid.NewGuid();
        }

    }
}
