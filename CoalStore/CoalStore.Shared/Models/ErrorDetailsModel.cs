using System.Text.Json;

namespace CoalStore.Shared.Models
{
    public class ErrorDetailsModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
