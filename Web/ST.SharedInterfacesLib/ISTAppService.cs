﻿using System.Collections.Generic;
using ST.SharedEntitiesLib;

namespace ST.SharedInterfacesLib
{
    public interface ISTAppService<out TRepo> where TRepo : ISTRepo
    {
        ICollection<Ticket> GetClosedTickets();

        ICollection<Ticket> GetClosedTicketsMatching(string searchTerm);

        ICollection<Severity> GetSeverities();

        ICollection<Product> GetProducts();

        Ticket GetTicket(int id);

        TRepo Repo { get; }

        Ticket AddTicket(Ticket ticket);
    }
}