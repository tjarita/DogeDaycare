using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Persons
{
    [Table("Addresses")]
    public class Address
    {
        /// <summary>
        /// Street address, P.O. box, company name, c/o (care of)
        /// </summary>
        public virtual string Address1 { get; set; }
        /// <summary>
        /// Apartment, suite, unit, building, floor, etc
        /// </summary>
        public virtual string Address2 { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// State / Province / Region
        /// </summary>
        public virtual string State { get; set; }
        /// <summary>
        /// Zip / Postal
        /// </summary>
        public virtual string Zip { get; set; }

    }
}
