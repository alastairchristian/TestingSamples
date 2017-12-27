using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

namespace SweetShop
{
    public class SweetService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public SweetService(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> NumberOfGummyBearsForUser(string userId)
        {
            var userHasASweetTooth = await _userManager.IsInRoleAsync(userId, "SweetTooth");
            if (userHasASweetTooth)
            {
                return 100;
            }
            else
            {
                return 1;
            }
        }
    }
}
