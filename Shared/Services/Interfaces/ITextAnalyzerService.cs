using Shared.Models;

namespace Shared.Services.Interfaces
{
	public interface ITextAnalyzerService
	{
		TextAnalyzerResult AnalyzeTexts(List<AnalyzeTextItem> texts);
		Task<TextAnalyzerResult> AnalyzeTextsFromUrls(List<string> urls);
	}
}
