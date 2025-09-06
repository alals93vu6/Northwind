using MediatR;
using NorthwindTest.Data;

namespace NorthwindTest.Application.Northwind.Commands.CreateUserCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        public readonly NorthwindContext _context;

        public CreateUserHandler(NorthwindContext context)
        {
            _context = context;
        }
        public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = request.GetNewData;

            _context.Customers.Add(newUser);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateUserResult()
            {
                ReturnMessage = $"新增成功！新增的ID為{newUser.CustomerID}",
            };
        }
    }
}
