using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.Application.ViewModels.Template;
using MediatR;

namespace CabinetManagement.Application.Handlers.Template;
public class RequestTemplate : IRequest<TemplateViewModel>
{
    //Add parameters
}
public class HandlerTemplate : IRequestHandler<RequestTemplate, TemplateViewModel>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public HandlerTemplate(IApplicationDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    public async Task<TemplateViewModel> Handle(RequestTemplate request, CancellationToken cancellationToken)
    {
        //add code handle
        return new TemplateViewModel();
    }
}
