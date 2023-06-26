using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BusinessObjects
{
    public class Order
    {
        [Key][Required] public Guid OrderID { get;set; }
        [ForeignKey("Meal")][Required] public Guid MealID { get; set; }
        [ForeignKey("Account")][Required] public Guid AccountID { get; set; }
        [DataType(DataType.DateTime)] public DateTime? CreateDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        [MaxLength(10)][Required] public string Status { get; set; }
        public string? Detail { get; set; }
        public Meal Meal { get; set; }
        public Account Account { get; set; }
    }
}