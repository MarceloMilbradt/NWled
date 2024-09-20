# NWled

NWled is a .NET library for interacting with [WLED](https://github.com/Aircoookie/WLED) devices over HTTP. It provides an easy-to-use client for controlling and configuring your WLED lights through their [JSON API](https://github.com/Aircoookie/WLED/wiki/JSON-API).

[![install from nuget](http://img.shields.io/nuget/v/NWLED.svg?style=flat-square)](https://www.nuget.org/packages/NWled/)
[![install from nuget](http://img.shields.io/nuget/v/NWLED.svg?style=flat-square)](https://www.nuget.org/packages/NWled.DependencyInjection/)

## Features

- **WLedClient**: A client to interact with WLed devices.
- **Dependency Injection**: Simplified registration of the WLedClient in the DI container.

## Getting Started

### Installation

You can install the NWled library via NuGet. Run the following command in your package manager console:

```bash
dotnet add package NWled
```

To install the Dependency Injection package, use:

```bash
dotnet add package NWled.DependencyInjection
```

### Using the WLedClient

To use the `WLedClient`, follow these steps:

1. **Create an instance of `WLedClient`:**

   ```csharp
   var client = new WLedClient("http://your-wled-device-ip");
   ```

2. **Make requests to the WLed API:**

   - **Get the current state:**

     ```csharp
     var state = await client.GetStateAsync();
     ```

   - **Get information about the device:**

     ```csharp
     var info = await client.GetInformationAsync();
     ```

   - **Post a new state:**

     ```csharp
     var stateRequest = new StateRequest { On = true, Brightness = 128 };
     await client.PostAsync(stateRequest);
     ```

3. **Handle the results as needed:**

   The responses can be handled as desired, depending on your application needs.

### Dependency Injection

NWled provides an easy way to register the `WLedClient` using Dependency Injection.

#### Registering WLedClient in DI

You can register the `WLedClient` in your DI container by using the `AddWLed` method:

1. **Add the WLedClient:**

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddWLed("http://your-wled-device-ip");
   }
   ```

2. **Using WLedClient in your application:**

   After registration, you can inject `WLedClient` into your classes:

   ```csharp
   public class MyService
   {
       private readonly WLedClient _wledClient;

       public MyService(WLedClient wledClient)
       {
           _wledClient = wledClient;
       }

       public async Task DoSomethingWithWLed()
       {
           var state = await _wledClient.GetStateAsync();
           // Implement your logic here
       }
   }
   ```


### Conclusion

NWled provides a straightforward way to integrate WLed device control into your .NET applications. Whether you prefer using the client directly or through Dependency Injection, NWled simplifies the process and allows you to focus on building your application.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
