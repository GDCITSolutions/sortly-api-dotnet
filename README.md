
# **Sortly .NET API**

Open source library for v1 of the [Sortly API](https://sortlyapi.docs.apiary.io/). This library provides a programmable interface for .NET based languages (C# and VB.NET).

## Getting Started

The Sortly .NET API is [available on NuGet](https://www.nuget.org/packages/Sortly.Api/):

```

dotnet add package Sortly.Api

```

## Quick Examples

Initial client setup:

```c#

// initialize DI container and get the client
var client = host.Services.GetService<ISortlyClient>();

```
Requesting all items:

```c#

// build query parameters
var request = new ListItemsRequest()
    .WithPerPage(10) // add parameters with methods
    .IncludeCustomAttributes(); // or include properties for the response

var listItems = client.Item.ListItems(request).Result;

foreach (var li in listItems.Data)
    Console.WriteLine(li.Id);

// Item: <id>
// Item: <id>
...
// etc.

```


## Basic Usage Example

A basic functional example application exists [here](/src/Sortly.Examples/Console/HelloWorld/).

```c#
  /// <summary>
  /// Executes basic request to list information from your Sortly API instance.
  /// </summary>
  static void ListInformation()
  {
      // build query parameters
      var request = new ListItemsRequest()
          .WithPerPage(10) // add parameters with methods
          .IncludeCustomAttributes(); // or include properties for the response
      
      var listItems = _client.Item.ListItems(request).Result;
      
      foreach (var li in listItems.Data)
          Console.WriteLine(li.Id);
  }
```

## Supported Frameworks

- [.NET 6.0.0](https://dotnet.microsoft.com/download/dotnet/6.0) (or greater)

## Available Clients

- [Item Client](/src/Sortly.Api/Client/ItemClient.cs) 
  - https://sortlyapi.docs.apiary.io/#reference/0/items
- [Item Group Client](/src/Sortly.Api/Client/ItemGroupClient.cs) 
  - https://sortlyapi.docs.apiary.io/#reference/0/item-variants-groups
- [Alert Client](/src/Sortly.Api/Client/AlertClient.cs) 
  - https://sortlyapi.docs.apiary.io/#reference/0/alerts
- [Custom Fields Client](/src/Sortly.Api/Client/CustomFieldClient.cs) 
  - https://sortlyapi.docs.apiary.io/#reference/0/custom-fields/attributes
- [Units of Measure Client](/src/Sortly.Api/Client/UnitsOfMeasureClient.cs) 
  - https://sortlyapi.docs.apiary.io/#reference/0/units-of-measure

## Support

Support is provided by [GDC IT Solutions](https://gdcitsolutions.com/).  For any issues or requests, please submit an Issue. This library is a result of open sourcing integration efforts and in no way affiliated Sortly, Inc.

Want to contribute? Feel free to submit a Pull Request to the team!

<img src="https://gdcitsolutions.com/wp-content/uploads/GDC-Logo-Main-Tagline-Alt-Reversed-01.png"  alt="GDC IT Solutions" width="250"/>
