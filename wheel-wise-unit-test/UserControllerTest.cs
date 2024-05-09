using System.ComponentModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "admin@admin.com"),
            new Claim(ClaimTypes.Role, "Admin")
            // other required and custom claims
        }, "TestAuthentication"));

        var controller = _userController;
        controller.ControllerContext = new ControllerContext();
        controller.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User
            { Id = 1, IdentityUser = new IdentityUser { UserName = "admin", Email = "admin@admin.com" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@admin.com"),
            new Claim(ClaimTypes.Role, "User")
            // other required and custom claims
        }, "TestAuthentication"));

        var controller = _userController;
        controller.ControllerContext = new ControllerContext();
        controller.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User
            { Id = 1, IdentityUser = new IdentityUser { UserName = "admin", Email = "admin@admin.com" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@admin.com"),
            new Claim(ClaimTypes.Role, "Admin")
            // other required and custom claims
        }, "TestAuthentication"));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };

        var user = new User
            { Id = 1, IdentityUser = new IdentityUser { UserName = "admin", Email = "admin@admin.com" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "admin@admin.com"),
            new Claim(ClaimTypes.Role, "Admin")
            // other required and custom claims
        }, "TestAuthentication"));

        var controller = _userController;
        controller.ControllerContext = new ControllerContext();
        controller.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User { IdentityUser = new IdentityUser { Email = "valami@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "Admin")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        User user = new User { IdentityUser = new IdentityUser { Email = "i@i" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        var user = new User { IdentityUser = new IdentityUser { Email = "valami@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "User")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test"),
            new Claim(ClaimTypes.Role, "Admin")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        User user = new User { IdentityUser = new IdentityUser { Email = "i@i" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(
            new Claim[] { new Claim(ClaimTypes.Email, "test@test") }
        ));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        User user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(
            new Claim[] { new Claim(ClaimTypes.Email, "atest@test") }
        ));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        User user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(
            new Claim[] { new Claim(ClaimTypes.Email, "test@test") }
        ));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };
        User user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };

        var user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };

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
        var claims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, "test@test")
        }));
        _userController.ControllerContext.HttpContext = new DefaultHttpContext { User = claims };

        var user = new User { IdentityUser = new IdentityUser { Email = "test@test" } };
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
}