using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Kros.EventBusDoc.Demo.Products;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kros.EventBusDoc.Demo.Contracts
{
    public class OrderingService : IOrderingService
    {
        private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IOptions<AppSettings> _settings;


        public OrderingService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            _remoteServiceBaseUrl = $"{settings.Value.PurchaseUrl}/api/orders";
        }

        async public Task CancelOrder(int orderId)
        {
            var order = new Order() { Id = orderId };
            var uri = $"{_remoteServiceBaseUrl}/cancel";
            var orderContent = new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, orderContent);

            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error cancelling order, try later.");
            }

            response.EnsureSuccessStatusCode();
        }

        public Task<List<Order>> GetMyOrders(StoreUser user)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(StoreUser user, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
