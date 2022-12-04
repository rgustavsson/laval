namespace Shared.Services.Interfaces
{
	public interface ITextDataStore
	{
		Task<string> GetText(string path);
	}
}
