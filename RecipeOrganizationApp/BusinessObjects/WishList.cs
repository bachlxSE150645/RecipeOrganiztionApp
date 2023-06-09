﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class WishList
    {
        [Key][Required] public Guid WishListID { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        public Account? Account { get; set; }
    }
}
