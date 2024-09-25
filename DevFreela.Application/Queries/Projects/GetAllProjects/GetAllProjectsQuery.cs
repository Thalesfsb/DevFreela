using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectViewModel>>>
    {
        public GetAllProjectsQuery(string search, int size, int page)
        {
            Search = search;
            Size = size;
            Page = page;
        }

        public string? Search { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }

    }
}
