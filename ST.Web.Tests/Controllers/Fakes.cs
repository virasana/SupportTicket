using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FakeItEasy;
using InterfacesLib;
using ST.SharedEntities.Models;

namespace ST.Web.Tests.Controllers
{
    public class DummyProductsFactory : DummyFactory<ICollection<Product>>
    {
        protected override ICollection<Product> Create()
        {
            ICollection<Product> result = new Collection<Product>();
            for (int n = 0; n < 3; n++)
            {
                result.Add(A.Fake<Product>());
            }
            return result;
        }
    }

    public class RepoFake : ISTRepo
    {
        public bool AddTicketWasCalled { get; private set; }
        public bool GetClosedTicketsWasCalled { get; private set; }
        public bool GetProductsWasCalled { get; set; }
        public bool GetSeveritiesWasCalled { get; set; }

        public RepoFake()
        {
            AddTicketWasCalled = false;
            GetClosedTicketsWasCalled = false;
            GetProductsWasCalled = false;
        }


        public Ticket AddTicket(Ticket ticket)
        {
            AddTicketWasCalled = true;
            ticket.TicketId = 1;
            return ticket;
        }
        public ICollection<Ticket> GetClosedTickets()
        {
            GetClosedTicketsWasCalled = true;
            var tickets = A.CollectionOfDummy<Ticket>(10);
            return tickets;
        }

        public ICollection<Ticket> GetClosedTicketsMatching(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public ICollection<Severity> GetSeverities()
        {
            GetSeveritiesWasCalled = true;
            var result = A.CollectionOfDummy<Severity>(3);
            return result;
        }

        public ICollection<Product> GetProducts()
        {
            GetProductsWasCalled = true;
            return A.Dummy<ICollection<Product>>();
        }

        public Ticket GetTicket(int id)
        {
            throw new NotImplementedException();
        }
    }
}
