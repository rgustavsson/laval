using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services
{
	public class TextStatisticsService : ITextStatisticsService
	{
		private List<string> GetWordsFromText(string text)
		{
			List<string> words = new();
			
			if(string.IsNullOrEmpty(text))
			{
				return words;
			}

			var textLines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();
			foreach (var line in textLines)
			{
				var lineWords = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
				if(lineWords?.Count > 0)
				{
					words.AddRange(lineWords);
				}
			}
			return words;
		}

		public List<string> LongestWords(string text, int n)
		{
			var words = GetWordsFromText(text);
			words = words.Distinct().ToList();
			words = words.OrderByDescending(o => o.Length).ToList();
			return words.Take(n).ToList();
		}

		public List<WordFrequency> TopWords(string text, int n)
		{
			List<WordFrequency> wordFrequencies = new();
			
			var words = GetWordsFromText(text);
			var wordsGrouped = words
				.GroupBy(o => o)
				.OrderByDescending(o => o.Count())
				.ToList();

			for (int i = 0; i < n; i++)
			{
				var group = wordsGrouped[i];
				var wordFrequency = new WordFrequency()
				{
					Word = group.Key,
					Frequency = group.Count()
				};
				wordFrequencies.Add(wordFrequency);
			};
			return wordFrequencies;
		}
	}
}
