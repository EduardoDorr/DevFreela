using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(int skip = 0, int take = 50);
    ProjectDetailsViewModel? GetById(int id);
    int Create(CreateProjectInputModel inputModel);
    void Update(UpdateProjectInputModel inputModel);
    void CreateComment(CreateCommentInputModel inputModel);
    void Delete(int id);
    void Start(int id);
    void Finish(int id);
}