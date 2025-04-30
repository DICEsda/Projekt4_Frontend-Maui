using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;

namespace FinanceTracker.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PaycheckViewModel : ObservableObject
    {
        readonly IDataStore<Item> dataStore;
        ILogger<PaycheckViewModel> logger;

        public PaycheckViewModel(IDataStore<Item> dataStore, ILogger<PaycheckViewModel> logger)
        {
            this.dataStore = dataStore;
            this.logger = logger;
        }

        [ObservableProperty]
        private string? title;

        [ObservableProperty]
        private string? id;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? description;

        private string? itemId;
        public string ItemId
        {
            get
            {
                if(itemId == null) { throw new NullReferenceException(nameof(itemId)); }
                return itemId;
            }

            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            if (itemId == null) { throw new ArgumentNullException(nameof(itemId)); }
            var item = await dataStore.GetItemAsync(itemId);
            if (item == null) { logger.LogDebug("cannot find {itemId}", itemId); return; }
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
        }
    }
}
