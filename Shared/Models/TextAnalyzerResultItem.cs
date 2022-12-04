using System.Text;

namespace Shared.Models
{
	public class TextAnalyzerResultItem
	{
		public string Id { get; set; }
		public string Text { get; set; }
		public List<string> LongestWords { get; set; } = new();
		public List<WordFrequency> TopWords { get; set; } = new ();

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"Id: {Id}{Environment.NewLine}");
			sb.Append(Environment.NewLine);
			sb.Append($"### Longest words:{Environment.NewLine} {Environment.NewLine}");
			foreach (var word in LongestWords)
			{
				sb.Append($"{word}{Environment.NewLine}");
			}
			sb.Append(Environment.NewLine);
			sb.Append($"### Top words:{Environment.NewLine} {Environment.NewLine}");
			foreach (var word in TopWords)
			{
				sb.Append($"{word.Word} ({word.Frequency}){Environment.NewLine}");
			}
			return sb.ToString();
		}
	}
}
