namespace CoalStore.Shared.Models.Authorization
{
    public sealed class AuthorizationResultModel
    {
        public AuthorizationResultModel(DateTime dateTo, IEnumerable<ClaimResult> claims, string token)
        {
            ValidTo = dateTo;
            Claims = claims;
            Token = token;
        }

        public DateTime ValidTo { get; }


        public IEnumerable<ClaimResult> Claims { get; }

        public string Token { get; set; }
    }
}
