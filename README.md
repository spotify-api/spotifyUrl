# SpotifyUrl
A spotify-url-info parser without any api key!

# Example
Getting dominant color of track
```cs
using System;
using SpotifyUrl;

namespace Test {
public class Program {
public static void Main(string[] args){
var spotify = new UrlInfo();
var data = await spotify.getData("https://open.spotify.com/embed/track/44I5NYJ7CGEcaLOuG2zJsU");
Console.Write(data.dominantColor); // outputs #786B8E
  }
 }
}
```

# Installation

## Stable (NuGet)
Our stable builds available from NuGet through the SpotifyUrl metapackage:
- [SpotifyUrl](https://www.nuget.org/packages/SpotifyUrl)

## Compiling
In order to compile SpotifyUrl, you require the following:

### Using Visual Studio
- [Visual Studio 2017](https://www.microsoft.com/net/core#windowsvs2017)
- [.NET Core SDK](https://www.microsoft.com/net/download/core)

The .NET Core workload must be selected during Visual Studio installation.

### Using Command Line
- [.NET Core SDK](https://www.microsoft.com/net/download/core)
