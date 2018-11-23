using System.Collections.Generic;
using ST.SharedEntitiesLib;
using ST.SharedInterfacesLib;

namespace ST.AppServicesLib
{
    public class STAppService<TRepo> : ISTAppService<ISTRepo> where TRepo: ISTRepo
    {
        private readonly TRepo _repo;

        public STAppService(TRepo repo)
        {
            _repo = repo;
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            var result = _repo.AddTicket(ticket);
            return result;
        }

        public ICollection<Ticket> GetActiveTickets()
        {
            var result = _repo.GetActiveTickets();
            return result;
        }

        public ICollection<Ticket> GetActiveTicketsMatching(string searchTerm)
        {
            var result = _repo.GetActiveTicketsMatching(searchTerm);
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
