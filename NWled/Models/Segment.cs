using System.Text.Json.Serialization;

namespace NWled.Models;
public sealed class Segment
{
    /// <summary>
    /// Zero-indexed ID of the segment. 
    /// If omitted, the ID will be inferred based on the order of the segments in the array. 
    /// This property is not included in the state response.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The index of the LED at which this segment begins.
    /// </summary>
    [JsonPropertyName("start")]
    public int Start { get; set; }

    /// <summary>
    /// The index of the LED at which this segment ends (exclusive). 
    /// If <see cref="Stop"/> is set to a value less than or equal to <see cref="Start"/> (0 recommended), the segment is considered invalid and will be deleted.
    /// </summary>
    [JsonPropertyName("stop")]
    public int Stop { get; set; }

    /// <summary>
    /// The length of the segment, calculated as <see cref="Stop"/> minus <see cref="Start"/>. 
    /// If <see cref="Stop"/> is specified, it takes precedence over this value.
    /// </summary>
    [JsonPropertyName("len")]
    public int Length { get; set; }

    /// <summary>
    /// The number of consecutive LEDs grouped together and assigned the same color in this segment.
    /// </summary>
    [JsonPropertyName("grp")]
    public int Group { get; set; }

    /// <summary>
    /// The number of LEDs to skip (turn off) between each grouped set of LEDs in this segment.
    /// </summary>
    [JsonPropertyName("spc")]
    public int Spacing { get; set; }

    /// <summary>
    /// The number of LEDs to rotate the virtual start of the segment. 
    /// This creates an offset effect (available since version 0.13.0).
    /// </summary>
    [JsonPropertyName("of")]
    public int Offset { get; set; }

    /// <summary>
    /// A two-dimensional array representing up to three color sets: primary, secondary (background), and tertiary colors for the segment.
    /// Each color is an array of 3 or 4 bytes, representing an RGB(W) value.
    /// </summary>
    [JsonPropertyName("col")]
    public int[][] Colors { get; set; } = [[]];

    /// <summary>
    /// The ID of the currently active lighting effect for this segment.
    /// </summary>
    [JsonPropertyName("fx")]
    public int EffectId { get; set; }

    /// <summary>
    /// The speed of the active effect, relative to the default effect speed.
    /// </summary>
    [JsonPropertyName("sx")]
    public int EffectSpeed { get; set; }

    /// <summary>
    /// The intensity of the active effect, controlling how strongly the effect is applied.
    /// </summary>
    [JsonPropertyName("ix")]
    public int EffectIntensity { get; set; }

    /// <summary>
    /// The ID of the color palette used by this segment.
    /// </summary>
    [JsonPropertyName("pal")]
    public int ColorPaletteId { get; set; }

    /// <summary>
    /// Indicates whether this segment is selected. 
    /// When true, state updates (color, effects) from APIs that don't support segments will apply to this segment.
    /// </summary>
    [JsonPropertyName("sel")]
    public bool Selected { get; set; }

    /// <summary>
    /// When true, reverses the direction of animations in this segment.
    /// </summary>
    [JsonPropertyName("rev")]
    public bool Reverse { get; set; }

    /// <summary>
    /// Indicates whether this segment is currently active (on).
    /// Available since version 0.10.0.
    /// </summary>
    [JsonPropertyName("on")]
    public bool SegmentState { get; set; }

    /// <summary>
    /// The brightness level of this individual segment, ranging from 0 (off) to 255 (full brightness).
    /// Available since version 0.10.0.
    /// </summary>
    [JsonPropertyName("bri")]
    public int Brightness { get; set; }

    /// <summary>
    /// When true, mirrors the animation of this segment (available since version 0.10.2).
    /// </summary>
    [JsonPropertyName("mi")]
    public bool Mirror { get; set; }
}
