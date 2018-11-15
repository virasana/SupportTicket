using System;
using System.Collections.Generic;
using InterfacesLib;
using ST.SharedEntities.Models;

namespace ST.ServicesLib
{
    public class STService<TRepo> : ISTService<ISTRepo> where TRepo: ISTRepo
    {
        private readonly TRepo _repo;

        public STService(TRepo repo)
        {
            _repo = repo;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            var result = _repo.AddTicket(ticket);
            return result;
        }

        public ICollection<Ticket> GetClosedTickets()
        {
            var result = _repo.GetClosedTickets();
            return result;
        }

        public ICollection<Ticket> GetClosedTicketsMatching(string searchTerm)
        {
            var result = _repo.GetClosedTicketsMatching(searchTerm);
            return result;
        }

        public ICollection<Severity> GetSeverities()
        {
            var result = _repo.GetSeverities();
            return result;
        }

        public ICollection<Product> GetProducts()
        {
            var result = _repo.GetProducts();
            return result;
        }

        public Ticket GetTicket(int id)
        {
            var result = _repo.GetTicket(id);
            return result;
        }

        public Ticket AddTicket(Ticket ticket)
        {
            var result = _repo.AddTicket(ticket);

            return result;
        }

        public ISTRepo Repo => _repo;
    }
}
