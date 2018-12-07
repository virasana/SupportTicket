using System.Collections.Generic;
using ST.SharedEntitiesLib;

namespace ST.SharedInterfacesLib
{
    public interface ISTAppService<out TRepo> where TRepo : ISTRepo
    {
        ICollection<Ticket> GetActiveTickets();

        ICollection<Ticket> GetActiveTicketsMatching(string searchTerm);

        ICollection<Severity> GetSeverities();

        StaticData GetStaticData();

        ICollection<Product> GetProducts();

        Ticket GetTicket(int id);

        TRepo Repo { get; }

        Ticket AddTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
    }
}