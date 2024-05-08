using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using wheel_wise.Controllers;
using wheel_wise.Model;
using wheel_wise.Service.Repository.CarTypeRepo;
using wheel_wise.Service.Repository.UserRepo;

namespace wheel_wise_unit_test;

public class CarTypeControllerTest
{
    private Mock<ILogger<CarTypeController>> _loggerMock;
    private Mock<ICarTypeRepository> _carTypeRepositoryMock;
    private Mock<IUserRepository> _userRepositoryMock;
    private CarTypeController _controller;
    
    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<CarTypeController>>();
        _carTypeRepositoryMock = new Mock<ICarTypeRepository>();
        _userRepositoryMock = new Mock<IUserRepository>();

        _controller = new CarTypeController(_loggerMock.Object, _carTypeRepositoryMock.Object, _userRepositoryMock.Object);
    }
    
    
    //get all
    [Test]
    public async Task GetAllReturnsOkResult()
    {
        // Arrange
        var carTypeList = new List<CarType> { new CarType { Id = 1, Brand = "Suzuki", Model = "Swift"}, new CarType { Id = 2, Brand = "Toyota", Model = "Yaris"} };
        _carTypeRepositoryMock.Setup(ctr => ctr.GetAll()).ReturnsAsync(carTypeList);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }
    
    //get by brand
    [Test]
    public async Task GetByBrandReturnsOkResult()
    {
        // Arrange
        var carType = new CarType { Id = 1, Brand = "TestBrand", Model = "TestModel" };
        _carTypeRepositoryMock.Setup(ctr => ctr.GetByCarModel(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(carType);

        // Act
        var result = await _controller.GetByBrand("TestBrand", "TestModel");

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }
    
    [Test]
    public async Task GetByBrandReturnsNotFoundResultWhenNoCarTypeFound()
    {
        // Arrange
        _carTypeRepositoryMock.Setup(ctr => ctr.GetByCarModel(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((CarType)null);

        // Act
        var result = await _controller.GetByBrand("Brand", "Model");

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
    }
    
    
    //post car
    [Test]
    public async Task AddCarTypeReturnsCreatedAtActionAsAdmin()
    {
        // Arrange
        var carType = new CarType {Id = 1, Brand = "TestBrand", Model = "TestModel"};
        _carTypeRepositoryMock.Setup(repo => repo.Add(It.IsAny<CarType>())).Returns(Task.CompletedTask);
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Admin") }));
        _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

        // Act
        var result = await _controller.AddCarType(carType);

        // Assert
        Assert.That(result,Is.InstanceOf<CreatedAtActionResult>());
    }
    
    [Test]
    public async Task AddCarTypeReturnsCreatedAtActionWithNoAdmin()
    {
        // Arrange
        var carType = new CarType { Id = 1, Brand = "TestBrand", Model = "TestModel" };
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "User") }));
        _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };

        // Act
        var result = await _controller.AddCarType(carType);

        // Assert
        Assert.That(result, Is.InstanceOf<ForbidResult>());
    }

    [Test]
    public async Task DeleteCarTypeReturnsNoContentWithAdmin()
    {
        //Arrange
        var carType = new CarType { Id = 1, Brand = "TestBrand", Model = "TestModel" };
        _carTypeRepositoryMock.Setup(crt => crt.GeById(It.IsAny<int>())).ReturnsAsync(carType);
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Admin") }));
        _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        
        //Act
        var result = await _controller.DeleteCarType(1);
        
        //Assert
        Assert.That(result, Is.InstanceOf<NoContentResult>());
    }
    
    [Test]
    public async Task DeleteCarTypeReturnsNotFoundWithAdminIfNotExistentId()
    {
        //Arrange
        var carType = new CarType { Id = 1, Brand = "TestBrand", Model = "TestModel" };
        _carTypeRepositoryMock.Setup(crt => crt.GeById(It.IsAny<int>())).ReturnsAsync(carType);
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Admin") }));
        _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        
        //Act
        var result = await _controller.DeleteCarType(2);
        
        //Assert
        Assert.That(result, Is.InstanceOf<NoContentResult>());
    }
    
    [Test]
    public async Task DeleteCarTypeReturnsForbidResultIfNoAdmin()
    {
        //Arrange
        var carType = new CarType { Id = 1, Brand = "TestBrand", Model = "TestModel" };
        _carTypeRepositoryMock.Setup(crt => crt.GeById(It.IsAny<int>())).ReturnsAsync(carType);
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "User") }));
        _controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = user } };
        
        //Act
        var result = await _controller.DeleteCarType(1);
        
        //Assert
        Assert.That(result, Is.InstanceOf<ForbidResult>());
    }
    
    
}