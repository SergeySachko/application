﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public bool IsEnabled { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<SubStatus> SubStatus { get; set; }

        public ApplicationUser()
        {
            SubStatus = new List<SubStatus>();
        }        
        
    }
}
