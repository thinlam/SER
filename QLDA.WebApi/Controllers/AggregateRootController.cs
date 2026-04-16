
using QLDA.Application.Common.Attributes;

namespace QLDA.WebApi.Controllers;

[ApiController, ApiExplorerSettings(GroupName = "v1")]
[AuthorizeAllRoles]
public abstract class AggregateRootController(IServiceProvider serviceProvider) : ControllerBase {
    protected readonly IMediator Mediator = serviceProvider.GetRequiredService<IMediator>();
}