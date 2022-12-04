namespace Shared.Models
{
	public class TextAnalyzerResult
	{
		public AggregatedTextAnalyzerResult AggregatedResult 
		{
			get 
			{
				var result = new AggregatedTextAnalyzerResult();

				foreach (var item in ResultItems)
				{
					if(item.LongestWords.Any())
					{
						result.LongestWords.AddRange(item.LongestWords);
					}
					if (item.TopWords.Any())
					{
						foreach (var word in item.TopWords)
						{
							var existingTopWord = result.TopWords.FirstOrDefault(o => o.Word == word.Word);
							if(existingTopWord == null)
							{
								result.TopWords.Add(word);
							}
							else 
							{
								existingTopWord.Frequency += word.Frequency;
							}
						}
					}
				}

				result.LongestWords = result.LongestWords.OrderByDescending(o => o.Length).Distinct().Take(20).ToList();
				result.TopWords = result.TopWords.OrderByDescending(o => o.Frequency).Take(10).ToList();
				return result;
			}
		}
		public List<TextAnalyzerResultItem> ResultItems { get; set; } = new();
	}
}
