using System.Security.Claims;

namespace OnKeyWebApp
{
    public static class ClaimsPrincipalExtention
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
