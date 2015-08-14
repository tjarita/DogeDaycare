using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DogeDaycare.Humans
{
    public class Person : Entity<Guid>
    {
        public virtual Guid IdPerson { get; set; }
        public virtual string Name { get; set; }



    }
}
