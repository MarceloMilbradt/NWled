using System.Text.Json.Serialization;

namespace NWled.Models;

/// <summary>
/// Provides general information about the WLED device, including version, hardware details, and system status.
/// </summary>
public sealed class Information
{
    /// <summary>
    /// The version name of the WLED firmware currently running on the device.
    /// </summary>
    [JsonPropertyName("ver")]
    public string VersionName { get; set; } = null!;

    /// <summary>
    /// The unique build identifier, formatted as YYMMDDB, where B is the daily build index.
    /// </summary>
    [JsonPropertyName("vid")]
    public uint BuildId { get; set; }

    /// <summary>
    /// Information about the LEDs, including configuration and state.
    /// See <see cref="Models.Leds"/>.
    /// </summary>
    [JsonPropertyName("leds")]
    public Leds Leds { get; set; } = null!;

    /// <summary>
    /// If true, a single-button UI for toggling sync will toggle both send and receive modes. 
    /// If false, it toggles send mode only.
    /// </summary>
    [JsonPropertyName("str")]
    public bool ToggleSendReceive { get; set; }

    /// <summary>
    /// The user-friendly name of the device or light.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// The UDP port used for receiving realtime packets and WLED broadcast communication.
    /// </summary>
    [JsonPropertyName("udpport")]
    public int UdpPort { get; set; }

    /// <summary>
    /// Indicates whether the device is currently receiving realtime data via UDP or E1.31.
    /// </summary>
    [JsonPropertyName("live")]
    public bool Live { get; set; }

    /// <summary>
    /// The total number of lighting effects available on the device.
    /// </summary>
    [JsonPropertyName("fxcount")]
    public byte EffectsCount { get; set; }

    /// <summary>
    /// The total number of color palettes configured on the device.
    /// </summary>
    [JsonPropertyName("palcount")]
    public ushort PalettesCount { get; set; }

    /// <summary>
    /// The name of the hardware platform on which WLED is running (e.g., ESP8266, ESP32).
    /// </summary>
    [JsonPropertyName("arch")]
    public string Arch { get; set; } = null!;

    /// <summary>
    /// The version of the underlying SDK (Arduino core) used by the device.
    /// </summary>
    [JsonPropertyName("core")]
    public string Core { get; set; } = null!;

    /// <summary>
    /// The amount of free heap memory (RAM) currently available on the device.
    /// Values below 10k may indicate performance issues.
    /// </summary>
    [JsonPropertyName("freeheap")]
    public uint FreeHeapMemory { get; set; }

    /// <summary>
    /// The time elapsed since the last boot or reset, measured in seconds.
    /// </summary>
    [JsonPropertyName("uptime")]
    public uint UpTime { get; set; }

    /// <summary>
    /// A value used for debugging purposes, providing various system-related options.
    /// </summary>
    [JsonPropertyName("opt")]
    public ushort Opt { get; set; }

    /// <summary>
    /// The name of the vendor or producer of the device. 
    /// For standard installations, this is always "WLED".
    /// </summary>
    [JsonPropertyName("brand")]
    public string Brand { get; set; } = null!;

    /// <summary>
    /// The product name of the device. 
    /// For standard installations, this is always "FOSS".
    /// </summary>
    [JsonPropertyName("product")]
    public string Product { get; set; } = null!;

    /// <summary>
    /// Specifies the origin of the build:
    /// "src" if compiled from source, 
    /// "bin" for official release images, 
    /// "dev" for development builds, 
    /// "exp" for experimental versions, 
    /// or "ogn" if flashed to hardware by the vendor.
    /// </summary>
    [JsonPropertyName("btype")]
    public string BuildType { get; set; } = null!;

    /// <summary>
    /// The hexadecimal hardware MAC address of the device, represented in lowercase and without colons.
    /// </summary>
    [JsonPropertyName("mac")]
    public string MacAddress { get; set; } = null!;

    /// <summary>
    /// The IP address assigned to this instance of WLED on the network.
    /// Will be an empty string if the device is not connected.
    /// Available since version 0.13.0.
    /// </summary>
    [JsonPropertyName("ip")]
    public string NetworkAddress { get; set; } = null!;
}
