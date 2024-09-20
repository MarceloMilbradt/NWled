using Microsoft.Extensions.Options;
using NWLED;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for registering the WLedClient in the dependency injection container.
/// </summary>
public static class WLedClientServiceExtensions
{
    /// <summary>
    /// Registers the WLedClient and configures it using the provided configuration action.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configure">The action to configure WledSettings.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddWLed(this IServiceCollection services, Action<WledSettings> configure)
    {
        // Configure WledSettings using the provided action
        services.Configure(configure);

        // Register WLedClient as a singleton service
        services.AddSingleton<IWLedClient>(provider =>
        {
            // Retrieve the configured WledSettings
            var options = provider.GetRequiredService<IOptions<WledSettings>>();
            // Create and return a new instance of WLedClient with the specified handler and URL
            return new WLedClient(options.Value.HttpMessageHandler ?? new HttpClientHandler(), options.Value.Url);
        });

        return services; // Return the updated services collection
    }

    /// <summary>
    /// Registers the WLedClient with the specified URL.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="url">The URL to configure for the WLedClient.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddWLed(this IServiceCollection services, string url)
    {
        // Call the overloaded AddWLed method with a configuration action that sets the URL
        return AddWLed(services, configure =>
        {
            configure.Url = url;
        });
    }

    /// <summary>
    /// Registers the WLedClient with the specified URL and HttpMessageHandler.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="url">The URL to configure for the WLedClient.</param>
    /// <param name="httpMessageHandler">The HttpMessageHandler to use for the WLedClient.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddWLed(this IServiceCollection services, string url, HttpMessageHandler httpMessageHandler)
    {
        // Call the overloaded AddWLed method with a configuration action that sets the URL and handler
        return AddWLed(services, configure =>
        {
            configure.Url = url;
            configure.HttpMessageHandler = httpMessageHandler;
        });
    }

    /// <summary>
    /// Registers the WLedClient with the specified WledSettings.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="settings">The WledSettings to configure for the WLedClient.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddWLed(this IServiceCollection services, WledSettings settings)
    {
        // Call the overloaded AddWLed method with a configuration action that sets the properties from WledSettings
        return AddWLed(services, configure =>
        {
            configure.Url = settings.Url;
            configure.HttpMessageHandler = settings.HttpMessageHandler;
        });
    }
}
