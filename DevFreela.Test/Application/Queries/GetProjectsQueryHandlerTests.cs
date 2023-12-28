using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Application.Projects.Queries;
using DevFreela.Application.Projects.Queries.Handlers;

namespace DevFreela.UnitTests.Application.Queries;

public class GetProjectsQueryHandlerTests
{
    [Fact]
    public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
    {
        // Arrange
        var projects = new List<Project>
        {
            new("Title1", "Description1", 1, 2, 1000),
            new("Title2", "Description2", 3, 4, 2000),
            new("Title3", "Description3", 5, 6, 3000)
        };

        var projectRepositorySubstitute = Substitute.For<IProjectRepository>();

        projectRepositorySubstitute.GetAllAsync().Returns(projects);

        var getProjectsQuery = new GetProjectsQuery();
        var getProjectsQueryHandler = new GetProjectsQueryHandler(projectRepositorySubstitute);

        // Act
        var projectViewModelList = await getProjectsQueryHandler.Handle(getProjectsQuery, new CancellationToken());

        // Assert
        Assert.NotNull(projectViewModelList);
        Assert.NotEmpty(projectViewModelList);
        Assert.Equal(projects.Count, projectViewModelList.Count());

        await projectRepositorySubstitute.Received(Quantity.Exactly(1)).GetAllAsync();
    }
}