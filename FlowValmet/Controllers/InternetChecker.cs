using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

public class InternetChecker
{
    private readonly HttpClient _httpClient;
    private readonly string[] _testUrls = {
        "https://www.google.com",
        "https://www.microsoft.com",
        "https://www.cloudflare.com"
    };

    public InternetChecker()
    {
        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(3)
        };
    }

    public async Task<bool> HasInternetAccessAsync()
    {
        // Verifica primeiro se há conexão de rede
        if (!NetworkInterface.GetIsNetworkAvailable())
            return false;

        // Testa vários endpoints para maior confiabilidade
        foreach (var url in _testUrls)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                    return true;
            }
            catch
            {
                // Ignora erros e tenta o próximo endpoint
            }
        }

        return false;
    }
}