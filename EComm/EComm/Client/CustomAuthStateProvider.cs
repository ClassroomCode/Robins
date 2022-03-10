using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EComm.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            /*
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "Bill Gates"),
                new Claim(ClaimTypes.Role, "Admin")
            }, "My Custom Auth");
            */

            var principal = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
