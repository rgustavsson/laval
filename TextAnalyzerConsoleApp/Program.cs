using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Services;
using Shared.Services.Interfaces;

IConfiguration config = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json")
		.AddEnvironmentVariables()
		.Build();

using IHost host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((_, services) =>
		services
		.AddScoped<ITextAnalyzerService, TextAnalyzerService>()
		.AddScoped<ITextStatisticsService, TextStatisticsService>()
		.AddScoped<ITextDataStore, ExternalTextDataStore>())
	.Build();

var textAnalyzerFrequencyService = host.Services.GetRequiredService<ITextAnalyzerService>();

string arg1 = Environment.GetCommandLineArgs()[1];
if (arg1 == null)
{
	Console.WriteLine("No arguments detected. The program expects a comma separated list of urls as first argument.");
}
else
{
	var paths = arg1.Split(",").ToList();
	Console.WriteLine($"Analyzing text from {paths.Count} urls..");
	var result = textAnalyzerFrequencyService.AnalyzeTextsFromUrls(paths).Result;
	Console.WriteLine("Download complete. Printing results..");
	Console.WriteLine("");
	Console.WriteLine("#################################################################");
	Console.WriteLine("");

	for (int i = 0; i < result.ResultItems.Count; i++)
	{
		var resultItem = result.ResultItems[i];
		Console.WriteLine($"Url #{i+1}");
		Console.WriteLine(resultItem.ToString());
		Console.WriteLine("");
		Console.WriteLine("#################################################################");
		Console.WriteLine("");
	}
	Console.WriteLine(result.AggregatedResult.ToString());
}
await host.RunAsync();