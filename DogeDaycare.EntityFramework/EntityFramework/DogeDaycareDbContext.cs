﻿using System.Data.Common;
using Abp.Zero.EntityFramework;
using DogeDaycare.Authorization.Roles;
using DogeDaycare.MultiTenancy;
using DogeDaycare.Users;
using System.Data.Entity;

namespace DogeDaycare.EntityFramework
{
    public class DogeDaycareDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public virtual IDbSet<Animals.Animal> Animals { get; set; }
        public virtual IDbSet<Appointments.Appointment> Appointments { get; set; }
        public virtual IDbSet<Emails.EmailTemplate> EmailTemplates { get; set; }
        //public virtual IDbSet<Persons.Person> Persons{ get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public DogeDaycareDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in DogeDaycareDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of DogeDaycareDbContext since ABP automatically handles it.
         */
        public DogeDaycareDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public DogeDaycareDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
