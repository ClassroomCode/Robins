using Blazored.LocalStorage;
using Bunit;
using EComm.Client.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EComm.Tests
{
    public class CounterTest : TestContext
    {
        [Fact]
        public void SimpleCounterTest()
        {
            Services.AddScoped<ILocalStorageService, StubLocalStorageService>();

            var c = RenderComponent<Counter>();

            Assert.Equal("", c.Markup);
        }
    }

    class StubLocalStorageService : ILocalStorageService
    {
        public event EventHandler<ChangingEventArgs> Changing;
        public event EventHandler<ChangedEventArgs> Changed;

        public ValueTask ClearAsync(CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ContainKeyAsync(string key, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> GetItemAsStringAsync(string key, CancellationToken? cancellationToken = null)
        {
            return new ValueTask<string>("");
        }

        public ValueTask<T> GetItemAsync<T>(string key, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> KeyAsync(int index, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<string>> KeysAsync(CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<int> LengthAsync(CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask RemoveItemAsync(string key, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask SetItemAsStringAsync(string key, string data, CancellationToken? cancellationToken = null)
        {
            return new ValueTask();
        }

        public ValueTask SetItemAsync<T>(string key, T data, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }
    }
}
