namespace CoalStore.DB.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int UnitsInStock { get; set; }

        public string CoalType { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
