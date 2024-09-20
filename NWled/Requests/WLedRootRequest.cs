using System.Text.Json.Serialization;
using NWled.Models;

namespace NWled.Requests;

public sealed class WLedRootRequest
{
    /// <inheritdoc cref="State" />
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StateRequest? State { get; set; }

    public static WLedRootRequest Create(WLedRoot root)
    {
        return new WLedRootRequest
        {
            State = root.State
        };
    }

    public static implicit operator WLedRootRequest(WLedRoot rhs) => Create(rhs);
}