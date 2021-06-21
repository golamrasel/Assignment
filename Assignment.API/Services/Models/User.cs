using Microsoft.AspNetCore.Identity;
using System;

namespace Services.models
{
    public class User: IdentityUser
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
