using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CartManagementGateway.APIHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CartManagementGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartManagementController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<CartManagementController> _logger;

        private readonly IItemServiceClient _itemServiceClient;

        public CartManagementController(ILogger<CartManagementController> logger, IItemServiceClient itemServiceClient)
        {
            _logger = logger;
            _itemServiceClient = itemServiceClient;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> GetAllItems()
        {
            dynamic response = null;

            try
            {
                var reqId = Guid.NewGuid();
                response = await _itemServiceClient.GetAllItems();

            }
            //catch (BrokenCircuitException cbe)
            //{
            //    // Circuit Borker Exception
            //    throw new Exception("Circuit Breaker Invoked- Exception: ", cbe);
            //}
            //catch (HttpRequestException ex)
            //{
            //    // Other Exceptions
            //    throw new Exception("Generic HTTP Exception: ", ex);
            //}
            catch(Exception e)
            {
                throw e;
            }

            JustAChk();

            return response;
        }

        private void JustAChk()
        {
            try
            {
                _itemServiceClient.BlockItemsAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
