using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sortly.Api.Client;
using Sortly.Api.Configuration;
using Sortly.Api.Http;
using Sortly.Api.Model.Request;

const string API = "Api";
const string API_KEY = "Key";
const string APP_SETTINGS = "appsettings.json";

static IHostBuilder CreateHostBuilder(string[] args)
{
    var hostBuilder = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddCommandLine(args);
            builder.AddJsonFile(APP_SETTINGS, optional: false, reloadOnChange: true);
            builder.AddEnvironmentVariables();
        })
        .ConfigureServices((context, services) =>
        {
            services.AddHttpClient();
            services.AddSingleton<ISortlyApiAdapter, SortlyApiAdapter>();
            services.AddSingleton<ISortlyClient, SortlyClient>();

            // NOTE: update appsettings.json with your api key
            services.AddSingleton(new SortlyApiConfiguration()
            {
                ApiBearerToken = context.Configuration[$"{API}:{API_KEY}"]
            });
        });

    return hostBuilder;
}

var host = CreateHostBuilder(args).Build();

///
/// Use Sortly API client to load and display item ids
///
static void ListItems(ISortlyClient client) 
{
    // build query parameters
    var request = new ListItemsRequest()
        .WithPerPage(10) // add parameters with methods
        .IncludeCustomAttributes(); // or include properties for the response

    var listItems = client.Item.ListItems(request).Result;

    Console.WriteLine("Listing item ids...");
    // list response item ids
    foreach (var li in listItems.Data)
        Console.WriteLine(li.Id);
}

///
/// Use Sortly API client to load and display alert ids
///
static void ListAlerts(ISortlyClient client)
{
    // build query parameters
    var request = new ListAlertsRequest()
        .WithPerPage(10); // add parameters with methods

    var alerts = client.Alert.ListAlerts(request).Result;

    Console.WriteLine("Listing alert ids...");
    // list response item ids
    foreach (var li in alerts.Data)
        Console.WriteLine(li.Id);
}

///
/// Use Sortly API client to load and display alert ids
///
static void ListUnitsOfMeasure(ISortlyClient client)
{
    var units = client.UnitsOfMeasure.ListUnitsOfMeasure().Result;

    Console.WriteLine("Listing alert ids...");
    // list response item ids
    foreach (var li in units)
        Console.WriteLine(li.PrettyName);
}

try
{
    var client = host.Services.GetService<ISortlyClient>();

    ListItems(client);
    ListAlerts(client);
    ListUnitsOfMeasure(client);

    Console.WriteLine("Finished");
}
catch (Exception e)
{
    Console.WriteLine("Exception occurred!");
    Console.WriteLine(e.Message);
}

Console.WriteLine("Press any key to close");
Console.ReadKey();