using Microsoft.AspNetCore.Identity;
using OnlineStore.Core.Identity;

namespace OnlineStore.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user, UserManager<ApplicationUser> userManager);

    }
}
