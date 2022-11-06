namespace CoalStore.Shared.Models.Product
{
    public class AddSupplyModel
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int UnitsInStock { get; set; }

        public string CoalType { get; set; }
    }
}
