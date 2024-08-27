using Azure;
using DevFreela.Application.Models;
using DevFreela.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectViewModel>>>
    {
        public GetAllProjectsQuery(string search, int size, int page)
        {
            Search = search;
            Size = size;
            Page = page;
        }

        public string Search { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
