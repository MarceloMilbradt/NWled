using System.Text.Json.Serialization;

namespace NWled.Models;

/// <summary>
/// Represents the nightlight feature of the WLED device, which gradually dims or changes the light over a set period.
/// </summary>
public sealed class Nightlight
{
    /// <summary>
    /// Indicates whether the nightlight is currently active (true) or inactive (false).
    /// </summary>
    [JsonPropertyName("on")]
    public bool On { get; set; }

    /// <summary>
    /// The duration of the nightlight effect in minutes. After this period, the light will reach the target brightness.
    /// </summary>
    [JsonPropertyName("dur")]
    public int Duration { get; set; }

    /// <summary>
    /// The mode of the nightlight, determining how the light transitions:
    /// 0 = Instant change, 
    /// 1 = Gradual fade out, 
    /// 2 = Color fade, 
    /// 3 = Sunrise effect (light gradually brightens).
    /// Available since version 0.10.2.
    /// </summary>
    [JsonPropertyName("mode")]
    public NightlightMode Mode { get; set; }

    /// <summary>
    /// The target brightness that the nightlight will reach at the end of the set duration.
    /// The value ranges from 0 (off) to 255 (full brightness).
    /// </summary>
    [JsonPropertyName("tbri")]
    public int TargetBrightness { get; set; }
}
