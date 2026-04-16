using QLHD.Application.Common.Attributes;

namespace QLHD.WebApi.Controllers;

[ApiController]
[Route("api")]
[AuthorizeAllRoles]
public abstract class AggregateRootController(IServiceProvider serviceProvider) : ControllerBase
{
    protected readonly IMediator Mediator = serviceProvider.GetRequiredService<IMediator>();
}