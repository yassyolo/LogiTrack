using System.Security.Claims;

namespace LogiTrack.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
