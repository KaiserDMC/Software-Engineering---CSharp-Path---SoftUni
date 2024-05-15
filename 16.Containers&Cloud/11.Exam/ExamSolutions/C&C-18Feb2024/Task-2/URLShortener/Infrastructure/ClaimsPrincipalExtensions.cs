using System.Security.Claims;

namespace URLShortener.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string UserId(this ClaimsPrincipal user)
        {
            Claim? userClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userClaim is null)
            {
                return string.Empty;
            }

            return userClaim.Value;
        }
    }
}
