using System.Text.Json.Serialization;
using NWled.Models;

namespace NWled.Requests;

public sealed class StateRequest
{
    /// <inheritdoc cref="State.On"/>
    [JsonPropertyName("on")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? On { get; set; }

    /// <inheritdoc cref="State.Brightness"/>
    [JsonPropertyName("bri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte? Brightness { get; set; }

    /// <inheritdoc cref="State.Transition"/>
    [JsonPropertyName("transition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte? Transition { get; set; }

    /// <inheritdoc cref="State.PresetId"/>
    [JsonPropertyName("ps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PresetId { get; set; }

    /// <inheritdoc cref="State.PlaylistId"/>
    [JsonPropertyName("pl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PlaylistId { get; set; }

    /// <inheritdoc cref="State.Nightlight"/>
    [JsonPropertyName("nl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public NightlightRequest? Nightlight { get; set; } = null!;

    /// <inheritdoc cref="State.UdpPackets"/>
    [JsonPropertyName("udpn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UdpPacketsRequest? UdpPackets { get; set; } = null!;

    /// <inheritdoc cref="State.LiveDataOverride"/>
    [JsonPropertyName("lor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte? LiveDataOverride { get; set; }

    /// <inheritdoc cref="State.MainSegment"/>
    [JsonPropertyName("mainseg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MainSegment { get; set; }

    /// <inheritdoc cref="State.Segments"/>
    [JsonPropertyName("seg")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SegmentRequest[]? Segments { get; set; } = null!;

    /// <summary>
    /// Timebase for effects.
    /// </summary>
    [JsonPropertyName("tb")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timebase { get; set; }

    public static StateRequest Create(State state)
    {
        var request = new StateRequest()
        {
            On = state.On,
            Brightness = state.Brightness,
            Transition = state.Transition,
            PresetId = state.PresetId,
            PlaylistId = state.PlaylistId,
            LiveDataOverride = state.LiveDataOverride,
            MainSegment = state.MainSegment,
            Timebase = state.Timebase
        };
        if (state.Nightlight != null)
        {
            request.Nightlight = state.Nightlight;
        }
        if (state.UdpPackets != null)
        {
            request.UdpPackets = state.UdpPackets;
        }
        if (state.Segments != null)
        {
            request.Segments = state.Segments.Select(SegmentRequest.Create).ToArray();
        }
        return request;
    }

    public static implicit operator StateRequest(State rhs) => Create(rhs);
}