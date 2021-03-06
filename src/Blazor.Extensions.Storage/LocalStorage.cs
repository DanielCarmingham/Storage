using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Storage
{
    public class LocalStorage : IStorage
    {
        private readonly IJSRuntime runtime;

        public ValueTask<int> Length() => this.runtime.InvokeAsync<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.LOCAL_STORAGE);

        public ValueTask Clear() => this.runtime.InvokeVoidAsync(MethodNames.CLEAR_METHOD, StorageTypeNames.LOCAL_STORAGE);

        public LocalStorage(IJSRuntime runtime)
        {
            this.runtime = runtime;
        }

        public ValueTask<TItem> GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeAsync<TItem>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public ValueTask<string> Key(int index) => this.runtime.InvokeAsync<string>(MethodNames.KEY_METHOD, StorageTypeNames.LOCAL_STORAGE, index);

        public ValueTask RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeVoidAsync(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public ValueTask SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeVoidAsync(MethodNames.SET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key, item);
        }
    }
}
