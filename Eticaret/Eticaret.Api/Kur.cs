using System.Text.Json;

namespace Eticaret.Api
{
    public class Kur
    {
        public async Task<Model.Kur?> KurCek()
        {
            string url = "https://api.currencyapi.com/v3/latest?apikey=5bdef440-688a-11ec-a415-8765895e1e50&currencies=TRY";

            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Model.Kur kur = JsonSerializer.Deserialize<Model.Kur>(responseBody)!;
                return kur;
            }

            return null;
        }
    }
}
