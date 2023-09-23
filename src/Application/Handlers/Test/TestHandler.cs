using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabinetManagement.Application.Common.Exceptions;
using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.Application.IO.Test;
using CabinetManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CabinetManagement.Application.Handlers.Test;
public class TestHandler : IRequestHandler<TestRequest, TestResponse>
{
    public IApplicationDbContext _dbContext { get; set; }
    public TestHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
    {
        //var cabinetType = await _dbContext.CabinetTypes.Where(x => x.CabinetTypeId == request.Id).FirstOrDefaultAsync();
        //if (cabinetType != null)
        //{
        //    throw new ConflictException(request.Name, request.Id);
        //}
        var newType = new CabinetType
        {
            TypeName = request.Name,
            Description = request.Description
        };
        var response = await _dbContext.CabinetTypes.AddAsync(newType);
        await _dbContext.SaveChangesAsync();
        return new TestResponse
        {
            Message = "Success"
        };
    }
}
