
# Dependency Injection for WLedClient

This section provides details on how to integrate the `WLedClient` with the dependency injection (DI) system in your .NET application. This allows for easy management of the client and its configuration.

## Setting Up Dependency Injection

To register the `WLedClient` in your DI container, you can use the provided extension methods in the `WLedClientServiceExtensions` class. This enables you to configure the client with various settings, including the URL and the HTTP message handler.

### Adding WLedClient to the DI Container

You can add the `WLedClient` to your service collection using one of the following methods:

#### Configure with Action

```csharp
services.AddWLed(options =>
{
    options.Url = "http://your-wled-device/";
});
```

#### Configure with URL Only

```csharp
services.AddWLed("http://your-wled-device/");
```

#### Configure with URL and Custom HttpMessageHandler

```csharp
services.AddWLed("http://your-wled-device/", new HttpClientHandler());
```

#### Configure with WledSettings Object

```csharp
var settings = new WledSettings
{
    Url = "http://your-wled-device/",
    HttpMessageHandler = new HttpClientHandler()
};

services.AddWLed(settings);
```

### Accessing WLedClient in Your Application

Once the `WLedClient` has been registered in the DI container, you can easily inject it into your classes using constructor injection:

```csharp
public class MyService
{
    private readonly WLedClient _wledClient;

    public MyService(WLedClient wledClient)
    {
        _wledClient = wledClient;
    }

    public async Task DoSomethingWithWled()
    {
        var state = await _wledClient.GetStateAsync();
        // Do something with the state
    }
}
```

### Summary

By following these steps, you can efficiently integrate the `WLedClient` into your .NET application using dependency injection. This approach promotes better organization and testing practices by managing dependencies through the DI container.

For more information on dependency injection in .NET, refer to the [official documentation](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).
