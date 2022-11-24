namespace CoalStore.Shared.Models.Authorization
{
    public sealed class ClaimResult
    {
        public ClaimResult(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; }

        public string Value { get; }
    }
}
