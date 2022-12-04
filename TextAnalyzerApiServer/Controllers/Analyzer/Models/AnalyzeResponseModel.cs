using Shared.Models;

namespace TextAnalyzerApiServer.Controllers.Analyzer.Models
{
	public class AnalyzeResponseModel
	{
		public List<TextAnalyzerResultItem> ResultItems { get; set; } = new();
	}
}
