using System.Net.Http.Json;
using System.Text.Json.Serialization;

public class CoinGeckoService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public CoinGeckoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        // Get the base URL and API key from configuration
        var baseUrl = configuration["CoinGeckoApi:BaseUrl"];
        _apiKey = configuration["CoinGeckoApi:ApiKey"];

        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("API Key is not configured.");
        }

        if (!baseUrl.EndsWith("/"))
        {
            baseUrl += "/";
        }

        _httpClient.BaseAddress = new Uri(baseUrl);

        // Add a User-Agent header
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyApp/1.0");
    }


    public async Task<List<Coin>> GetCoinsAsync(string currency = "usd", int page = 1, int perPage = 50)
    {
        // Do not start relative URL with a leading slash
        var url = $"coins/markets?vs_currency={currency}&order=market_cap_desc&per_page={perPage}&page={page}&x_cg_demo_api_key={_apiKey}";

        var response = await _httpClient.GetAsync(url);

        // Log or handle errors for better debugging
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}. Content: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<List<Coin>>();
    }
}

 
public class Coin
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("current_price")]
    public decimal CurrentPrice { get; set; }

    [JsonPropertyName("market_cap")]
    public decimal MarketCap { get; set; }

    [JsonPropertyName("market_cap_rank")]
    public int MarketCapRank { get; set; }

    [JsonPropertyName("fully_diluted_valuation")]
    public decimal? FullyDilutedValuation { get; set; }

    [JsonPropertyName("total_volume")]
    public decimal TotalVolume { get; set; }

    [JsonPropertyName("high_24h")]
    public decimal High24h { get; set; }

    [JsonPropertyName("low_24h")]
    public decimal Low24h { get; set; }

    [JsonPropertyName("price_change_24h")]
    public decimal PriceChange24h { get; set; }

    [JsonPropertyName("price_change_percentage_24h")]
    public decimal PriceChangePercentage24h { get; set; }

    [JsonPropertyName("market_cap_change_24h")]
    public decimal MarketCapChange24h { get; set; }

    [JsonPropertyName("market_cap_change_percentage_24h")]
    public decimal MarketCapChangePercentage24h { get; set; }

    [JsonPropertyName("circulating_supply")]
    public decimal CirculatingSupply { get; set; }

    [JsonPropertyName("total_supply")]
    public decimal? TotalSupply { get; set; }

    [JsonPropertyName("max_supply")]
    public decimal? MaxSupply { get; set; }

    [JsonPropertyName("ath")]
    public decimal AllTimeHigh { get; set; }

    [JsonPropertyName("ath_change_percentage")]
    public decimal AllTimeHighChangePercentage { get; set; }

    [JsonPropertyName("ath_date")]
    public DateTime AllTimeHighDate { get; set; }

    [JsonPropertyName("atl")]
    public decimal AllTimeLow { get; set; }

    [JsonPropertyName("atl_change_percentage")]
    public decimal AllTimeLowChangePercentage { get; set; }

    [JsonPropertyName("atl_date")]
    public DateTime AllTimeLowDate { get; set; }

    [JsonPropertyName("roi")]
    public object Roi { get; set; } // Update this if ROI has a specific structure

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }
}
