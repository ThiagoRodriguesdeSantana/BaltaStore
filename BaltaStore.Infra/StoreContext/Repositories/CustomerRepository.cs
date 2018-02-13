using BaltaStore.Infra.StoreContext.DataContests;
using System.Data;
using System.Linq;
using Dapper;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using System.Collections.Generic;
using System;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;

        }

        public bool CheckDocument(string document)
        {
            return _context.Connection.Query<bool>(
                "spCheckDocument",
                new { Document = document },
                commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.Connection.Query<bool>(
               "spCheckEmail",
               new { Email = email },
               commandType: CommandType.StoredProcedure)
               .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
             return _context.Connection.Query<ListCustomerQueryResult>(
               "SELECT [Id],CONCAT([FIRSTNAME],' ',[LASTNAME]) AS [NAME], [DOCUMENT], [EMAIL] FROM [CUSTOMER]");
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return _context.Connection.Query<GetCustomerQueryResult>(
               "SELECT [Id],CONCAT([FIRSTNAME],' ',[LASTNAME]) AS [NAME], [DOCUMENT], [EMAIL] FROM [CUSTOMER] WHERE [Id] = @Id",
               new {Id = id})
               .FirstOrDefault();
        }

        public IEnumerable<ListCutomerOrderQueryResult> GetOrder(Guid id)
        {
                   return _context
                   .Connection
                   .Query<ListCutomerOrderQueryResult>("", new { Id = id} );
      
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Adress,
                    Phone = customer.Phone
                },
                commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Adress)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.Districty,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                },
                commandType: CommandType.StoredProcedure);

            }

        }

    }
}
