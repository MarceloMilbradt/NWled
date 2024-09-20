using System.Text.Json.Serialization;

namespace NWled.Models;

/// <summary>
/// Represents the settings related to UDP (User Datagram Protocol) packets for WLED.
/// This includes the ability to send and receive broadcast packets for synchronization across multiple devices.
/// </summary>
public sealed class UdpPackets
{
    /// <summary>
    /// Indicates whether to send a WLED broadcast (UDP sync) packet when there is a change in the state of the device.
    /// This allows for real-time synchronization with other devices on the network.
    /// </summary>
    [JsonPropertyName("send")]
    public bool Send { get; set; }

    /// <summary>
    /// Indicates whether the device is set to receive broadcast packets from other WLED devices.
    /// This setting allows the device to listen for state changes or commands sent by other devices.
    /// </summary>
    [JsonPropertyName("recv")]
    public bool Receive { get; set; }
}
