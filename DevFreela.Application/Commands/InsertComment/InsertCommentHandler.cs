﻿using DevFreela.Application.Models.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public InsertProjectHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == request.IdProject);

            if (project is null)
                return ResultViewModel<ProjectViewModel>.Error("Projeto não existe");

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
