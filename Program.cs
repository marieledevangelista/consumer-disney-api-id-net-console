using System.Net.Http;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();

        string url = "https://api.disneyapi.dev/character/423";

        string json = await client.GetStringAsync(url);

        DisneyResponse? resposta = JsonSerializer.Deserialize<DisneyResponse>(json);

        if (resposta != null && resposta.data != null)
        {
            Console.WriteLine("Nome:");
            Console.WriteLine(resposta.data.name);

            Console.WriteLine();
            Console.WriteLine("Imagem:");
            Console.WriteLine(resposta.data.imageUrl);
        }
    }
}

class DisneyResponse
{
    public DisneyCharacter? data { get; set; }
}

class DisneyCharacter
{
    public int _id { get; set; }
    public string? name { get; set; }
    public string? imageUrl { get; set; }
}
