using System.Text.Json;

namespace ZenestaMVC.Services
{
    public class MLService
    {
        private readonly HttpClient _httpClient;

        public MLService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://localhost:6060/");
        }
        public async Task<List<Dictionary<string, string>>> GetPrediction(IFormFile image)
        {
            MultipartFormDataContent multiPartContent = new();

            multiPartContent.Add(new StreamContent(image.OpenReadStream()), "image", image.FileName);

            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/predict", multiPartContent);
            string jsonStringResult = response.Content.ReadAsStringAsync().Result;

            Dictionary<string, List<Dictionary<string, string>>>? responseDict = JsonSerializer.Deserialize<Dictionary<string, List<Dictionary<string, string>>>>(jsonStringResult);

            return responseDict is null
                ? throw new NullReferenceException("Deserialized Json return null.")
                : responseDict["prediction_result"];
        }
    }
}
