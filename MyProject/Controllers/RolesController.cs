using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Roles.Queries;
using MyProject.Controllers.Base;

namespace MyProject.Controllers
{
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var roles = await _mediator.Send(new GetRolesQuery(cancellationToken));
            return View(roles);
        }
    }
}
