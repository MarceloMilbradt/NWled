namespace NWled.Models;

/// <summary>
/// Defines the different modes for the nightlight effect.
/// </summary>
public enum NightlightMode : byte
{
    /// <summary>
    /// Instantly changes the light to the target brightness.
    /// </summary>
    Instant = 0,

    /// <summary>
    /// Gradually fades out the light over the specified duration.
    /// </summary>
    Fade = 1,

    /// <summary>
    /// Fades the light while also changing its color over time.
    /// </summary>
    ColorFade = 2,

    /// <summary>
    /// Mimics a sunrise by gradually increasing the brightness.
    /// </summary>
    Sunrise = 3
}
