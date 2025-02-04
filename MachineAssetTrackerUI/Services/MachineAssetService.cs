using MachineAssetTrackerUI.Models;
using System.Net.Http.Json;

namespace MachineAssetTrackerUI.Services
{
    public class MachineAssetService
    {
        private readonly HttpClient _httpClient;

        public MachineAssetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MachineAsset>> GetMachineAssetsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<MachineAsset>>("api/machineassets");
        }

        public async Task<List<string>> GetAssestsByMachineAsync(string machineType)
        {
            var response = await _httpClient.GetFromJsonAsync<List<string>>($"api/machineassets/byMachineType/{machineType}");
           
            return response ?? new List<string>();
        }

        public async Task<List<string>> GetMachineByAsset(string assetName)
        {
            var response = await _httpClient.GetFromJsonAsync<List<string>>($"api/machineassets/byAssetName/{assetName}");
            return response ?? new List<string>();
        }

        public async Task<List<string>> GetMachineUsingLatestSeries()
        {
           var responce =  await _httpClient.GetFromJsonAsync<List<string>>("api/machineassets/GetMachinesUsingLatestSeries");
            return responce ?? new List<string>();
        }
    }
}
