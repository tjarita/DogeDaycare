using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public class Animal : Entity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual Guid IdOwner { get; set; }
        public virtual Guid IdAnimal { get; set; }
        public virtual DateTime RegisteredTime { get; set; }
        public void bark(){Name = "bark";}


        public Animal()
        {
            RegisteredTime = DateTime.Now;
            IdAnimal = Guid.NewGuid();
        }

    }
}
