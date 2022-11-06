namespace CoalStore.Shared.Models.Order
{
    public class OrderHistoryModel
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; }

        public double OrderPrice { get; set; }
    }
}
