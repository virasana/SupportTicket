using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ST.SharedEntitiesLib;
using ST.SharedInterfacesLib;
using ST.SQLServerRepoLib.Extensions;

namespace ST.SQLServerRepoLib
{
    public class SQLRepo : ISTRepo
    {
        private static string _connectionString;

        public void Initialise(string connectionString)
        {
            _connectionString = connectionString;

            using (var context = new SupportTicketContext(connectionString))
            {
                context.Database.Migrate();
            }

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            using (var context = new SupportTicketContext(_connectionString))
            {
                var products = new List<Product>()
                {
                    new Product() {Description = "P1"},
                    new Product() {Description = "P2"},
                    new Product() {Description = "P3"}
                };

                foreach (var newProduct in products)
                {
                    var dbProduct =
                        context.Product.ToList().FirstOrDefault(p => p.Description.Equals(newProduct.Description));
                    if (dbProduct == null)
                    {
                        context.Product.AddOrUpdate(newProduct);
                    }
                }

                var severities = new List<Severity>()
                {
                    new Severity() {DisplayName = "Mild"},
                    new Severity() {DisplayName = "Medium"},
                    new Severity() {DisplayName = "Critical"}
                };

                foreach (var newSeverity in severities)
                {
                    var dbSeverity =
                        context.Severity.ToList().FirstOrDefault(s => s.DisplayName.Equals(newSeverity.DisplayName));
                    if (dbSeverity == null)
                    {
                        context.Severity.AddOrUpdate(newSeverity);
                    }
                }

                context.SaveChanges(true);
            }
        }

        public virtual Ticket AddTicket(Ticket ticket)
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                ticket.Product = null;
                ticket.Severity = null;
                ctx.Tickets.Add(ticket);

                ctx.SaveChanges();

                var result = ctx.Tickets
                    .Include("Product")
                    .Include("Severity")
                    .FirstOrDefault(t => t.TicketId == ticket.TicketId);

                return result;
            }

            // return new Tickets();
        }

        public ICollection<Ticket> GetActiveTickets()
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Tickets
                    .Include("Severity")
                    .Include("Product")
                    .Where(t => t.Active)
                    .ToList();
                return result;
            }

            //return new List<Tickets>();
        }

        private ICollection<Ticket> GetActiveTicketsMatching(List<int> ticketIds)
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Tickets
                    .Include("Severity")
                    .Include("Product")
                    .Where(t => t.Active && ticketIds.Any(tid => tid == t.TicketId))
                    .ToList();
                return result;
            }

            //return new List<Tickets>();
        }

        public ICollection<Ticket> GetActiveTicketsMatching(string searchTerm)
        {
            // TODO: Search by Facet, Add Suggestions to the front end
            // TODO: Note: you should be using Azure queries to get the keys specific to an index, rather than using the admin key!   
            //var searchServiceName = "supportticket";
            //var apiKey = "todo"; // TODO - ConfigurationManager.AppSettings["AzureSearchKey"];
            //var searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
            //var indexClient = searchClient.Indexes.GetClient("idxticket");
            //var sp = new SearchParameters() { SearchMode = SearchMode.All };
            //var docs = indexClient.Documents.Search<Tickets>(searchTerm, sp).Results;

            var ticketIds = new List<int>();

            //foreach (var searchResult in docs)
            //{
            //    ticketIds.Add(searchResult.Document.TicketId);
            //}

            var result = GetActiveTicketsMatching(ticketIds);

            return result;
        }

        public ICollection<Severity> GetSeverities()
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Severity.ToList();
                return result;
            }

            //return new List<Severity>();
        }

        public ICollection<Product> GetProducts()
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Product.ToList();
                return result;
            }

            //return new List<Product>();
        }

        public Ticket GetTicket(int ticketId)
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Tickets
                    .Include("Severity")
                    .Include("Product")
                    .FirstOrDefault(t => t.TicketId.Equals(ticketId));
                return result;
            }
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {
                var result = ctx.Tickets
                    .First(t => t.TicketId == ticket.TicketId);

                result.Active = ticket.Active;
                result.Description = ticket.Description;
                result.Problem = ticket.Problem;
                result.ProductId = ticket.ProductId;
                result.SeverityId = ticket.SeverityId;

                ctx.SaveChanges();

                return result;

            }
        }

        public bool DeleteTicket(int ticketId)
        {
            using (var ctx = new SupportTicketContext(_connectionString))
            {

                var ticket = GetTicket(ticketId);
                if (ticket == null) return false;

                ctx.Remove(ticket);
                ctx.SaveChanges();
                return true;
            }

        }
    }
}
