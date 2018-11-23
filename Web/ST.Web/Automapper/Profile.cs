using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ST.SharedEntitiesLib;
using ST.Web.Models.ST;

namespace ST.Web.Automapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Ticket, TicketViewModel>();
        }
    }
}
