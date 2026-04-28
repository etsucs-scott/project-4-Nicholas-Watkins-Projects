
Note before running, NAudio is a dependency for this project

### Building and running
```bash
dotnet build
dotnet run --project ProjectName.App
```

### Using the app
```
Using launch settings from src\Project4.UI\Properties\launchSettings.json...
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5258
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\path\to\project-4-Nicholas-Watkins-Projects\src\Project4.UI
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.To use the app, a browser should automatically open

This is what the terminal should look like. First open a browser to the http://localhost:XXXX. The numbers are typically different in the X spot.

Once opened, go to the Add Sound tab and input your sound

All clip names should be unique

The percent field is the chance the selected sound will play in the selected interval i.e. .5 is 50%

The interval field is either sec (second), min (minute), or hour. This will determine the interval for the chance
If percent is .5 and interval is second, then there is a 50% chance of the sound to play in a second.

You can press the test button to check if all fields are correct and to test the audio

If everything is correct, hit save sound and it will appear in the Sounds tab. Once in the sounds tab, it will continue to play until you hit the stop button.
```