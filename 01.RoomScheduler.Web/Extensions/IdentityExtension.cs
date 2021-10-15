using Microsoft.AspNetCore.Identity;
using RoomScheduler.Data.Models;
using System.Threading.Tasks;

namespace RoomScheduler.Web.Extensions
{
    public static class IdentityExtension
    {
        public static async Task<string> GetSignInMethod(string emailOrUsername, UserManager<ApplicationUser> _userManager)
        {
            var signInMethod = emailOrUsername;
            if (emailOrUsername.Contains('@'))
            {
                var user = await _userManager.FindByEmailAsync(signInMethod);
                if (user != null)
                {
                    signInMethod = user.UserName;
                }
            }
            return signInMethod;
        }
    }
}
