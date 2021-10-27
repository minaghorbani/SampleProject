﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
