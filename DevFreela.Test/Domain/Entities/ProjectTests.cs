using DevFreela.Domain.Enums;
using DevFreela.Domain.Entities;

namespace DevFreela.UnitTests.Domain.Entities;

public class ProjectTests
{
    [Fact]
    public void AProject_Created_StartDateAndFinishDateMustBeNullAndProjectStatusMustBeCreated()
    {
        // Arrange+Act
        var project = CreateProject();

        // Assert
        Assert.Equal(ProjectStatus.Created, project.Status);
        Assert.Null(project.StartedAt);
        Assert.Null(project.FinishedAt);
    }

    [Fact]
    public void ACreatedProject_Started_StartDateMustBeNotNullAndProjectStatusMustBeInProgress()
    {
        // Arrange
        var project = CreateProject();

        // Act
        project.Start();

        // Assert
        Assert.Equal(ProjectStatus.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);
    }

    [Fact]
    public void AInProgressProject_PendingPayment_FinishDateMustBeNullAndProjectStatusMustBePendingPayment()
    {
        // Arrange
        var project = CreateProject();
        project.Start();

        // Act
        project.SetPaymentPending();

        // Assert
        Assert.Equal(ProjectStatus.PaymentPending, project.Status);
        Assert.Null(project.FinishedAt);
    }

    [Fact]
    public void APendingPaymentProject_Finished_FinishDateMustBeNotNullAndProjectStatusMustBeFinished()
    {
        // Arrange
        var project = CreateProject();
        project.Start();
        project.SetPaymentPending();

        // Act
        project.Finish();

        // Assert
        Assert.Equal(ProjectStatus.Finished, project.Status);
        Assert.NotNull(project.FinishedAt);
    }

    [Fact]
    public void AInProgressProject_Cancelled_FinishDateMustBeNotNullAndProjectStatusMustBeCancelled()
    {
        // Arrange
        var project = CreateProject();
        project.Start();

        // Act
        project.Cancel();

        // Assert
        Assert.Equal(ProjectStatus.Cancelled, project.Status);
        Assert.NotNull(project.FinishedAt);
    }

    [Fact]
    public void ACreatedProject_Finished_StartDateMustBeNullAndProjectStatusMustBeCreated()
    {
        // Arrange
        var project = CreateProject();

        // Act
        project.Finish();

        // Assert
        Assert.Equal(ProjectStatus.Created, project.Status);
        Assert.Null(project.StartedAt);
    }

    [Fact]
    public void AFinishedProject_Cancelled_FinishDateMustBeNotNullAndProjectStatusMustBeFinished()
    {
        // Arrange
        var project = CreateProject();
        project.Start();
        project.SetPaymentPending();
        project.Finish();

        // Act
        project.Cancel();

        // Assert
        Assert.Equal(ProjectStatus.Finished, project.Status);
        Assert.NotNull(project.FinishedAt);
    }

    private static Project CreateProject()
    {
        return new Project("Title1", "Description1", 1, 2, 1000);
    }
}