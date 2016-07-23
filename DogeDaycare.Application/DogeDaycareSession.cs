using Abp.MultiTenancy;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare
{
    public class DogeDaycareSession : IAbpSession
    {
        public long? UserId {get;set;}
        public int? TenantId { get; set; }
        public MultiTenancySides MultiTenancySide { get; set; }
        //
        // Summary:
        //     TenantId of the impersonator. This is filled if a user with Abp.Runtime.Session.IAbpSession.ImpersonatorUserId
        //     performing actions behalf of the Abp.Runtime.Session.IAbpSession.UserId.
        public int? ImpersonatorTenantId { get; }
        //
        // Summary:
        //     UserId of the impersonator. This is filled if a user is performing actions behalf
        //     of the Abp.Runtime.Session.IAbpSession.UserId.
        public long? ImpersonatorUserId { get; }


    }   
}
