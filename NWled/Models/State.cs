using System.Text.Json.Serialization;

namespace NWled.Models;

public sealed class State
{
    /// <summary>
    /// The current power state of the light. True if the light is on, false if it is off.
    /// </summary>
    [JsonPropertyName("on")]
    public bool On { get; set; }

    /// <summary>
    /// The brightness level of the light, ranging from 0 (off) to 255 (full brightness).
    /// If <see cref="On"/> is false, this property contains the last brightness level before the light was turned off.
    /// </summary>
    [JsonPropertyName("bri")]
    public byte Brightness { get; set; }

    /// <summary>
    /// Duration of the crossfade transition between different color or brightness levels.
    /// One unit equals 100 milliseconds (ms), so a value of 4 would create a 400ms transition.
    /// </summary>
    [JsonPropertyName("transition")]
    public byte Transition { get; set; }

    /// <summary>
    /// The ID of the currently selected preset, which stores a specific configuration of lighting effects.
    /// </summary>
    [JsonPropertyName("ps")]
    public int PresetId { get; set; }

    /// <summary>
    /// The ID of the currently active playlist for cycling presets. 
    /// A value of -1 disables the playlist, while 0 enables the preset cycle feature.
    /// </summary>
    [JsonPropertyName("pl")]
    public int PlaylistId { get; set; }

    /// <summary>
    /// Nightlight settings, such as its duration or fade behavior. See <see cref="Models.Nightlight"/> for more details.
    /// </summary>
    [JsonPropertyName("nl")]
    public Nightlight Nightlight { get; set; } = null!;

    /// <summary>
    /// Settings related to UDP packets used for controlling the WLED over the network.
    /// See <see cref="Models.UdpPackets"/> for more details.
    /// </summary>
    [JsonPropertyName("udpn")]
    public UdpPackets UdpPackets { get; set; } = null!;

    /// <summary>
    /// Controls the live data override behavior. 
    /// 0 = No override, 1 = Override until live data transmission ends, 2 = Override until device reboot.
    /// </summary>
    [JsonPropertyName("lor")]
    public byte LiveDataOverride { get; set; }

    /// <summary>
    /// The ID of the main segment. Segments divide the LED strip into individually controlled sections.
    /// </summary>
    [JsonPropertyName("mainseg")]
    public int MainSegment { get; set; }

    /// <summary>
    /// A collection of <see cref="Models.Segment"/> objects representing different sections of the LED strip,
    /// each of which can be controlled independently for effects and colors.
    /// </summary>
    [JsonPropertyName("seg")]
    public IEnumerable<Segment> Segments { get; set; } = null!;

    /// <summary>
    /// A timebase value used for synchronizing effects with a consistent reference point.
    /// </summary>
    [JsonPropertyName("tb")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timebase { get; set; }
}
