using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Account
    {
        [Key][Required] public Guid AccountID { get; set; }
        [MaxLength(50)] public string? UserName { get; set; }
        [MaxLength(50)] public string? Password { get; set; }
        [ForeignKey("Role")][Required] public Guid RoleID { get; set; }
        [MaxLength(50)] public string? Email { get; set; }
        [MaxLength(15)] public string? Phone { get; set; }
        [Required] public bool Status { get; set; }

        public Role Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        [JsonIgnore]
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        [JsonIgnore]
        public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();

    }
}
