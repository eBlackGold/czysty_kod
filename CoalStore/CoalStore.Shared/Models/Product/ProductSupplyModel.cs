namespace CoalStore.Shared.Models.Product
{
    public class ProductSupplyModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public string CoalType { get; set; }
    }
}
