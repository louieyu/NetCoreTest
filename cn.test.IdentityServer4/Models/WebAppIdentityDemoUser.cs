using System;
using Microsoft.AspNetCore.Identity;

namespace cn.test.IdentityServer4.Models
{
    public class WebAppIdentityDemoUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
