using NWled.Models;
using NWled.Requests;

namespace NWLED
{
    public interface IWLedClient
    {
        Task<WLedRoot?> GetAsync();
        Task<IEnumerable<string>> GetEffectsAsync();
        Task<Information?> GetInformationAsync();
        Task<IEnumerable<string>> GetPalettesAsync();
        Task<State?> GetStateAsync();
        Task PostAsync(StateRequest request);
        Task PostAsync(WLedRootRequest request);
    }
}