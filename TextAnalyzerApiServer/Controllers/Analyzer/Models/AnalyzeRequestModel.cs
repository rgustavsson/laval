using System.ComponentModel.DataAnnotations;

namespace TextAnalyzerApiServer.Controllers.Analyzer.Models
{
	public class AnalyzeRequestModel
	{
		[Required]
		public List<string> Urls { get; set; } = new List<string>();
		public bool IncludeTexts { get; set; }
	}
}
