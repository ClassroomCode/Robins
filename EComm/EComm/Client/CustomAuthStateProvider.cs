using Blazored.LocalStorage;
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
        private ILocalStorageService _localStorage;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");

            ClaimsIdentity identity = new ClaimsIdentity();

            if (!string.IsNullOrEmpty(token)) {
                // 

                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Bill Gates"),
                    new Claim(ClaimTypes.Role, "Admin")
                }, "My Custom Auth");
            }
            
            var principal = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
