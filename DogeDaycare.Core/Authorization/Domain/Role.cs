﻿using Abp.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Authorization
{
    public class Role : AbpRole<Tenant,User>
    {
    }
}
