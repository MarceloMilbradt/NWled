using System.Text.Json.Serialization;

namespace NWled.Models;

public sealed class WLedRoot
{
    /// <summary>
    /// Represents the current state of the WLED device, including power, brightness, color, and other attributes.
    /// These properties can be modified via the API to control the device.
    /// See <see cref="Models.State"/> for more details.
    /// </summary>
    [JsonPropertyName("state")]
    public State State { get; set; } = null!;

    /// <summary>
    /// Provides general information about the WLED device, such as version, uptime, and hardware details.
    /// These values are read-only and cannot be altered through the API.
    /// See <see cref="Models.Information"/> for more details.
    /// </summary>
    [JsonPropertyName("info")]
    public Information Information { get; set; } = null!;

    /// <summary>
    /// Contains a list of effect mode names that the WLED device supports. 
    /// Each effect corresponds to a visual lighting pattern that can be applied.
    /// </summary>
    [JsonPropertyName("effects")]
    public IEnumerable<string> Effects { get; set; } = [];

    /// <summary>
    /// Contains a list of color palette names that the WLED device can use. 
    /// Palettes define the range of colors available for effects or static lighting.
    /// </summary>
    [JsonPropertyName("palettes")]
    public IEnumerable<string> Palettes { get; set; } = [];
}