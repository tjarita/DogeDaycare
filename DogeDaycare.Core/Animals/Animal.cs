using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using DogeDaycare.Users;
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
    public class Animal : FullAuditedEntity<long>
    {
        public const int MaxNameLength = 128;

        public int TenantId { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; protected set; }

        [Required]
        public virtual User Owner { get; protected set; }
        
        public virtual float Age { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        /// <summary>
        /// Necessary for entity. Forces animal creation through <see cref="Create"/>.
        /// </summary>
        protected Animal()
        {

        }

        public static Animal Create(int tenantId, string name, User owner, float age)
        {
            var @animal = new Animal
            {
                TenantId = tenantId,
                Name = name,
                Owner = owner,
                Age = age
            };
            return @animal;
        }

        internal void Deactivate()
        {
            IsActive = false;
        }
    }
}

