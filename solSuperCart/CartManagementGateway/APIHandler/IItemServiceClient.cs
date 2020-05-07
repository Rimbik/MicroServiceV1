using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartManagementGateway.APIHandler
{
    public interface IItemServiceClient
    {
        public Task<IEnumerable<dynamic>> GetAllItems();
        public Task BlockItemsAsync();
    }

}
