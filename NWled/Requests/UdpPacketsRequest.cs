using System.Text.Json.Serialization;
using NWled.Models;

namespace NWled.Requests;

public sealed class UdpPacketsRequest
{
    /// <inheritdoc cref="UdpPackets.Send"/>
    [JsonPropertyName("send")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Send { get; set; }

    /// <inheritdoc cref="UdpPackets.Receive"/>
    [JsonPropertyName("recv")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Receive { get; set; }

    public static UdpPacketsRequest Create(UdpPackets udpPackets)
    {
        return new UdpPacketsRequest
        {
            Send = udpPackets.Send,
            Receive = udpPackets.Receive
        };
    }

    public static implicit operator UdpPacketsRequest(UdpPackets rhs) => Create(rhs);
}