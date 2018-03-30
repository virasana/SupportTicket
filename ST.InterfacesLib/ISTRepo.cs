
using System.Collections.Generic;
using ST.SharedEntities.Models;

namespace InterfacesLib
{
    public interface ISTRepo
    {
        Ticket AddTicket(Ticket info);

        ICollection<Ticket> GetClosedTickets();

        ICollection<Ticket> GetClosedTicketsMatching(string searchTerm);

        ICollection<Severity> GetSeverities();

        ICollection<Product> GetProducts();

        Ticket GetTicket(int id);
    }
}
