using Shared.Services;
using Shared.Services.Interfaces;

namespace TextAnalyzerApiServer.Configuration.Startup
{
	public static class ConfigureScopedStartupExtension
	{
		public static void ConfigureScoped(this IServiceCollection services)
		{
			services.AddScoped<ITextAnalyzerService, TextAnalyzerService>();
			services.AddScoped<ITextStatisticsService, TextStatisticsService>();
			services.AddScoped<ITextDataStore, ExternalTextDataStore>();
		}
	}
}
