using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Application.Services.Roles.Queries;
using MyProject.Application.Services.Users.Commands;
using MyProject.Application.Services.Users.Queries;
using MyProject.Controllers.Base;
using MyProject.DataAccess.ViewModels.Roles.Queries.GetRoles;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;
using MyProject.DataAccess.ViewModels.Users.Commands.DeleteUser;
using MyProject.DataAccess.ViewModels.Users.Commands.UpdateUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;

namespace MyProject.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUsersQuery(cancellationToken));
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            ViewBag.Roles = new SelectList(await _mediator.Send(new GetRolesQuery(cancellationToken)),"Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var createUser = await _mediator.Send(new CreateUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var userUpdate = await _mediator.Send(new UpdateUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> GetUser(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(Index));
        }

    }
}
