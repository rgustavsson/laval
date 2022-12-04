using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services
{
	public class TextAnalyzerService : ITextAnalyzerService
	{
		private readonly ITextStatisticsService _textStatisticsService;
		private readonly ITextDataStore _dataStore;

		public TextAnalyzerService(
			ITextStatisticsService textStatisticsService,
			ITextDataStore dataStore)
		{
			_textStatisticsService = textStatisticsService;
			_dataStore = dataStore;
		}

		public TextAnalyzerResult AnalyzeTexts(List<AnalyzeTextItem> texts)
		{
			var analyzerResult = new TextAnalyzerResult();
			foreach (var item in texts)
			{
				var textAnalyzerResultItem = new TextAnalyzerResultItem
				{
					Id = item.Id,
					Text = item.Text,
					LongestWords = _textStatisticsService.LongestWords(item.Text, 10),
					TopWords = _textStatisticsService.TopWords(item.Text, 20)
				};
				analyzerResult.ResultItems.Add(textAnalyzerResultItem);
			}
			return analyzerResult;
		}

		public async Task<TextAnalyzerResult> AnalyzeTextsFromUrls(List<string> urls)
		{
			var textsToAnalyze = new List<AnalyzeTextItem>();
			foreach (var url in urls)
			{
				var analyzeTextItem = new AnalyzeTextItem
				{
					Id = url,
					Text = await _dataStore.GetText(url)
				};
				textsToAnalyze.Add(analyzeTextItem);
			}

			return AnalyzeTexts(textsToAnalyze);
		}
	}
}
