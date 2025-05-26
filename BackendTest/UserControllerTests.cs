using API.OutputDto;

namespace BackendTest;

using Xunit;
using Moq;
using API.Controllers;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _controller = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOkWithUsers()
    {
        _userServiceMock.Setup(s => s.GetAllUsersAsync())
            .ReturnsAsync(new List<UserDto> { new UserDto() });

        var result = await _controller.GetAllUsers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<List<UserDto>>(okResult.Value);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOkWithMinusOne_WhenNull()
    {
        _userServiceMock.Setup(s => s.GetAllUsersAsync())
            .ReturnsAsync((List<UserDto>?)null);

        var result = await _controller.GetAllUsers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(-1, okResult.Value);
    }

    [Fact]
    public async Task GetUserById_ReturnsOkWithUser()
    {
        _userServiceMock.Setup(s => s.GetUserById(1))
            .ReturnsAsync(new UserDto());

        var result = await _controller.GetUserById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<UserDto>(okResult.Value);
    }

    [Fact]
    public async Task GetUserById_ReturnsOkWithMinusOne_WhenNull()
    {
        _userServiceMock.Setup(s => s.GetUserById(1))
            .ReturnsAsync((UserDto)null);

        var result = await _controller.GetUserById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(-1, okResult.Value);
    }
}