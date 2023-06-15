﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Review
    {
        [Key][Required] public Guid ReviewID { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        [ForeignKey("Recipe")][Required] public Guid RecipeID { get; set; }
        public string ReviewContent { get; set; }
        public float Rating { get; set; }
        public Account Account { get; set; }
        public Recipe Recipe { get; set; }
    }
}