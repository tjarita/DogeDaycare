using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogeDaycare.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DogeDaycare.Persons.Dtos;

namespace DogeDaycare.Persons.Tests
{
    [TestClass()]
    public class PersonAppServiceTests
    {
        [TestMethod()]
        public void SearchForPersonTest()
        {
            SearchPersonDto input = new SearchPersonDto();
            input.FName = "Toshiki";
            input.LName = "Arita";

            Assert.Fail();
        }
    }
}