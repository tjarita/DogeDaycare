using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Animals
{
    public interface IAnimal
    {
        string Name { get; set; }
        Users.User Owner{ get; set; }
    }
}
