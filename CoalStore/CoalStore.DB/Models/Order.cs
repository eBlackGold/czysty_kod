namespace CoalStore.DB.Models
{
    public partial class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public string Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
