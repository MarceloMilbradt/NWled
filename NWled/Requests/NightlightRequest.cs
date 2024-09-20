using System.Text.Json.Serialization;
using NWled.Models;

namespace NWled.Requests;

public sealed class NightlightRequest
{
    /// <inheritdoc cref="On"/>
    [JsonPropertyName("on")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? On { get; set; }

    /// <inheritdoc cref="Duration"/>
    [JsonPropertyName("dur")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Duration { get; set; }

    /// <inheritdoc cref="Mode"/>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NightlightMode? Mode { get; set; }

    /// <inheritdoc cref="TargetBrightness"/>
    [JsonPropertyName("tbri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TargetBrightness { get; set; }

    public static NightlightRequest Create(Nightlight nightlight)
    {
        return new NightlightRequest
        {
            On = nightlight.On,
            Duration = nightlight.Duration,
            Mode = nightlight.Mode,
            TargetBrightness = nightlight.TargetBrightness
        };
    }

    public static implicit operator NightlightRequest(Nightlight rhs) => Create(rhs);
}