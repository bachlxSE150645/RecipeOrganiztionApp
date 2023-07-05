namespace BusinessObjects.MapData
{
    public class OrderData
    {
        public Guid MealID { get; set; }
        public Guid AccountID { get; set; }
        public int Quantity { get; set; }   
        public string Detail { get; set; }
    }
}
