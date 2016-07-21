using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Services
{
    public class UserManagerAccountIdProvider : IAccountIdProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HttpContext _httpContext;

        public UserManagerAccountIdProvider(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _httpContext = new ControllerContext().HttpContext;
        }

        public async Task<int> AccountId()
        {
            return (await _userManager.GetUserAsync(User)).AccountId;
        }

        protected ClaimsPrincipal User { get; }
    }
}
