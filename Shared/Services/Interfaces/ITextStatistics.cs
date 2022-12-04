using Shared.Models;

namespace Shared.Services.Interfaces
{
    public interface ITextStatisticsService
    {
        /**
		* Returns a list of the most frequented words of the text.
		* @param n how many items of the list
		* @return a list representing the top n frequent words of the text.
		*/
        List<WordFrequency> TopWords(string text, int n);

        /**
		* Returns a list of the longest words of the text.
		* @param n how many items to return.
		* @return a list with the n longest words of the text.
		*/
        List<string> LongestWords(string text, int n);
	}
}
