using System.Net.Http;
using System.Threading.Tasks;

public class FileDownloader
{
    public static async Task<string> DownloadFile(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}