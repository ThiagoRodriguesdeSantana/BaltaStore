using BaltaStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Fakes
{
    public class FakeEmailService : IEmailServices
    {
        public void Send(string to, string from, string subject, string boby)
        {
       
        }
    }
}
