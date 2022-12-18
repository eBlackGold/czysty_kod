namespace CoalStore.DB.Models
{
    public interface IUser
    {
        int Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Address { get; set; }
    }
}
