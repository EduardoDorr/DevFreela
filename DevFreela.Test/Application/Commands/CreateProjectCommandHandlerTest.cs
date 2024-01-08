using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

using DevFreela.Application.Projects.CreateProject;

namespace DevFreela.UnitTests.Application.Commands;

public class CreateProjectCommandHandlerTest
{
    [Fact]
    public async Task InputDataIsOk_Executed_ReturnProjectId()
    {
        // Arrange
        var projectRepositorySubstitute = Substitute.For<IUnitOfWork>();

        var createProjectCommand = new CreateProjectCommand("Title1", "Description1", 1, 2, 1000);

        var createprojectCommandHandler = new CreateProjectCommandHandler(projectRepositorySubstitute);

        // Act
        var projectId = await createprojectCommandHandler.Handle(createProjectCommand, new CancellationToken());

        //Assert
        Assert.True(projectId >= 0);

        projectRepositorySubstitute.Received(Quantity.Exactly(1)).Projects.Create(Arg.Any<Project>());
    }
}