using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesLib;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using ST.SharedEntities.Models;

namespace ST.SQLRepoLib
{
    public class SQLRepo : ISTRepo
    {
        private readonly Ticket _ticketStub = new Ticket()
        {
            Active = true,
            Description = "New Ticket",
            Problem = "Problem!",
            Product = new Product() { Description = "P1", ProductId = 1 }
        };

        public virtual Ticket AddTicket(Ticket ticket)
        {
            //using (var ctx = new STEFModel())
            //{
            //    ticket.Product = null;
            //    ticket.Severity = null;

            //    ctx.Ticket.Add(ticket);

            //    ctx.SaveChanges();

            //    var result = ctx.Ticket
            //        .Include("Product")
            //        .Include("Severity")
            //        .FirstOrDefault(t => t.TicketId == ticket.TicketId);

            //    return result;
            //}

            return _ticketStub;
        }

        public ICollection<Ticket> GetClosedTickets()
        {
            //using (var ctx = new STEFModel())
            //{
            //    var result = ctx.Ticket
            //        .Include("Severity")
            //        .Include("Product")
            //        .Where(t => t.Active)
            //        .ToList();
            //    return result;
            //}
            return new List<Ticket>();
        }

        private ICollection<Ticket> GetClosedTicketsMatching(List<int> ticketIds)
        {
            //using (var ctx = new STEFModel())
            //{
            //    var result = ctx.Ticket
            //        .Include("Severity")
            //        .Include("Product")
            //        .Where(t => t.Active && ticketIds.Any(tid => tid == t.TicketId))
            //        .ToList();
            //    return result;
            //}
            return new List<Ticket>();
        }

        public ICollection<Ticket> GetClosedTicketsMatching(string searchTerm)
        {
            // TODO: Search by Facet, Add Suggestions to the front end
            // TODO: Note: you should be using Azure queries to get the keys specific to an index, rather than using the admin key!   
            //var searchServiceName = "supportticket";
            //var apiKey = ConfigurationManager.AppSettings["AzureSearchKey"];
            //var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
            //var indexClient = searchClient.Indexes.GetClient("idxticket");
            //var sp = new SearchParameters(){ SearchMode = SearchMode.All} ;
            //var docs = indexClient.Documents.Search<Ticket>(searchTerm, sp).Results;
            //List<int> ticketIds = new List<int>();

            //foreach (var searchResult in docs)
            //{
            //    ticketIds.Add(searchResult.Document.TicketId);
            //}

            //var result = GetClosedTicketsMatching(ticketIds);

            //return result;

            return new List<Ticket>();
        }

        public ICollection<Severity> GetSeverities()
        {
            //using (var ctx = new STEFModel())
            //{
            //    var result = ctx.Severity.ToList();
            //    return result;
            //}

            return new List<Severity>()
            {
                new Severity()
                {
                    DisplayName = "S1",
                    SeverityId = 1
                }
            };
        }

        public ICollection<Product> GetProducts()
        {
            //using (var ctx = new STEFModel())
            //{
            //    var result = ctx.Product.ToList();
            //    return result;
            //}
            return new List<Product>()
            {
                new Product(){Description = "P1", ProductId = 1}
            };
        }

        public Ticket GetTicket(int id)
        {
            //using (var ctx = new STEFModel())
            //{
            //    var result = ctx.Ticket
            //        .Include("Severity")
            //        .Include("Product")
            //        .FirstOrDefault(t => t.ProductId.Equals(id));
            //    return result;
            //}

            return _ticketStub;
        }
    }
}
