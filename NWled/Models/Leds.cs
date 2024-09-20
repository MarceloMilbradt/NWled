using System.Text.Json.Serialization;

namespace NWled.Models;

/// <summary>
/// Provides detailed information about the LED configuration and performance on the WLED device.
/// </summary>
public sealed class Leds
{
    /// <summary>
    /// The total number of LEDs controlled by the WLED device.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// The current frames per second (FPS) at which the LEDs are being updated.
    /// Available since WLED version 0.12.0.
    /// </summary>
    [JsonPropertyName("fps")]
    public byte Fps { get; set; }

    /// <summary>
    /// Represents the logical AND of all active segments' virtual light capabilities.
    /// This property helps determine the combined behavior of multiple segments.
    /// </summary>
    [JsonPropertyName("lc")]
    public byte LightCapabilities { get; set; }

    /// <summary>
    /// The current power consumption of the LEDs, measured in milliamps (mA), as determined by the Automatic Brightness Limiter (ABL).
    /// A value of 0 indicates that ABL is disabled.
    /// </summary>
    [JsonPropertyName("pwr")]
    public int PowerUsage { get; set; }

    /// <summary>
    /// The maximum allowable power consumption in milliamps (mA) as set by the Automatic Brightness Limiter (ABL).
    /// A value of 0 indicates that ABL is disabled.
    /// </summary>
    [JsonPropertyName("maxpwr")]
    public int MaximumPower { get; set; }

    /// <summary>
    /// The maximum number of LED segments supported by the current version of WLED.
    /// </summary>
    [JsonPropertyName("maxseg")]
    public byte MaximumSegments { get; set; }
}
