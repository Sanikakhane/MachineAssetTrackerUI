

namespace MachineAssetTrackerUI.Models
{
    public class Asset
    {
        
        public string? Id { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public List<string> Series { get; set; } = new List<string>();
    }
}
