namespace CoalStore.Shared.Models.Order
{
    public class SubmitOrderModel
    {
        public string Login { get; set; }

        public List<ProductOrderModel> ProductOrderModels { get; set; }
    }
}
