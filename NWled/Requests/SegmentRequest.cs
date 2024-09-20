using System.Text.Json.Serialization;
using NWled.Models;

namespace NWled.Requests;

public sealed class SegmentRequest
{
    /// <inheritdoc cref="Segment.Id"/>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Id { get; set; }

    /// <inheritdoc cref="Segment.Start"/>
    [JsonPropertyName("start")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Start { get; set; }

    /// <inheritdoc cref="Segment.Stop"/>
    [JsonPropertyName("stop")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Stop { get; set; }

    /// <inheritdoc cref="Segment.Length"/>
    [JsonPropertyName("len")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Length { get; set; }

    /// <inheritdoc cref="Segment.Group"/>
    [JsonPropertyName("grp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Group { get; set; }

    /// <inheritdoc cref="Segment.Spacing"/>
    [JsonPropertyName("spc")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Spacing { get; set; }

    /// <inheritdoc cref="Segment.Offset"/>
    [JsonPropertyName("of")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Offset { get; set; }

    /// <inheritdoc cref="Segment.Colors"/>
    [JsonPropertyName("col")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[][]? Colors { get; set; }

    /// <inheritdoc cref="Segment.EffectId"/>
    [JsonPropertyName("fx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EffectId { get; set; }

    /// <inheritdoc cref="Segment.EffectSpeed"/>
    [JsonPropertyName("sx")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EffectSpeed { get; set; }

    /// <inheritdoc cref="Segment.EffectIntensity"/>
    [JsonPropertyName("ix")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EffectIntensity { get; set; }

    /// <inheritdoc cref="Segment.ColorPaletteId"/>
    [JsonPropertyName("pal")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ColorPaletteId { get; set; }

    /// <inheritdoc cref="Segment.Selected"/>
    [JsonPropertyName("sel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Selected { get; set; }

    /// <inheritdoc cref="Segment.Reverse"/>
    [JsonPropertyName("rev")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Reverse { get; set; }

    /// <inheritdoc cref="Segment.SegmentState"/>
    [JsonPropertyName("on")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SegmentState { get; set; }

    /// <inheritdoc cref="Segment.Brightness"/>
    [JsonPropertyName("bri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Brightness { get; set; }

    /// <inheritdoc cref="Segment.Mirror"/>
    [JsonPropertyName("mi")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Mirror { get; set; }


    public static SegmentRequest Create(Segment segmentResponse)
    {
        return new SegmentRequest
        {
            Id = segmentResponse.Id,
            Start = segmentResponse.Start,
            Stop = segmentResponse.Stop,
            Length = segmentResponse.Length,
            Group = segmentResponse.Group,
            Spacing = segmentResponse.Spacing,
            Offset = segmentResponse.Offset,
            Colors = segmentResponse.Colors,
            EffectId = segmentResponse.EffectId,
            EffectSpeed = segmentResponse.EffectSpeed,
            EffectIntensity = segmentResponse.EffectIntensity,
            ColorPaletteId = segmentResponse.ColorPaletteId,
            Selected = segmentResponse.Selected,
            Reverse = segmentResponse.Reverse,
            SegmentState = segmentResponse.SegmentState,
            Brightness = segmentResponse.Brightness,
            Mirror = segmentResponse.Mirror
        };
    }

    public static implicit operator SegmentRequest(Segment rhs) => Create(rhs);
}