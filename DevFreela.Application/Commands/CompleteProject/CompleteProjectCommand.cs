using DevFreela.Application.Models.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CompleteProject
{
    public  class CompleteProjectCommand : IRequest<ResultViewModel>
    {
        public CompleteProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
