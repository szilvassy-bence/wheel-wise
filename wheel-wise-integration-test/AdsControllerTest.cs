using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using wheel_wise.Contracts;
using wheel_wise.Data;
using wheel_wise.Model;
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
        _outputHelper = testOutputHelper;
    }

    [Fact]
    public async Task GetAllReturnsOk()
    {
        var response = await _httpClient.GetAsync("/api/Ads");
        response.EnsureSuccessStatusCode();
        Assert.Equal(response.StatusCode, HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetAdById_ReturnsNotFound()
    {
        var response = await _httpClient.GetAsync($"/api/Ads/555");
        var resContent = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [Fact]
    public async Task GetAdById_ReturnsOkIfAdIsFound()
    {
        var response = await _httpClient.GetAsync($"/api/Ads/1");
        
        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        var responseGet = JsonSerializer.Deserialize<Advertisement>(responseString, options);
        _outputHelper.WriteLine(responseGet.Id.ToString());
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(1, responseGet.Id);

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
    
    [Fact]
    public async Task PostAd_ReturnsCreatedIfSuccessful()
    {
        var token = await Helper.LoginUser(_httpClient);

        AdvertisementPostRequest ad = new AdvertisementPostRequest
        {
            Brand = "Opel",
            Model = "Astra",
            Color = "White",
            Description = "Description",
            FuelType = "Diesel",
            Mileage = 100,
            Power = 70,
            Price = 10000,
            Status = "New",
            Transmission = "Manual",
            Year = 1990,
            UserName = "user",
            Title = "Title",
            Equipments = new Dictionary<int, bool>()
        };
        var json = JsonSerializer.Serialize(ad);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.PostAsync($"/api/Ads", content);
        
        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        var postResponse = JsonSerializer.Deserialize<Advertisement>(responseString, options);
        
        Assert.Equal( HttpStatusCode.Created, response.StatusCode);
        Assert.Equal( ad.UserName, postResponse.User.UserName);
        Assert.Equal( ad.Description, postResponse.Description);
        Assert.Equal( ad.Brand, postResponse.Car.CarType.Brand);
        Assert.Equal( ad.Price, postResponse.Car.Price);
        Assert.Equal( Status.New, postResponse.Car.Status);
    }
    
    [Fact]
    public async Task DeleteAdReturnsNoContentIfSuccessful()
    {
        var token = await Helper.LoginUser(_httpClient);
        
        AdvertisementPostRequest ad = new AdvertisementPostRequest
        {
            Brand = "Opel",
            Model = "Astra",
            Color = "White",
            Description = "Description",
            FuelType = "Diesel",
            Mileage = 100,
            Power = 70,
            Price = 10000,
            Status = "New",
            Transmission = "Manual",
            Year = 1990,
            UserName = "user",
            Title = "Title",
            Equipments = new Dictionary<int, bool>()
        };
        var json = JsonSerializer.Serialize(ad);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.PostAsync($"/api/Ads", content);
        var postResponseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        var postResponse = JsonSerializer.Deserialize<Advertisement>(postResponseString, options);
        
        Assert.Equal( HttpStatusCode.Created, response.StatusCode);
        Assert.Equal( 21, postResponse.Id);
        
        var getrequest = await _httpClient.GetAsync($"/api/Ads/21");
        var getResponseString = await getrequest.Content.ReadAsStringAsync();
        var getResponse = JsonSerializer.Deserialize<Advertisement>(getResponseString, options);
        
        var delResponse = await _httpClient.DeleteAsync($"/api/Ads/21");
        
        Assert.Equal( HttpStatusCode.NoContent, delResponse.StatusCode);
    }
    
    
    [Fact]
    public async Task PutAdById_ReturnsOkIfSuccessful()
    {
        var token = await Helper.LoginUser(_httpClient);
        
        AdvertisementPostRequest ad = new AdvertisementPostRequest
        {
            Brand = "Opel",
            Model = "Astra",
            Color = "White",
            Description = "Description",
            FuelType = "Diesel",
            Mileage = 100,
            Power = 70,
            Price = 10000,
            Status = "New",
            Transmission = "Manual",
            Year = 1990,
            UserName = "user",
            Title = "Title",
            Equipments = new Dictionary<int, bool>()
        };
        var json = JsonSerializer.Serialize(ad);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var response = await _httpClient.PostAsync($"/api/Ads", content);
        var postResponseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        var postResponse = JsonSerializer.Deserialize<Advertisement>(postResponseString, options);
        
        Assert.Equal( HttpStatusCode.Created, response.StatusCode);
        Assert.Equal( 21, postResponse.Id);
        
        AdvertisementPostRequest modifiedProperties = new AdvertisementPostRequest
        {
            Brand = "Honda",
            Model = "Civic",
            Color = "Black",
            Description = "ModifiedDescription",
            FuelType = "Petrol",
            Mileage = 200,
            Power = 100,
            Price = 20000,
            Status = "Broken",
            Transmission = "Automatic",
            Year = 2000,
            UserName = "user",
            Title = "Title2",
            Equipments = new Dictionary<int, bool>()
        };
        var jsonForModified = JsonSerializer.Serialize(modifiedProperties);
        var contentForModified = new StringContent(jsonForModified, Encoding.UTF8, "application/json");
        
        var updateResponse = await _httpClient.PutAsync($"/api/Ads/21", contentForModified);
        var updateResponseString = await updateResponse.Content.ReadAsStringAsync();
        var updateResponseDeserialized = JsonSerializer.Deserialize<Advertisement>(updateResponseString, options);
        
        Assert.Equal( HttpStatusCode.OK, updateResponse.StatusCode);
        Assert.Equal( 21, updateResponseDeserialized.Id);
        Assert.Equal( "Title2", updateResponseDeserialized.Title);
        Assert.Equal( modifiedProperties.Brand, updateResponseDeserialized.Car.CarType.Brand);
        Assert.Equal( 2000, updateResponseDeserialized.Car.Year);
    }
}