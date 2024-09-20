using NWled.Models;
using NWled.Requests;
using System.Net.Http.Json;
using System.Text.Json;

namespace NWLED;

public sealed class WLedClient
{
    private readonly HttpClient _client;

    public WLedClient(HttpMessageHandler httpMessageHandler, string baseUri)
    {
        _client = new HttpClient(httpMessageHandler)
        {
            BaseAddress = new Uri(baseUri, UriKind.Absolute)
        };

        // Add the keep-alive flag to the header
        _client.DefaultRequestHeaders.Add("Connection", "keep-alive");
    }

    public WLedClient(string baseUri) : this(new HttpClientHandler(), baseUri)
    {

    }

    public async Task<WLedRoot?> GetAsync()
    {
        var message = await _client.GetAsync("json");

        message.EnsureSuccessStatusCode();

        return await message.Content.ReadFromJsonAsync<WLedRoot>();
    }

    public async Task<State?> GetStateAsync()
    {
        var message = await _client.GetAsync("json/state");

        message.EnsureSuccessStatusCode();

        return await message.Content.ReadFromJsonAsync<State>();
    }

    public async Task<Information?> GetInformationAsync()
    {
        var message = await _client.GetAsync("json/info");

        message.EnsureSuccessStatusCode();

        return await message.Content.ReadFromJsonAsync<Information>();
    }

    public async Task<IEnumerable<string>> GetEffectsAsync()
    {
        var message = await _client.GetAsync("json/eff");

        message.EnsureSuccessStatusCode();

        return await message.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? [];
    }

    public async Task<IEnumerable<string>> GetPalettesAsync()
    {
        var message = await _client.GetAsync("json/pal");

        message.EnsureSuccessStatusCode();

        return await message.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? [];
    }

    public async Task PostAsync(WLedRootRequest request)
    {
        var stateString = JsonSerializer.Serialize(request);

        using var content = new StringContentWithoutCharset(stateString, "application/json");
        var result = await _client.PostAsync("/json", content);
        result.EnsureSuccessStatusCode();
    }

    public async Task PostAsync(StateRequest request)
    {
        var stateString = JsonSerializer.Serialize(request);

        using var content = new StringContentWithoutCharset(stateString, "application/json");
        var result = await _client.PostAsync("/json/state", content);
        result.EnsureSuccessStatusCode();
    }
}
