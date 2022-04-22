using Bunit;
using EComm.Client.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EComm.Tests
{
    public class CounterTest : TestContext
    {
        [Fact]
        public void SimpleCounterTest()
        {
            //Services.AddScoped<ILocalStorageService, StubLocalStorageService>();

            var c = RenderComponent<FetchData>();

            Assert.Equal("", c.Markup);
        }
    }
}
