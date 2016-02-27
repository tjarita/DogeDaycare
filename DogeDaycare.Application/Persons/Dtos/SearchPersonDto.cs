using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons.Dtos
{
    public class SearchPersonDto : IInputDto
    {
        private string _fName;
        private string _lName;

        public string FName
        {
            get { return _fName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _fName = ".*";
                else
                    _fName = value;
            }
        }
        public string LName {
            get { return _lName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _lName = ".*";
                else
                    _lName = value;
            }
        }
    }
}
