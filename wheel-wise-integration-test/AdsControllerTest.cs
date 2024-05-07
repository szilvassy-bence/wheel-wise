using System.Net;
using wheel_wise.Data;
using Xunit.Abstractions;

namespace wheel_wise_integration_test;

[Collection("IntegrationTest")]
public class AdsControllerTest : IClassFixture<WheelWiseFactory>
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _outputHelper;
    private readonly WheelWiseFactory _factory;

    public AdsControllerTest(ITestOutputHelper testOutputHelper)
    {
        _factory = new WheelWiseFactory();
        _httpClient = _factory.CreateClient();
    }

    [Fact]
    public async Task GetAllReturnsOk()
    {
        var response = await _httpClient.GetAsync("/api/Ads");
        response.EnsureSuccessStatusCode();
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAdById()
    {
        var response = await _httpClient.GetAsync($"/api/Ads/555");
        var resContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteAdReturnsNoContentIfSuccessful()
    {
        var token = await Helper.LoginUser(_httpClient);
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var delResponse = await _httpClient.DeleteAsync($"/api/Ads/1");
        
        Assert.Equal( HttpStatusCode.NoContent, delResponse.StatusCode);
    }
    
    [Fact]
    public async Task DeleteAdReturnsNotFoundIfAdIsNotInDb()
    {
        var token = await Helper.LoginUser(_httpClient);
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var delResponse = await _httpClient.DeleteAsync($"/api/Ads/554320");
        
        Assert.Equal(HttpStatusCode.NotFound, delResponse.StatusCode);
    }
    
    [Fact]
    public async Task DeleteAdReturnUnAuthorized()
    {
        var delResponse = await _httpClient.DeleteAsync($"/api/Ads/5");
        
        Assert.Equal(HttpStatusCode.Unauthorized, delResponse.StatusCode);
    }
}