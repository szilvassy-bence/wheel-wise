using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using wheel_wise.Contracts;
using wheel_wise.Data;
using Xunit.Abstractions;

namespace wheel_wise_integration_test;

public class AuthControllerTest
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _outputHelper;
    private readonly WheelWiseFactory _factory;


    public AuthControllerTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _factory = new WheelWiseFactory();
        _httpClient = _factory.CreateClient();
    }

    [Fact]
    public void SeededDataIsPresentInDb()
    {
        // Arrange
        using var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WheelWiseContext>();
        
        var userManager = dbContext.GetService<UserManager<IdentityUser>>();
        
        // Act
        var users = dbContext.Users.ToList();
        foreach (var user in users)
        {
            _outputHelper.WriteLine(user.ZipCode.ToString());
            //_outputHelper.WriteLine(user.IdentityUser.NormalizedUserName);
        }
        var identityUserAdmin = userManager.FindByEmailAsync("admin@admin.com").Result;
        
        // Assert
        Assert.NotNull(users);
        Assert.NotEmpty(users);
        Assert.NotNull(identityUserAdmin);
    }
    
    [Fact]
    public async Task RegisterReturnsSuccessStatusCode()
    {
        // Arrange
        var regRequest = new RegistrationRequest("t@t", "t", "1233445", 2000);
        var json = JsonSerializer.Serialize(regRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/Auth/Register", content);

        var responseString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
        var regResponse = JsonSerializer.Deserialize<RegistrationResponse>(responseString, options);
        
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(response.StatusCode, HttpStatusCode.Created);
        Assert.Equal(regRequest.Email, regResponse.Email);
    }
    
    
    [Fact]
    public async Task RegisterReturnsBadRequestStatusCode()
    {
        // Arrange
        var regRequest = new RegistrationRequest("tt", "t", "12321657", 2000);
        var json = JsonSerializer.Serialize(regRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/api/Auth/Register", content);

        var responseString = await response.Content.ReadAsStringAsync();
        
        // Assert
        Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task LoginReturnsOKIfSuccessful()
    {
        // Arrange
        var regRequest = new RegistrationRequest("t@t", "t", "12321657", 2000);
        var regJson = JsonSerializer.Serialize(regRequest);
        var regContent = new StringContent(regJson, Encoding.UTF8, "application/json");

        var regResponse = await _httpClient.PostAsync("/api/Auth/Register", regContent);
        regResponse.EnsureSuccessStatusCode();

        var authRequest = new AuthRequest("t@t", "12321657");
        var loginJson = JsonSerializer.Serialize(authRequest);
        var loginContent = new StringContent(loginJson, Encoding.UTF8, "application/json");

        var loginResponse = await _httpClient.PostAsync("/api/Auth/Login", loginContent);

        var loginResponseString = await loginResponse.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var authResponse = JsonSerializer.Deserialize<AuthResponse>(loginResponseString, options);

        loginResponse.EnsureSuccessStatusCode();
        Assert.Equal(loginResponse.StatusCode, HttpStatusCode.OK);
        Assert.Equal(authResponse.Email, authRequest.Email);
        Assert.NotNull(authResponse.Token);
    }
    [Fact]
    public async Task LoginAdminReturnsOKIfSuccessful()
    {
        var authRequest = new AuthRequest("admin@admin.com", "admin123");
        var loginJson = JsonSerializer.Serialize(authRequest);
        var loginContent = new StringContent(loginJson, Encoding.UTF8, "application/json");

        var loginResponse = await _httpClient.PostAsync("/api/Auth/Login", loginContent);

        var loginResponseString = await loginResponse.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var authResponse = JsonSerializer.Deserialize<AuthResponse>(loginResponseString, options);

        loginResponse.EnsureSuccessStatusCode();
        Assert.Equal(loginResponse.StatusCode, HttpStatusCode.OK);
        Assert.Equal(authResponse.Email, authRequest.Email);
        Assert.NotNull(authResponse.Token);
    }
}