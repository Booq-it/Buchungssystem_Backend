using Xunit;
using Moq;
using API.Controllers;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.OutputDto;

public class MovieControllerTests
{
    private readonly Mock<IMovieService> _movieServiceMock;
    private readonly MovieController _controller;

    public MovieControllerTests()
    {
        _movieServiceMock = new Mock<IMovieService>();
        _controller = new MovieController(_movieServiceMock.Object);
    }

    [Fact]
    public async Task GetAllMovies_ReturnsOkWithMovies()
    {
        _movieServiceMock.Setup(s => s.GetAllMovies())
            .ReturnsAsync(new List<MovieDto> { new MovieDto() });

        var result = await _controller.GetAllMovies();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<List<MovieDto>>(okResult.Value);
    }

    [Fact]
    public async Task GetAllMovies_ReturnsNotFound_WhenNull()
    {
        _movieServiceMock.Setup(s => s.GetAllMovies())
            .ReturnsAsync((List<MovieDto>?)null);

        var result = await _controller.GetAllMovies();

        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("No movies found!", notFoundResult.Value);
    }

    [Fact]
    public async Task GetMovieById_ReturnsOkWithMovie()
    {
        _movieServiceMock.Setup(s => s.GetMovieById(1))
            .ReturnsAsync(new MovieDto());

        var result = await _controller.GetMovieById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<MovieDto>(okResult.Value);
    }

    [Fact]
    public async Task GetMovieById_ReturnsOkWithMinusOne_WhenNull()
    {
        _movieServiceMock.Setup(s => s.GetMovieById(1))
            .ReturnsAsync((MovieDto?)null);

        var result = await _controller.GetMovieById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(-1, okResult.Value);
    }
}