using DevFreela.Domain.Models;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Application.Projects.GetProjects;

namespace DevFreela.UnitTests.Application.Queries;

public class GetProjectsQueryHandlerTests
{
    [Fact]
    public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
    {
        // Arrange
        var projects = new PaginationResult<Project>
        {
            Data = new List<Project>
            {
                new("Title1", "Description1", 1, 2, 1000),
                new("Title2", "Description2", 3, 4, 2000),
                new("Title3", "Description3", 5, 6, 3000)
            }
        };

        var projectRepositorySubstitute = Substitute.For<IProjectRepository>();

        projectRepositorySubstitute.GetAllAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).Returns(projects);

        var getProjectsQuery = new GetProjectsQuery("", 1, 2);
        var getProjectsQueryHandler = new GetProjectsQueryHandler(projectRepositorySubstitute);

        // Act
        var paginationProjectViewModelList = await getProjectsQueryHandler.Handle(getProjectsQuery, new CancellationToken());

        // Assert
        Assert.NotNull(paginationProjectViewModelList);
        Assert.NotEmpty(paginationProjectViewModelList.Data);
        Assert.Equal(projects.Data.Count, paginationProjectViewModelList.Data.Count());

        await projectRepositorySubstitute.Received(Quantity.Exactly(1)).GetAllAsync(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>());
    }
}