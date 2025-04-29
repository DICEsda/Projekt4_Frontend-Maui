using FinanceTracker.Models;
using FinanceTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Services
{
    public class JobDataStore : IDataStore<JobDTO>
    {
        private readonly List<JobDTO> _items;

        public JobDataStore()
        {
            _items = new List<JobDTO>();
            // Add mock data if needed
        }

        public async Task<bool> AddItemAsync(JobDTO item)
        {
            _items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(JobDTO item)
        {
            var oldItem = _items.FirstOrDefault(x => x.Id == item.Id);
            if (oldItem != null)
            {
                _items.Remove(oldItem);
                _items.Add(item);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _items.FirstOrDefault(x => x.Id == id);
            if (oldItem != null)
            {
                _items.Remove(oldItem);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<JobDTO> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(x => x.Id == id) ?? new JobDTO());
        }

        public async Task<IEnumerable<JobDTO>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }
    }
}