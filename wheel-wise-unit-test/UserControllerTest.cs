using System.ComponentModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using wheel_wise_unit_test.Utilities;
using wheel_wise.Contracts;
using wheel_wise.Controllers;
using wheel_wise.Model;
using wheel_wise.Model.DTO;
using wheel_wise.Service.Repository.UserRepo;

namespace wheel_wise_unit_test;

public class UserControllerTest
{
    private Mock<IUserRepository> _userRepository;
    private UserController _userController;
    private Mock<ILogger<UserController>> _loggerMock;

    [SetUp]
    public void SetUp()
    {
        _userRepository = new Mock<IUserRepository>();
        _loggerMock = new Mock<ILogger<UserController>>();
        _userController = new UserController(_userRepository.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetAllReturnsOk()
    {
        // Arrange
        var users = new List<User>();
        _userRepository.Setup(x => x.GetAll()).ReturnsAsync(users);

        // Act
        var result = await _userController.GetAll();

        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task GetAllReturnsStatusCode500()
    {
        // Arrange
        _userRepository.Setup(x => x.GetAll()).ThrowsAsync(new Exception());

        // Act
        var result = await _userController.GetAll();

        // Assert
        Assert.IsInstanceOf(typeof(ObjectResult), result.Result);
        var objectResult = result.Result as ObjectResult;
        Assert.AreEqual(500, objectResult.StatusCode);
        Assert.AreEqual("Could not process the request", objectResult.Value);
    }

    [Test]
    public async Task GetByNameReturnsOk()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetByName("admin");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task GetByNameReturnsForbid()
    {
        // Arrange
        var user = ConfigureHttpContext.UserBadContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetByName("admin");

        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result.Result);
    }

    [Test]
    public async Task GetByNameReturnsOkIfAdminRequests()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetByName("admin");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task GetByNameReturnsNotFound()
    {
        // Arrange
        ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ThrowsAsync(new Exception());

        // Act
        var result = await _userController.GetByName("lksndfg");

        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
    }

    [Test]
    public async Task GetFavoriteAdsByUserNameReturnsOkIfUsersRequestTheirOwn()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        var adsList = new List<Advertisement>();
        _userRepository.Setup(x => x.GetFavoriteAdsByUserName(It.IsAny<string>())).ReturnsAsync(adsList);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task GetFavoriteAdsByUserNameReturnsForbidIfUsersRequestNotTheirOwn()
    {
        // Arrange
        var user = ConfigureHttpContext.UserBadContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result.Result);
    }

    [Test]
    public async Task GetFavoriteAdsByUserNameReturnsNotFoundIfUsersRequestNotFoundUser()
    {
        // Arrange
        ConfigureHttpContext.UserGoodContext(_userController);
        User user = null;
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
    }

    [Test]
    public async Task GetFavoriteAdsByUserNameReturnsOkIfAdminRequests()
    {
        // Arrange
        User user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }


    [Test]
    public async Task GetAdsByUserNameReturnsOkIfUsersRequestTheirOwn()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        var adsList = new List<AdvertisementDTO>();
        _userRepository.Setup(x => x.GetAdsByUserName(It.IsAny<string>())).ReturnsAsync(adsList);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task GetAdsByUserNameReturnsForbidIfUsersRequestNotTheirOwn()
    {
        // Arrange
        var user = ConfigureHttpContext.UserBadContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result.Result);
    }

    [Test]
    public async Task GetAdsByUserNameReturnsNotFoundIfUsersRequestNotFoundUser()
    {
        // Arrange
        ConfigureHttpContext.UserGoodContext(_userController);
        User user = null;
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
    }

    [Test]
    public async Task GetAdsByUserNameReturnsOkIfAdminRequests()
    {
        // Arrange
        User user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        var adsList = new List<AdvertisementDTO>();
        _userRepository.Setup(x => x.GetAdsByUserName(It.IsAny<string>())).ReturnsAsync(adsList);

        // Act
        var result = await _userController.GetFavoriteAdsByUserName("kjnasdf");

        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task AddFavoriteAdvertisementReturnsOk()
    {
        // Arrange
        User user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        _userRepository.Setup(x => x.AddFavoriteAdvertisement(It.IsAny<string>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _userController.AddFavoriteAdvertisement("jkabdng", 354684);
        
        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result);
    }
    
    [Test]
    public async Task AddFavoriteAdvertisementReturnsForbid()
    {
        // Arrange
        User user = ConfigureHttpContext.UserBadContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        _userRepository.Setup(x => x.AddFavoriteAdvertisement(It.IsAny<string>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _userController.AddFavoriteAdvertisement("jkabdng", 354684);
        
        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result);
    }
    
    [Test]
    public async Task AddFavoriteAdvertisementReturnsStatusCode500()
    {
        // Arrange
        User user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        _userRepository.Setup(x => x.AddFavoriteAdvertisement(It.IsAny<string>(), It.IsAny<int>()))
            .ThrowsAsync(new Exception());
        
        // Act
        var result = await _userController.AddFavoriteAdvertisement("jkabdng", 354684);
        
        // Assert
        var objectResult = result as ObjectResult;
        Assert.IsInstanceOf(typeof(ObjectResult), result);
        Assert.AreEqual(500, objectResult.StatusCode);
    }

    [Test]
    public async Task RemoveFavoriteAdvertisementReturnNoContent()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        _userRepository.Setup(x => x.RemoveFavoriteAdvertisement(It.IsAny<string>(), It.IsAny<int>()))
            .Returns(Task.CompletedTask);
        
        // Act
        var result = await _userController.RemoveFavoriteAdvertisement("léknsdfg", 6156);
        
        // Assert
        Assert.IsInstanceOf(typeof(NoContentResult), result);
    }   

    [Test]
    public async Task RemoveFavoriteAdvertisementReturnNotFound()
    {
        // Arrange
        ConfigureHttpContext.UserGoodContext(_userController);
        User user = null;
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        
        // Act
        var result = await _userController.RemoveFavoriteAdvertisement("léknsdfg", 6156);
        
        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result);
    }   
    
    

    [Test]
    public async Task RemoveFavoriteAdvertisementReturn500StatusCode()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(user);
        _userRepository.Setup(x => x.RemoveFavoriteAdvertisement(It.IsAny<string>(), It.IsAny<int>()))
            .ThrowsAsync(new Exception());
        
        // Act
        var result = await _userController.RemoveFavoriteAdvertisement("léknsdfg", 6156);
        
        // Assert
        var objectResult = result as ObjectResult;
        Assert.IsInstanceOf(typeof(ObjectResult), result);
        Assert.AreEqual(500, objectResult.StatusCode);
    }

    [Test]
    public async Task UpdateByIdReturnsOk()
    {
        // Arrange
        var user = ConfigureHttpContext.IdentityUserGoodContext(_userController);
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(user);

        var regRequest = new RegistrationResponse("kdfng@sdfg", "kjbdfg");
        _userRepository.Setup(x => x.UpdateIdentityUserData(It.IsAny<IdentityUser>(), new DataChangeRequest("lknsdf", "dfg")))
            .ReturnsAsync(regRequest);
        
        // Act
        var result = await _userController.UpdateById("lknbdfg", new DataChangeRequest("lkndsfg", "kdsf"));
        
        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }

    [Test]
    public async Task UpdateByIdReturnsForbid()
    {
        // Arrange
        var user = ConfigureHttpContext.IdentityUserBadContext(_userController);
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(user);

        var regRequest = new RegistrationResponse("kdfng@sdfg", "kjbdfg");
        _userRepository.Setup(x => x.UpdateIdentityUserData(It.IsAny<IdentityUser>(), new DataChangeRequest("lknsdf", "dfg")))
            .ReturnsAsync(regRequest);
        
        // Act
        var result = await _userController.UpdateById("lknbdfg", new DataChangeRequest("lkndsfg", "kdsf"));
        
        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result.Result);
    }

    [Test]
    public async Task UpdateByIdReturnsStatusCode500()
    {
        // Arrange
        var identityUser = ConfigureHttpContext.IdentityUserGoodContext(_userController);
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(identityUser);
        
        _userRepository.Setup(x => x.UpdateIdentityUserData(It.IsAny<IdentityUser>(), It.IsAny<DataChangeRequest>()))
            .ThrowsAsync(new Exception());
        
        // Act
        var result = await _userController.UpdateById("lknbdfg", new DataChangeRequest("lkndsfg", "kdsf"));
        
        // Assert
        var statusCodeResult = (StatusCodeResult)result.Result;
        Assert.AreEqual(500, statusCodeResult.StatusCode);
    }

    [Test]
    public async Task DeleteUserReturnsNoContent()
    {
        // Arrange
        var user = ConfigureHttpContext.UserGoodContext(_userController);
        _userRepository.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(user);
        
        _userRepository.Setup(x => x.DeleteUser(user)).Returns(Task.CompletedTask);
        
        // Act
        var result = await _userController.DeleteUserById(654);
        
        // Assert
        Assert.IsInstanceOf(typeof(NoContentResult), result);
        
    }

    [Test]
    public async Task DeleteUserReturnsForbid()
    {
        // Arrange
        var user = ConfigureHttpContext.UserBadContext(_userController);
        _userRepository.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(user);
        
        // Act
        var result = await _userController.DeleteUserById(54);
        
        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result);
    }

    [Test]
    public async Task DeleteUserReturnsNotFound()
    {
        // Arrange
        ConfigureHttpContext.UserGoodContext(_userController);
        User user = null;
        _userRepository.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(user);
        
        // Act
        var result = await _userController.DeleteUserById(234);
        
        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result);
    }

    [Test]
    public async Task UpdatePasswordByIdReturnsOk()
    {
        // Arrange
        var identityUser = ConfigureHttpContext.IdentityUserGoodContext(_userController);
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(identityUser);

        var registrationResponse = new RegistrationResponse("lksjdf", "kjdfg");
        _userRepository.Setup(x => x.UpdatePasswordById(It.IsAny<IdentityUser>(), It.IsAny<PasswordChangeRequest>()))
            .ReturnsAsync(registrationResponse);
        
        // Act
        var result = await _userController.UpdatePasswordById("lskjdf", new PasswordChangeRequest("ksdfg", "sdfg"));
        
        // Assert
        Assert.IsInstanceOf(typeof(OkObjectResult), result.Result);
    }
    
    [Test]
    public async Task UpdatePasswordByIdReturnsForbid()
    {
        // Arrange
        var identityUser = ConfigureHttpContext.IdentityUserBadContext(_userController);
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(identityUser);

        var registrationResponse = new RegistrationResponse("lksjdf", "kjdfg");
        _userRepository.Setup(x => x.UpdatePasswordById(It.IsAny<IdentityUser>(), It.IsAny<PasswordChangeRequest>()))
            .ReturnsAsync(registrationResponse);
        
        // Act
        var result = await _userController.UpdatePasswordById("lskjdf", new PasswordChangeRequest("ksdfg", "sdfg"));
        
        // Assert
        Assert.IsInstanceOf(typeof(ForbidResult), result.Result);
    }
    
    [Test]
    public async Task UpdatePasswordByIdReturnsNoContent()
    {
        // Arrange
        ConfigureHttpContext.IdentityUserBadContext(_userController);
        IdentityUser identityUser = null;
        _userRepository.Setup(x => x.GetIdentityUserById(It.IsAny<string>())).ReturnsAsync(identityUser);

        var registrationResponse = new RegistrationResponse("lksjdf", "kjdfg");
        _userRepository.Setup(x => x.UpdatePasswordById(It.IsAny<IdentityUser>(), It.IsAny<PasswordChangeRequest>()))
            .ReturnsAsync(registrationResponse);
        
        // Act
        var result = await _userController.UpdatePasswordById("lskjdf", new PasswordChangeRequest("ksdfg", "sdfg"));
        
        // Assert
        Assert.IsInstanceOf(typeof(NotFoundObjectResult), result.Result);
    }
    
}