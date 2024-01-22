using desafio_back_end_picpay.Models;
using Newtonsoft.Json;

namespace desafio_back_end_picpay.Services;

public static class AuthorizationService
{
    public static async Task<bool> CallAuthorizationService()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = "https://run.mocky.io/v3/5794d450-d2e2-4412-8131-73d0293ac1cc";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ServiceModel>(responseContent);

                    return result != null && result.Message == "Autorizado";
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
