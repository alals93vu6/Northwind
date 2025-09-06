using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthwindTest.Data;
using NorthwindTest.Modles;

namespace NorthwindTest.Application.Northwind.Queries.QueryUserLIstQuery
{
    public class QueryUserListHandler : IRequestHandler<QueryUserListQuery, QueryUserListResult>
    {
        public readonly NorthwindContext _context;

        public QueryUserListHandler(NorthwindContext northwindContext)
        {
            _context = northwindContext;
        }
        public async Task<QueryUserListResult> Handle(QueryUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _context.Customers.AsQueryable().ToListAsync(cancellationToken);
            return new QueryUserListResult()
            {
                ReturnList = userList.Select(userList => new CustomerItem
                {
                    CustomerID = userList.CustomerID,
                    CompanyName = userList.CompanyName,
                    ContactName = userList.ContactName,
                    ContactTitle = userList.ContactTitle,
                    Address = userList.Address,
                    City = userList.City,
                    Region = userList.Region,
                    PostalCode = userList.PostalCode,
                    Country = userList.Country,
                    Phone = userList.Phone,
                    Fax = userList.Fax
                }).ToList()

            };
        }
    }
}
