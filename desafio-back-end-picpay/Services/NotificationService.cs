using desafio_back_end_picpay.Models;
using Newtonsoft.Json;

namespace desafio_back_end_picpay.Services;

public static class NotificationService
{
    public static  async Task<bool> CallNotificationService()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = "https://run.mocky.io/v3/54dc2cf1-3add-45b5-b5a9-6bf7e7f1f4a6";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ServiceModel>(responseContent);

                    return result != null && result.Message == "true";
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
