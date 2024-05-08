using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using wheel_wise.Controllers;
using wheel_wise.Service.Repository.ColorRepo;
using Color = wheel_wise.Model.Color;

namespace wheel_wise_unit_test;

public class ColorControllerTests
{
    private Mock<ILogger<ColorController>> _loggerMock;
    private  Mock<IColorRepository> _colorRepository;
    private ColorController _controller;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<ColorController>>();
        _colorRepository = new Mock<IColorRepository>();
        _controller = new ColorController(_loggerMock.Object, _colorRepository.Object);
    }

    [Test]
    public async Task GetAllReturnsOkResult()
    {
        var colorList = new List<Color> { new Color{ Name = "Red" },new Color{ Name = "White" }  };
        _colorRepository.Setup(cr => cr.GetAll()).ReturnsAsync(colorList);
        
        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}