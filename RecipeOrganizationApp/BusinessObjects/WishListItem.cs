﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [PrimaryKey(nameof(RecipeID), nameof(WishListID))]
    public class WishListItem
    {
        [ForeignKey("WishList")]
        [Required] public Guid WishListID { get; set; }
        [ForeignKey("Recipe")]
        [Required] public Guid RecipeID { get; set; }
        
        [JsonIgnore]
        public WishList WishList { get; set; }
        public Recipe Recipe { get; set; }
    }
}
