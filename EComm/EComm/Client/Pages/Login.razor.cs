using EComm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EComm.Client.Pages
{
    public partial class Login
    {
        private LoginDto user = new LoginDto();

        async Task HandleLogin()
        {
            var result = await Http.PostAsJsonAsync("api/auth/login", user);
            var token = await result.Content.ReadAsStringAsync();
            await LocalStorage.SetItemAsync("token", token);
            await AuthStateProvider.GetAuthenticationStateAsync();
        }
    }
}
