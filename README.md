# NWled

NWled is a .NET library for interacting with [WLED](https://github.com/Aircoookie/WLED) devices over HTTP. It provides an easy-to-use client for controlling and configuring your WLED lights through their [JSON API](https://github.com/Aircoookie/WLED/wiki/JSON-API).

[![install from nuget](http://img.shields.io/nuget/v/NWLED.svg?style=flat-square)](https://www.nuget.org/packages/NWled/)
[![install from nuget](http://img.shields.io/nuget/v/NWLED.svg?style=flat-square)](https://www.nuget.org/packages/NWled.DependencyInjection/)


## Features

- Get information about connected WLED devices.
- Control LED states, effects, and palettes.
- Support for dependency injection with .NET Core.
- Configurable through app settings.

## Installation

You can install NWled via NuGet:

```bash
dotnet add package NWled
```

## Usage

### Basic Setup

First, register the `WLedClient` in your `Startup.cs` or wherever you configure your services:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddWLed(options =>
    {
        options.Url = "http://your-wled-device-url";
    });
}
```

### Example Usage

Here’s an example of how to use the `WLedClient`:

```csharp
public class YourService
{
    private readonly WLedClient _wledClient;

    public YourService(WLedClient wledClient)
    {
        _wledClient = wledClient;
    }

    public async Task GetWledInformationAsync()
    {
        var info = await _wledClient.GetInformationAsync();
        Console.WriteLine($"WLED Version: {info.VersionName}");
    }
}
```

### Configuration

You can configure the `WLedClient` settings in your `appsettings.json`:

```json
{
  "Wled": {
    "Url": "http://your-wled-device-url"
  }
}
```

### Dependency Injection

The `WLedClient` is registered as a singleton, and it can be configured using the `IOptions<WledSettings>` pattern.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddWLed(Configuration.GetSection("Wled"));
}
```

## Contributing

Contributions are welcome! If you have suggestions for improvements or find bugs, feel free to create an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Author

- Marcelo Milbradt ([@MarceloMilbradt](https://github.com/MarceloMilbradt))

