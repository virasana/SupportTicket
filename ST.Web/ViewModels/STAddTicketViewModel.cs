using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ST.SharedEntitiesLib;

namespace ST.Web.ViewModels
{
    public class STAddTicketViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<SelectListItem> Severities { get; set; }

        public IEnumerable<SelectListItem> Products{ get; set; }
    }
}