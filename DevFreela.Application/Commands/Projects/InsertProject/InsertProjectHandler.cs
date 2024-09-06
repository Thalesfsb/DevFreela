using DevFreela.Application.Notification.ProjectCreated;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Projects.InsertProject

{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMediator _mediator;
        public InsertProjectHandler(IProjectRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _repository.Add(project);

            var projectedCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);

            await _mediator.Publish(projectedCreated);

            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
