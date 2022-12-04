using System.Text;

namespace Shared.Models
{
	public class AggregatedTextAnalyzerResult
	{
		public List<string> LongestWords { get; set; } = new();
		public List<WordFrequency> TopWords { get; set; } = new();

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"Aggregated Result{Environment.NewLine}{Environment.NewLine}");
			sb.Append($"{Environment.NewLine}### Longest words:{Environment.NewLine}{Environment.NewLine}");
			foreach (var word in LongestWords)
			{
				sb.Append($"{word}{Environment.NewLine}");
			}
			sb.Append($"{Environment.NewLine}### Top words:{Environment.NewLine}{Environment.NewLine}");
			foreach (var word in TopWords)
			{
				sb.Append($"{word.Word} ({word.Frequency}){Environment.NewLine}");
			}
			return sb.ToString();
		}
	}
}
