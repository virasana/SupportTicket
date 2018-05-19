using System.Collections.Generic;
using ST.SharedEntitiesLib;

namespace ST.SharedInterfacesLib
{
    public interface ISTRepo
    {
        void Initialise();

        Ticket AddTicket(Ticket info);

        ICollection<Ticket> GetClosedTickets();

        ICollection<Ticket> GetClosedTicketsMatching(string searchTerm);

        ICollection<Severity> GetSeverities();

        ICollection<Product> GetProducts();

        Ticket GetTicket(int id);
    }
}
