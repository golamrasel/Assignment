using Microsoft.AspNetCore.Identity;
using System;

namespace Context.models
{
    public class User: IdentityUser
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
