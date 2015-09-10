using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons.Dtos
{
    public class CreatePersonInput
    {
        [Required]
        public Guid IdPerson { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
