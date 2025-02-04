

namespace MachineAssetTrackerUI.Models
{
    public class Machine
    {
    
        public string? Id { get; set; }
        public string MachineType { get; set; } = string.Empty;
        public List<Asset> Assets { get; set; } = new List<Asset>();
    }
}
