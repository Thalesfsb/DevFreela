using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var pagination = new Pagination(request.Search, request.Size, request.Page);

            var projects = await _repository.GetAll(pagination);

            if (projects is null)
                return ResultViewModel<List<ProjectViewModel>>.Error("Projeto não existe");

            var model = projects.Select(ProjectViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectViewModel>>.Success(model);
        }
    }
}
