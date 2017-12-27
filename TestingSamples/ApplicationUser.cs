using System;

using Microsoft.AspNet.Identity;

namespace SweetShop
{
    public class ApplicationUser : IUser<string>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public ApplicationUser(string userName) : this()
        {
            UserName = userName;
        }

        public string Id { get; }

        public string UserName { get; set; }
    }
}
