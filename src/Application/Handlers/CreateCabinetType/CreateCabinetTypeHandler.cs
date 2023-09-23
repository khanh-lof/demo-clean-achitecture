using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CabinetManagement.Application.Common.Exceptions;
using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.Application.IO.CreateCabinetType;
using CabinetManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CabinetManagement.Application.Handlers.CreateCabinetType;
public class CreateCabinetTypeHandler : IRequestHandler<CreateCabinetTypeCommand, CreateCabinetTypeResponse>
{
    public IApplicationDbContext _dbContext { get; set; }
    public IMapper _mapper { get; set; }
    public CreateCabinetTypeHandler(IApplicationDbContext dbContext,IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<CreateCabinetTypeResponse> Handle(CreateCabinetTypeCommand request, CancellationToken cancellationToken)
    {
        //var cabinetType = await _dbContext.CabinetTypes.Where(x => x.CabinetTypeId == request.Id).FirstOrDefaultAsync();
        //if (cabinetType != null)
        //{
        //    throw new ConflictException(request.Name, request.Id);
        //}
        var newType = _mapper.Map<CabinetType>(request);
        await _dbContext.CabinetTypes.AddAsync(newType);
        await _dbContext.SaveChangesAsync();
        return new CreateCabinetTypeResponse
        {
            Message = "Success"
        };
    }
}
