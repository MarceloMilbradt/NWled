# WLedClient

`WLedClient` is a .NET class that provides an easy interface for interacting with the WLED API. This client allows you to manage and control your WLED devices over HTTP, offering methods to retrieve and update various settings.

## Features

### Initialization

You can initialize the `WLedClient` with a custom `HttpMessageHandler` and a base URI:

```csharp
var client = new WLedClient(new HttpClientHandler(), "http://your-wled-device/");
```

### Methods

#### GetAsync

Retrieves the current state of the WLED device.

```csharp
var wledRoot = await client.GetAsync();
```

#### GetStateAsync

Fetches the current state, including the On/Off status, brightness, and other parameters.

```csharp
var state = await client.GetStateAsync();
```

#### GetInformationAsync

Gets information about the WLED device, including version, build ID, and capabilities.

```csharp
var information = await client.GetInformationAsync();
```

#### GetEffectsAsync

Retrieves a list of available effects that can be applied to the WLED device.

```csharp
var effects = await client.GetEffectsAsync();
```

#### GetPalettesAsync

Fetches a list of color palettes available for the WLED device.

```csharp
var palettes = await client.GetPalettesAsync();
```

#### PostAsync

Sends a request to update the WLED device's configuration with the provided request object.

```csharp
var request = new WLedRootRequest { /* set properties */ };
await client.PostAsync(request);
```

#### PostAsync (State)

Sends a request to update the state of the WLED device.

```csharp
var stateRequest = new StateRequest { /* set properties */ };
await client.PostAsync(stateRequest);
```
