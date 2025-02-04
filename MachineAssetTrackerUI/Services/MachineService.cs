using MachineAssetTrackerUI.Models;
using System.Net.Http.Json;

namespace MachineAssetTrackerUI.Services
{
    public class MachineService
    {
        private readonly HttpClient _httpClient;

        public MachineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Machine>> GetMachinesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Machine>>("api/machines");
            if(response == null)
            {
                throw new ArgumentException("No machines found in the database");
            }
            return response ;

        }

        public async Task<Machine> GetMachineDetailsAsync(string machineId)
        {
            return await _httpClient.GetFromJsonAsync<Machine>($"api/machines/{machineId}");
        }

        public async Task<Machine> AddMachineAsync(Machine machine)
        {
            var response = await _httpClient.PostAsJsonAsync("api/machines", machine);
            return await response.Content.ReadFromJsonAsync<Machine>();
        }

        public async Task UpdateMachineAsync(Machine machine)
        {
            await _httpClient.PutAsJsonAsync($"api/machines/{machine.Id}", machine);
        }

        public async Task DeleteMachineAsync(string machineId)
        {
            await _httpClient.DeleteAsync($"api/machines/{machineId}");
        }
    }
}
