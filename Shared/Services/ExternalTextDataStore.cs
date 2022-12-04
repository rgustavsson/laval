using Shared.Services.Interfaces;

namespace Shared.Services
{
	public class ExternalTextDataStore : ITextDataStore
    {
        public async Task<string> GetText(string path)
        {
			using (var client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(path);
					if(response.IsSuccessStatusCode) 
					{
						Console.WriteLine($"Fetching text from: {path}");
						var responseString = await response.Content.ReadAsStringAsync();
						return responseString;
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine($"{exception.Message}, {exception.StackTrace}");
				}
			}
			return null;
		}
    }
}
