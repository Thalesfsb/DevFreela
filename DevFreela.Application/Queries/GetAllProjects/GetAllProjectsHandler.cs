using DevFreela.Application.Models.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectViewModel>>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllProjectsHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {

            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted && (request.Search == "" || p.Title.Contains(request.Search) || p.Description.Contains(request.Search)))
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();

            var model = projects.Select(ProjectViewModel.FromEntity).ToList();

            return ResultViewModel<List<ProjectViewModel>>.Success(model);
        }
    }
}
