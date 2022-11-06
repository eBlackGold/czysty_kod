namespace CoalStore.DB.Models
{
    public partial class Customer
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public DateTime SessionStart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
