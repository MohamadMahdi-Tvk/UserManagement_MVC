using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Services.Users.Commands;
using MyProject.Application.Services.Users.Queries;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUsersQuery(cancellationToken));
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var createUser = await _mediator.Send(new CreateUserCommand(request, cancellationToken));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(request, cancellationToken));
            return View(user);
        }
    }
}
