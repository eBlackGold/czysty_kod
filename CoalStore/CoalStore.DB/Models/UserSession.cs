namespace CoalStore.DB.Models
{
    public partial class UserSession
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserRole { get; set; }

        public DateTime SessionStart { get; set; }
    }
}
