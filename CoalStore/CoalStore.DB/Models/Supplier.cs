namespace CoalStore.DB.Models
{
    public partial class Supplier : IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
