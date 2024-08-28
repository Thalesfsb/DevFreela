﻿using DevFreela.Application.Models.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdHandler : IRequestHandler<GetSkillByIdQuery, ResultViewModel<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetSkillByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<SkillViewModel>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Skills
                .SingleOrDefaultAsync(s => s.Id == request.Id);

            if (result is null)
                return ResultViewModel<SkillViewModel>.Error("Skill não existe");

            var model = SkillViewModel.FromEntity(result);

            return ResultViewModel<SkillViewModel>.Success(model);
        }
    }
}
