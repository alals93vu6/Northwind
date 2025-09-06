using MediatR;
using NorthwindTest.Modles;

namespace NorthwindTest.Application.Northwind.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<CreateUserResult>
    {
        public CustomerItem? GetNewData { get; set; }
    }
}
