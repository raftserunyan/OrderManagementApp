using Newtonsoft.Json;
using OrderManagementApp.Models;
using OrderManagementApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApp.UI.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public SupplierService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:9253");
        }

        public async Task<SupplierModel> CreateSupplierAsync(SupplierCreationRequest request)
        {
            var response = await _httpClient.PostAsync("api/suppliers", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<SupplierModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/suppliers/{id}");
        }

        public async Task<List<SupplierModel>> GetAllSuppliersAsync()
        {
            var response = await _httpClient.GetAsync("api/suppliers");

            return JsonConvert.DeserializeObject<List<SupplierModel>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<SupplierModel> GetSupplierByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/suppliers/{id}");

            return JsonConvert.DeserializeObject<SupplierModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<SupplierModel> UpdateSupplierAsync(SupplierUpdateRequest request)
        {
            var response = await _httpClient.PutAsync($"api/suppliers/{request.Id}", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<SupplierModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
